using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelNumberComplete : MonoBehaviour
{

    public TMP_Text TextComplete;
  
    void Start()
    {
        int scenenumb = SceneManager.GetActiveScene().buildIndex;
        TextComplete.text = "Level - " + scenenumb;
    }   
}
