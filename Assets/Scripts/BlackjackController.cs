using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class BlackjackController : MonoBehaviour
{
    [SerializeField] private BlackjackPack _blackjackPack;
    [SerializeField] private PlayerHand _playerHand;
    [SerializeField] private DealerHand _dealerHand;
    [SerializeField] private Button _moreButton;
    [SerializeField] private Button _passButon;
    [SerializeField] private TMP_Text _playerScore;
    [SerializeField] private TMP_Text _dealerScore;
    [SerializeField] private GameObject _endPanel;
    [SerializeField] private TMP_Text _endText;

    private void Start()
    {
        StartGame();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainScene");
    }

    private void StartGame()
    {
        _moreButton.gameObject.SetActive(false);
        _passButon.gameObject.SetActive(false);
        _blackjackPack.StartGame();
        _playerScore.text = "Player points: " + 0;
        _dealerScore.text = "Dealer points: " + 0;
        _dealerHand.CardAdded += UpdateDealerScore;
        _playerHand.CardAdded += UpdatePlayerScore;
        _blackjackPack.StartCardsDealed += StartPlayerTurn;
    }

    private void UpdatePlayerScore(int score)
    {
        _playerScore.text = "Player points: " + score;
    }

    private void UpdateDealerScore(int score)
    {
        _dealerScore.text = "Dealer points: " + score;
    }

    private void StartPlayerTurn()
    {
        _blackjackPack.StartCardsDealed -= StartPlayerTurn;
        if (_playerHand.GetCurrentScore() == 21)
        {
            _dealerHand.RevealSecondCard();
            ShowEndPanel("PLAYER WIN!");
            return;
        }
        if(_dealerHand.GetCurrentScore() == 21)
        {
            _dealerHand.RevealSecondCard();
            ShowEndPanel("DEALER WIN");
            return;
        }
        _moreButton.onClick.AddListener(PlayerGetCard);
        _passButon.onClick.AddListener(StartDealerTurn);
        _moreButton.gameObject.SetActive(true);
        _passButon.gameObject.SetActive(true);
    }

    private void PlayerGetCard()
    {
        _blackjackPack.GiveCardToPlayer();
        _moreButton.gameObject.SetActive(false);
        _passButon.gameObject.SetActive(false);
        _blackjackPack.PlayerGetCard += PlayerCardAdded;
    }

    private void PlayerCardAdded()
    {
        _blackjackPack.PlayerGetCard -= PlayerCardAdded;
        if(_playerHand.GetCurrentScore() > 21)
        {
            _moreButton.onClick.RemoveAllListeners();
            _passButon.onClick.RemoveAllListeners();
            _dealerHand.RevealSecondCard();
            ShowEndPanel("DEALER WIN");
            return;
        }
        _moreButton.gameObject.SetActive(true);
        _passButon.gameObject.SetActive(true);
    }

    private void StartDealerTurn()
    {
        _moreButton.onClick.RemoveAllListeners();
        _passButon.onClick.RemoveAllListeners();
        _moreButton.gameObject.SetActive(false);
        _passButon.gameObject.SetActive(false);
        _dealerHand.RevealSecondCard();
        StartCoroutine(DealerTurn());
    }

    private void ShowEndPanel(string winner)
    {
        _dealerHand.CardAdded -= UpdateDealerScore;
        _playerHand.CardAdded -= UpdatePlayerScore;
        _endText.text = winner;
        _endPanel.transform.DOScale(1, 0.5f).SetLink(gameObject).OnComplete(() => 
        {
            _endPanel.transform.DOScale(0, 0.5f).SetDelay(2f).SetLink(gameObject).OnComplete(() =>
            {
                _dealerHand.RemoveCards();
                _playerHand.RemoveCards();
                StartGame();
            });
        });
    }

    private void EndGame()
    {
        if(_dealerHand.GetCurrentScore() > 21)
        {
            ShowEndPanel("PLAYER WIN!");
            return;
        }
        if (_dealerHand.GetCurrentScore() == _playerHand.GetCurrentScore())
        {
            ShowEndPanel("DRAW!");
            return;
        }
        if (_dealerHand.GetCurrentScore() > _playerHand.GetCurrentScore())
        {
            ShowEndPanel("DEALER WIN!");
            return;
        }
        else
        {
            ShowEndPanel("PLAYER WIN");
            return;
        }

    }

    private IEnumerator DealerTurn()
    {
        yield return new WaitForSeconds(1f);
        while (_dealerHand.GetCurrentScore() < 17)
        {
            _blackjackPack.GiveCardToDealer();
            yield return new WaitForSeconds(1.5f);
        }
        EndGame();
    }
}
