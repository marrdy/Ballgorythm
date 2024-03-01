using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class DataSaver
{  
    static string  PathForLevel = Application.persistentDataPath + "Progress.Lvlpg";
    static string  PathForAchivement = Application.persistentDataPath + "AchievementData.Lvlpg";
    static string  PathForAgreement = Application.persistentDataPath + "agreement.Lvlpg";
    static string  PathForSettings = Application.persistentDataPath + "settings.Lvlpg";
    #region Stars earned and last level player left
    public static LevelData loadLevel(int[] levels)
    {
        if (File.Exists(PathForLevel))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream FS = new FileStream(PathForLevel, FileMode.Open);
            LevelData data = formatter.Deserialize(FS) as LevelData;
            FS.Close();
            return data;
        }
        else
        {
            LevelData data = new LevelData();
            data.stars = levels;
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream FS = new FileStream(PathForLevel, FileMode.Create);
            formatter.Serialize(FS, data);
            FS.Close();
            return data;
        }
    }

    

    public static void SaveLevel(LevelData data)
    {
        Debug.Log("saving");
        BinaryFormatter formater = new BinaryFormatter();
        FileStream FS = new FileStream(PathForLevel, FileMode.Open);
        formater.Serialize(FS, data);
        FS.Close();
    }
    public static int GetCurrentLevel(LevelData def)
    {
        if (File.Exists(PathForLevel))
        {
            LevelData data = new();
            BinaryFormatter formater = new BinaryFormatter();
            FileStream FS = new FileStream(PathForLevel, FileMode.Open);
            data = formater.Deserialize(FS) as LevelData;
            Debug.Log("old game:" + PathForLevel);
            Debug.Log("Current Level:" + data.currentlvl);
            FS.Close();
            return data.currentlvl;
        }
        else
        {
            LevelData data = new();
            BinaryFormatter formater = new BinaryFormatter();
            FileStream FS = new FileStream(PathForLevel, FileMode.Create);
            Debug.Log("new game" + PathForLevel);
            data.currentlvl = 1;
            formater.Serialize(FS, def);

            FS.Close();
            return data.currentlvl;
        }

    }
    #endregion

    #region Save quizes and Players achievements

    public static AchivementDatas loadAchivementDatas(AchivementDatas data) 
    {
        if (File.Exists(PathForAchivement))
        {
            
            BinaryFormatter formater = new BinaryFormatter();
            FileStream FS = new FileStream(PathForAchivement, FileMode.Open);
            data = formater.Deserialize(FS) as AchivementDatas;
            
            FS.Close();
            return data;
        }
        else
        {
            
            BinaryFormatter formater = new BinaryFormatter();
            FileStream FS = new FileStream(PathForAchivement, FileMode.Create);
            
            formater.Serialize(FS, data);

            FS.Close();
            return data;
        }
        
    }

    public static void SavingAchievement(AchivementDatas data)
    {
        BinaryFormatter formater = new BinaryFormatter();
        FileStream FS = new FileStream(PathForAchivement, FileMode.Create);
        formater.Serialize(FS, data);
    }
    #endregion
    #region Save the set of settings
    public static volumeSettings GetVolSetValue(volumeSettings data) 
    {
        if (File.Exists(PathForSettings))
        {

            BinaryFormatter formater = new BinaryFormatter();
            FileStream FS = new FileStream(PathForSettings, FileMode.Open);
            data = formater.Deserialize(FS) as volumeSettings;

            FS.Close();
            return data;
        }
        else
        {

            BinaryFormatter formater = new BinaryFormatter();
            FileStream FS = new FileStream(PathForSettings, FileMode.Create);
            formater.Serialize(FS, data);
            FS.Close();
            return data;
        }
       
    }
    public static int GetSetFont()
    {
        if (File.Exists(PathForSettings)) 
        {
            BinaryFormatter formater = new BinaryFormatter();
            volumeSettings data;
            FileStream FS = new FileStream(PathForSettings, FileMode.Open);
            data = formater.Deserialize(FS) as volumeSettings;
            FS.Close();
            return data.selectedFont;
        }
        else 
        {
            return 0;
        }
       
        
    }
    public static void SaveVolSetValue(volumeSettings data) 
    {

        BinaryFormatter formater = new BinaryFormatter();
        FileStream FS = new FileStream(PathForSettings, FileMode.Create);
        formater.Serialize(FS, data);
        FS.Close();
    }
    #endregion
    public static void agreetoconsent(bool data)
    {
        
        BinaryFormatter formater = new BinaryFormatter();
        FileStream FS = new FileStream(PathForAgreement, FileMode.Create);
        formater.Serialize(FS, data);
        FS.Close();
    }
    public static bool loadAgreement() 
    {
        if (File.Exists(PathForAgreement))
        {

            bool data = false;
            BinaryFormatter formater = new BinaryFormatter();
            FileStream FS = new FileStream(PathForAgreement, FileMode.Open);
            data = (bool)formater.Deserialize(FS);

            FS.Close();
            return data;
        }
        else
        {

            bool data =false;
            BinaryFormatter formater = new BinaryFormatter();
            FileStream FS = new FileStream(PathForAgreement, FileMode.Create);
            formater.Serialize(FS, data);
            FS.Close();
            return data;
        }

    }
    public static bool resetprogress()
    {
     
        bool closeapp = false;
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
        if (File.Exists(PathForAgreement))
        {
            File.Delete(PathForAgreement);
            Debug.Log("Achievement file deleted.");
            closeapp = true;
        }
        if (File.Exists(PathForSettings))
        {
            File.Delete(PathForSettings);
            Debug.Log("Achievement file deleted.");
            closeapp = true;
        }
        return closeapp;
    }
}
