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
    public int CurrentLevel;
    public LevelStat[] lockLevels;
    public int[] starsperlevel;
    public TMP_Text CurrentLevelLabel;
    private StarManager starManager; // Reference to the StarManager script

    void Start()
    {
        starManager = FindObjectOfType<StarManager>(); // Find the StarManager script in the scene
        LevelData load = DataSaver.loadlocklevel();
        CurrentLevel = load.CurrentLevel; 
        starsperlevel = load.starsInlevels;
        CurrentLevelLabel.text = "Current level = " + (CurrentLevel+1).ToString();
        loadLevelButtons();
      
    }

    public void loadLevelButtons()
    {
        for (int i = 0; i < lockLevels.Length; i++)
        {
            LevelStat Ilvlstat =  lockLevels[i];
            int levelIndex = i; // Create a local copy of i
            Ilvlstat.gameObject.AddComponent<Button>().onClick.AddListener(delegate { GoToLevel.FadeToNextScene(levelIndex + 1); });
            Ilvlstat.lc.levelnumber = i + 1;
            Ilvlstat.LevelNumText.text = Ilvlstat.lc.levelnumber.ToString();
            if (i <= CurrentLevel)
            {
                Ilvlstat.LockOrCheck.sprite = lockLevels[i].Complete;
                    if (i == CurrentLevel)
                 {
                Ilvlstat.LockOrCheck.gameObject.SetActive(false);
                 }
            }
           
            if (i > CurrentLevel)
            {
               Ilvlstat.gameObject.GetComponent<Button>().interactable = false;
               Ilvlstat.LockOrCheck.sprite = lockLevels[i].locker;
            
            }
            Ilvlstat.lc.amountStars = starsperlevel[i] ;
            Ilvlstat.starslighter(Ilvlstat.lc.amountStars);
        }
    }

   
}
