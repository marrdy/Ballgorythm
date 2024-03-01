using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class LevelData {

   public int CurrentLevel;
    public int[] starsInlevels;
    public bool agreed;
    public LevelData(LevelLocker locklev)
    {  
        CurrentLevel = locklev.CurrentLevel;
        starsInlevels = locklev.starsperlevel;
       
    }
}
