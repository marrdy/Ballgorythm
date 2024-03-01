using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;

public class AchievementsLoader : MonoBehaviour
{
    public GameObject AchievementTabList;
    public AchivementDatas achivements;
    public AchivementDatasHolder AchivementLIstHolder;
    private void Start()
    {

        achivements.achivementInfo = AchivementLIstHolder.data.achivementInfo;


            LoadAchievements();
            Debug.Log("loaded");
       
       
       
            SetUpData();
        Debug.Log("setted up");


    }
    public void SetUpData()
    {
        
            foreach (achiveclass varia in achivements.achivementInfo)
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
  
    public void LoadAchievements()
    {

        achivements = DataSaver.loadAchivementDatas(achivements);
    }


}
