using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class SCScript : MonoBehaviour
{

    public Animator animator;
    public Animator animateballNcam;
    private int SceneNumber;
    public Rigidbody ballpush;
    public CinemaCamScript CMS;
    public Canvas mainhud;
    public LevelData data;
    public bool playing;

    private void Start()
    {
        
    }
    public void FadeToNextScene(int scn)
    {

        SceneNumber = scn;
        animator.SetTrigger("FadeOut");
    }

    public void FreePlay()
    {

        SceneNumber = SceneManager.sceneCountInBuildSettings - 6;

        animator.SetTrigger("FadeOut");
    }
    public void aboutus()
    {
        
        SceneNumber = SceneManager.sceneCountInBuildSettings-5;
     
        animator.SetTrigger("FadeOut");
    }
    public void manual()
    {
        
        SceneNumber = SceneManager.sceneCountInBuildSettings-4;
     
        animator.SetTrigger("FadeOut");
    }
   
public void Settings()
    {

        SceneNumber = SceneManager.sceneCountInBuildSettings - 3;
        animator.SetTrigger("FadeOut");
    }
 public void achievement()
    {

        SceneNumber = SceneManager.sceneCountInBuildSettings - 2;
        animator.SetTrigger("FadeOut");
    }

    public void levelselection()
    {
        
        SceneNumber = SceneManager.sceneCountInBuildSettings-1;
     
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
       
        SceneNumber = SceneManager.GetActiveScene().buildIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        
        SceneManager.LoadScene(SceneNumber);
    }

    public void continuelevel()
    {
        try{animateballNcam.Play("ballOut");} catch{}

        SceneNumber = DataSaver.GetCurrentLevel(data);
        animator.SetTrigger("FadeOut");
    }


    public void startTheGame()
    {
        if(playing)    StartCoroutine(ShowHud());
    }
    IEnumerator ShowHud()
    {
        
        CMS.toggleview(true);
        yield return new WaitForSeconds(2);
        mainhud.gameObject.SetActive(true);
    }
    public void quit()
    {
        Application.Quit();
    }
}
