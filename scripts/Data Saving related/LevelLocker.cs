using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class LevelLocker : MonoBehaviour
{
   public Button[] lockLevels;
    public int CurrentLevel;
    public TMP_Text CurrentLevelLabel;
   
    public void LockingTheLevels()
    {
        foreach(Button i in lockLevels)
        {
            i.interactable = false;
        }
        for (int i =0; i <= lockLevels.Length; i++)
        {

            
            if(i<CurrentLevel) {
                lockLevels[i].interactable = true;
            }
        }
    }
    private void Start()
    {
       
        try
        {
            loadlevels();
           
        }
        catch(Exception e)
        {
            resetprog();
            Debug.Log("No file found, new fresh file has been generated...");
            loadlevels();
        }
        try
        {
            LockingTheLevels();
        }
        catch
        {

        }

    }
    public void resetprog()
    {
        CurrentLevel = 1;
        DataSaver.ProgressData(this);
        loadlevels();
        LockingTheLevels();

    }
    public void save()
    {
        
        DataSaver.ProgressData(this);
        Debug.Log(CurrentLevel);

    }
    public void loadlevels()
    {
        LevelData data = DataSaver.loadlocklevel();
        CurrentLevel = data.CurrentLevel;
        CurrentLevelLabel.text = "Current level :"+CurrentLevel.ToString();
        Debug.Log(CurrentLevel);
    }
   


    public void levelUp()
    {
        LevelData data = DataSaver.loadlocklevel();
        CurrentLevel = data.CurrentLevel;
        if(CurrentLevel<= SceneManager.GetActiveScene().buildIndex)
        {
            CurrentLevel++;
            DataSaver.ProgressData(this);
        }
    }

      


    
}
 