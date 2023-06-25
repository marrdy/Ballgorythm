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
        catch
        {
            resetprog();
            Debug.Log("No file found, new fresh file has been generated...");
            loadlevels();
        }
       
            LockingTheLevels();
        
       

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
        try
        {
        CurrentLevelLabel.text = "Current level :"+CurrentLevel.ToString();
        }
        catch{

        }
       
       
    }
   


   

      


    
}
 