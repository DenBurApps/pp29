using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SettingSaveData : SaveData
{
    public bool IsDark { get; set; }

    public SettingSaveData (bool isDark)
    {
        IsDark = isDark;
    }
}
