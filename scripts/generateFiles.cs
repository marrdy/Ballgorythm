using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class generateFiles : MonoBehaviour
{
    public AchievementsLoader achievementfiles;
    public LevelData levelprogressfiles;

    private void Start()
    {
        levelprogressfiles =DataSaver.loadlocklevel();
        AchievementAdder data = new AchievementAdder(achievementfiles);
       achievementfiles.adder = data.achivecache;
    }
    public void resetLevel()
    {
        levelprogressfiles.CurrentLevel =0;
        for (int i = 0; i < levelprogressfiles.starsInlevels.Length; i++)
        {
            int star = levelprogressfiles.starsInlevels[i];
            star = 0;
        }
        LevelLocker datatosave = new LevelLocker();
        datatosave.CurrentLevel = levelprogressfiles.CurrentLevel;
        datatosave.starsperlevel = levelprogressfiles.starsInlevels;
        DataSaver.ProgressData(datatosave);
    }
     public void resetach()
     {
        foreach(achiveclass i in achievementfiles.adder)
        {
            i.Achived = false;
        }
        AchievementsLoader datatosave = new AchievementsLoader();
        datatosave.adder = achievementfiles.adder;
        DataSaver.AchivementDataSave(datatosave);
     }
}
