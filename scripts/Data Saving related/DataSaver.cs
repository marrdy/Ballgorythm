using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class DataSaver
{
    static string  PathForLevel = Application.persistentDataPath + "Progress.Lvlpg";
    static string  PathForAchivement = Application.persistentDataPath + "AchievementData.Lvlpg";

    public static void AchivementDataSave(AchievementsLoader Info)
    {

       
        BinaryFormatter BF = new BinaryFormatter();    
        FileStream FS = new FileStream(PathForAchivement, FileMode.Create);
        AchievementAdder data = new AchievementAdder(Info);
        BF.Serialize(FS, data);
        FS.Close();
    }


    public static AchievementAdder LoadAchievements()
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
            return null;
          
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
            Debug.LogError(PathForAchivement + " was not found, new file save is created");
            BinaryFormatter BF = new BinaryFormatter();
            FileStream FS = new FileStream(PathForLevel, FileMode.Create);
            LevelLocker newlock = new LevelLocker();
            newlock.CurrentLevel = 1;
            LevelData data = new LevelData(newlock);
            BF.Serialize(FS, data);
            FS.Close();
            return data;
        }
        
    }
   
}
