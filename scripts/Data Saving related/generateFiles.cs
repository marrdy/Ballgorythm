using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class generateFiles : MonoBehaviour
{
    public AchivementDatasHolder achievementsListHolder;
    public AchivementDatas ListOfAchivement;
    public LevelData levelprogressfiles;
    public GameObject agreementform;
     public TMP_Text cl;
    public LevelData data;
    private void Start()
    {
        ListOfAchivement.achivementInfo = achievementsListHolder.data.achivementInfo;
        data = DataSaver.loadLevel(data.stars);
        cl.text = "Current level : " + data.currentlvl.ToString();
        ListOfAchivement = DataSaver.loadAchivementDatas(ListOfAchivement);
       
    }
    public void showagreement() 
    {
        agreementform.SetActive(!DataSaver.loadAgreement());
    }
   
     

    public void acceptAgreement() 
    {
       DataSaver.agreetoconsent(true);
    }
}
