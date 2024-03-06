using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class FavoritesSaveData : SaveData
{
    public List<bool> Items {get; set;}

    public FavoritesSaveData(List<bool> items)
    {
        Items = items;
    }

}
