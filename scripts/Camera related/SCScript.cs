using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class SCScript : MonoBehaviour
{

    public Animator animator;
    private int SceneNumber;
    public TMP_Text cl;

    private void Start()
    {
        try
        {
            LevelData data = DataSaver.loadlocklevel();
            cl.text = data.CurrentLevel.ToString();
        }
        catch
        {

        }
       
    }

    public void FadeToNextScene(int scn)
    {

        SceneNumber = scn;
        animator.SetTrigger("FadeOut");
    }

    public void levelselection()
    {
        
        SceneNumber = SceneManager.sceneCountInBuildSettings-1;
        Debug.Log(SceneNumber);
        animator.SetTrigger("FadeOut");
    }
    public void achievement()
    {

        SceneNumber = SceneManager.sceneCountInBuildSettings - 2;
        Debug.Log(SceneNumber);
        animator.SetTrigger("FadeOut");
    }

    public void FadeToNextLevel()
    {
        SceneNumber = SceneManager.GetActiveScene().buildIndex+1;
        animator.SetTrigger("FadeOut");
    }

    public void FadeToHome()
    {
        SceneNumber =0;
        animator.SetTrigger("FadeOut");
    }
    public void FadeResetLevel()
    {
        Debug.Log("scene-"+ SceneManager.GetActiveScene().buildIndex);
        SceneNumber = SceneManager.GetActiveScene().buildIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        Debug.Log("scene-" + SceneNumber);
        SceneManager.LoadScene(SceneNumber);
    }

    public void continuelevel()
    {
        LevelData data = DataSaver.loadlocklevel();
        SceneNumber = data.CurrentLevel;
        if (SceneNumber == 0)
        {
            SceneNumber = 1;
        }
      
        animator.SetTrigger("FadeOut");
    }
}
