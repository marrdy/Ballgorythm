using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementTriggerScripts 
{

    public static void  AchievementTriggered(int AchievementIndex) 
    {   

        AchievementsLoader loader = new AchievementsLoader();
        achiveclass []VarLoaded;
        AchievementAdder LoadedData = DataSaver.LoadAchievements(loader.adder);
        VarLoaded = LoadedData.achivecache;
        VarLoaded[AchievementIndex].Achived = true;
        loader.adder = VarLoaded;
        DataSaver.AchivementDataSave(loader);
    }

}
