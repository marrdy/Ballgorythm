using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class LevelLocker : MonoBehaviour
{
    public SCScript GoToLevel;
    public LevelData lvldata;
    public LevelStat lockLevels;
    public TMP_Text CurrentLevelLabel;
    private StarManager starManager; // Reference to the StarManager script

    void Start()
    {
       starManager = FindObjectOfType<StarManager>(); // Find the StarManager script in the scene
       lvldata = DataSaver.loadLevel(lvldata.stars);
        CurrentLevelLabel.text = "Current Level : " + lvldata.currentlvl;
        for (int i = 0; i < lvldata.currentlvl; i++)
        {
            int levelIndex = i+1;
            GameObject lvlbutton = Instantiate(lockLevels.gameObject);
            lvlbutton.transform.SetParent(transform);
            lvlbutton.transform.localScale = new Vector3(1,1,1);
            lvlbutton.GetComponent<Button>().onClick.AddListener(delegate { GoToLevel.FadeToNextScene(levelIndex); });
            lvlbutton.GetComponent<LevelStat>().LevelNumText.text = levelIndex.ToString();
            lvlbutton.GetComponent<LevelStat>().LockOrCheck.gameObject.SetActive(!(i+1 == lvldata.currentlvl));
            switch (lvldata.stars[i]) 
            {
                case 0:
                    lvlbutton.GetComponent<LevelStat>().Star1.gameObject.SetActive(false);
                    lvlbutton.GetComponent<LevelStat>().Star2.gameObject.SetActive(false);
                    lvlbutton.GetComponent<LevelStat>().Star3.gameObject.SetActive(false);
                    break;
                case 1:
                    lvlbutton.GetComponent<LevelStat>().Star1.gameObject.SetActive(false);
                    lvlbutton.GetComponent<LevelStat>().Star2.gameObject.SetActive(true);
                    lvlbutton.GetComponent<LevelStat>().Star3.gameObject.SetActive(false);
                    break;
                case 2:
                    lvlbutton.GetComponent<LevelStat>().Star1.gameObject.SetActive(true);
                    lvlbutton.GetComponent<LevelStat>().Star2.gameObject.SetActive(false);
                    lvlbutton.GetComponent<LevelStat>().Star3.gameObject.SetActive(true);
                    break;
                case 3:
                    lvlbutton.GetComponent<LevelStat>().Star1.gameObject.SetActive(true);
                    lvlbutton.GetComponent<LevelStat>().Star2.gameObject.SetActive(true);
                    lvlbutton.GetComponent<LevelStat>().Star3.gameObject.SetActive(true);
                    break;
            }
            
        }
       // CurrentLevelLabel.text = "Current level = " + (lvldata.CurrentLevel +1).ToString();
        loadLevelButtons();
      
    }

    public void loadLevelButtons()
    {
        
    }

   
}
