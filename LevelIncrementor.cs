using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelIncrementor : MonoBehaviour
{

    int CurrentLevel;

    private void Start()
    {
        LevelData data = DataSaver.loadlocklevel();
        CurrentLevel = data.CurrentLevel;
        Debug.Log("current level =" + CurrentLevel);
        Debug.Log("index level =" + SceneManager.GetActiveScene().buildIndex);
    }
    public void levelUp()
    {
      
        if (CurrentLevel <= SceneManager.GetActiveScene().buildIndex)
        {
            CurrentLevel++;
            Debug.Log("level up = "+CurrentLevel);
            LevelLocker save = new LevelLocker();
            save.CurrentLevel = CurrentLevel;
            DataSaver.ProgressData(save);
        }
    }
}
