using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FavoritesMenu : MonoBehaviour
{
    [SerializeField] private GameObject _scrollView;
    [SerializeField] private GameObject _nonFavorites;
    [SerializeField] private List<GameObject> _favorites;
    [SerializeField] private List<FavoriteButton> _menuFavoriteButton;
    [SerializeField] private List<FavoriteButton> _infoFavoriteButton;

    private void OnEnable()
    {
        UpdateFavorites();
    }

    private void UpdateFavorites()
    {
        var fav = SaveSystem.LoadData<FavoritesSaveData>();
        bool containsTrue = fav.Items.Exists(element => element == true);
        if (containsTrue)
        {
            _nonFavorites.SetActive(false);
            _scrollView.SetActive(true);
            for (int i = 0; i < fav.Items.Count; i++)
            {
                if (fav.Items[i])
                {
                    _favorites[i].SetActive(true);
                }
                else
                {
                    _favorites[i].SetActive(false);
                }
            }
        }
        else
        {
            _nonFavorites.SetActive(true);
            _scrollView.SetActive(false);
        }
    }

    public void RemoveFromFavorites(int index)
    {
        var fav = SaveSystem.LoadData<FavoritesSaveData>();
        fav.Items[index] = false;
        SaveSystem.SaveData(fav);
        UpdateFavorites();
    }

    public void HideFavorites()
    {
        gameObject.SetActive(false);
    }

    public void TryAddFavorites(int index) 
    {
        var fav = SaveSystem.LoadData<FavoritesSaveData>();
        if (fav.Items[index])
        {
            RemoveFromFavorites(index);
            _menuFavoriteButton[index].RemoveFromFavorites();
            _infoFavoriteButton[index].RemoveFromFavorites();
        }
        else
        {
            AddToFavorites(index);
            _menuFavoriteButton[index].AddToFavorites();
            _infoFavoriteButton[index].AddToFavorites();
        }
    }



    public void AddToFavorites(int index)
    {
        var fav = SaveSystem.LoadData<FavoritesSaveData>();
        fav.Items[index] = true;
        SaveSystem.SaveData(fav);
        UpdateFavorites();
    }
}
