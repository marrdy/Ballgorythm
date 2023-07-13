using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;

public class AchievementsLoader : MonoBehaviour
{
    public GameObject AchievementTabList;
    public achiveclass[] adder;
   
    private void Start()
    {


        try
        {
            LoadAchievements();
            Debug.Log("loaded");
        }
        catch 
        {
           
        }
       
            SetUpData();
        Debug.Log("setted up");


    }
    public void SetUpData()
    {
        try
        {
            foreach (achiveclass varia in adder)
            {
                int i = 0;
                GameObject tab = Instantiate(AchievementTabList, transform.parent);
                tab.transform.SetParent(this.transform);
                tab.GetComponent<AchievementTabs>().Title.text = varia.AchivementName;
                tab.GetComponent<AchievementTabs>().Description.text = varia.AchivementDescription;
                tab.GetComponent<AchievementTabs>().AchievedCheck.isOn = varia.Achived;
                i++;
            }
        }
        
        catch
        {

        }



    }
    public void ResetProgress()
    {
        foreach(achiveclass i in adder)
        {
            Debug.Log("LOADED ACHIEVEMENT:"+i.AchivementName);
            i.Achived = false;
        }
        DataSaver.AchivementDataSave(this);
        Debug.Log("New data save created...");
    }
    public void LoadAchievements()
    {
       AchievementAdder LoadedData=  DataSaver.LoadAchievements(adder);
      
        if (LoadedData.achivecache.Length != 0 && LoadedData !=null)
        {
            adder = LoadedData.achivecache;
            Debug.Log(LoadedData.achivecache.Length);
        }
        else
        {
            ResetProgress();
            Debug.Log("No file found, new fresh file has been generated...");
            LoadAchievements();
        }
      
    }
        
    
}
