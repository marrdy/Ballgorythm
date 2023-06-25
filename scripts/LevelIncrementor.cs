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
        
    }
    public void levelUp()
    {
      
        if (CurrentLevel <= SceneManager.GetActiveScene().buildIndex)
        {
            CurrentLevel++;
            
            LevelLocker save = new LevelLocker();
            save.CurrentLevel = CurrentLevel;
            DataSaver.ProgressData(save);
        }
    }
}
