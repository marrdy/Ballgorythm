using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class DataSaver
{
    static string  PathForLevel = Application.persistentDataPath + "Progress.Lvlpg";
    static string  PathForAchivement = Application.persistentDataPath + "AchievementData.Lvlpg";
    static string  PathForAgreement = Application.persistentDataPath + "agreement.Lvlpg";

    public static void AchivementDataSave(AchievementsLoader Info)
    {

       
        BinaryFormatter BF = new BinaryFormatter();    
        FileStream FS = new FileStream(PathForAchivement, FileMode.Create);
        AchievementAdder data = new AchievementAdder(Info);
        BF.Serialize(FS, data);
        FS.Close();
    }



    public static AchievementAdder achReset(achiveclass[] adder)
    {
          BinaryFormatter BF = new BinaryFormatter();    
             FileStream FS = new FileStream(PathForAchivement, FileMode.Create);
             AchievementsLoader Info = new AchievementsLoader();
             Info.adder = adder;
             AchievementAdder data = new AchievementAdder(Info);
             BF.Serialize(FS, data);
             FS.Close();
             return data;
    }
    public static AchievementAdder LoadAchievements(achiveclass[] adder)
    {
        if (File.Exists(PathForAchivement))
        {

            BinaryFormatter formater = new BinaryFormatter();
            FileStream FS = new FileStream(PathForAchivement, FileMode.Open);
            AchievementAdder data = formater.Deserialize(FS) as AchievementAdder;
            FS.Close();
            return data;
        }
        else
        {
            Debug.LogError("NO FILE LOADED");
           
           
            return  achReset(adder);
          
        }

    }
    public static void ProgressData(LevelLocker Info)
    {   
        BinaryFormatter BF = new BinaryFormatter();
       
        FileStream FS = new FileStream(PathForLevel, FileMode.Create);
        LevelData data = new LevelData(Info);
        BF.Serialize(FS, data);
      
        FS.Close();
    }
    public static LevelData loadlocklevel()
    {
        if (File.Exists(PathForLevel)) 
        {
            BinaryFormatter formater = new BinaryFormatter();
            FileStream FS = new FileStream(PathForLevel, FileMode.Open);
           LevelData data= formater.Deserialize(FS) as LevelData;
            FS.Close();
            return data;
        }
        else 
        {
            Debug.LogError(PathForAchivement + " was not found, new file save is created, level start to 0 and stars resets...");
            BinaryFormatter BF = new BinaryFormatter();
            FileStream FS = new FileStream(PathForLevel, FileMode.Create);
            LevelLocker newlock = new LevelLocker();
            newlock.CurrentLevel = 0;
            newlock.starsperlevel = new int[SceneManager.sceneCountInBuildSettings-4];
            LevelData data = new LevelData(newlock);
            BF.Serialize(FS, data);
            FS.Close();
            return data;
        }
        
    }
   public static bool resetprogress()
   {
     Debug.Log(PathForLevel);
        bool closeapp =false;
        if (File.Exists(PathForLevel))
        {
            File.Delete(PathForLevel);
            Debug.Log("Progress file deleted.");
            closeapp = true;
        }

        if (File.Exists(PathForAchivement))
        {
            File.Delete(PathForAchivement);
            Debug.Log("Achievement file deleted.");
            closeapp = true;
        }
        return closeapp;
   }
    public static bool loadAgreement()
    {
        bool data = new();
        if (File.Exists(PathForAgreement))
        {

            BinaryFormatter formater = new BinaryFormatter();
            FileStream FS = new FileStream(PathForAgreement, FileMode.Open);
            data = (bool)formater.Deserialize(FS);
            FS.Close();
            return data;
        }
        else
        {
            Debug.LogError("NO FILE LOADED");

            BinaryFormatter BF = new BinaryFormatter();
            FileStream FS = new FileStream(PathForAchivement, FileMode.Create);
            data =false;
            BF.Serialize(FS, data);
            FS.Close();
            return data;

        }

    }
    public static void agreetoconsent(bool Info)
    {


        BinaryFormatter BF = new BinaryFormatter();
        FileStream FS = new FileStream(PathForAgreement, FileMode.Create);
        bool data = Info;
        BF.Serialize(FS, data);
        FS.Close();
    }

}
