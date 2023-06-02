using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementTriggerScripts 
{

    public static void  AchievementTriggered(int AchievementIndex) 
    {
        achiveclass []VarLoaded;
        AchievementAdder LoadedData = DataSaver.LoadAchievements();
        VarLoaded = LoadedData.achivecache;
        VarLoaded[AchievementIndex].Achived = true;
        AchievementsLoader loader = new AchievementsLoader();
        loader.adder = VarLoaded;
        DataSaver.AchivementDataSave(loader);
    }

}
