using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
using playerscript;
public class Goalscript : MonoBehaviour
{
    public Animator animator;
    float delay = 0;
    public GameObject finnalpannel;
    public Collider player;
    public Rigidbody RBplayer;
    public LevelIncrementor LevelUpEvent;
    public int CurrentLevel;
    public bool NoAimAssist = true;
    public bool Intime = true;
    bool showpan;
    bool stoped = false;
    bool done = false;
    PlayerMovement pp;
    public timerPush tp;
    public Canvas mainhud;
    public Canvas blackcanvas;
    public CinemaCamScript ccs;
    private StarManager starManager; // Reference to the StarManager script
    public int starsEarned = 1;
    public Canvas compasshud;
    LevelData data;
    private bool endPanelShown = false; // Flag to track if the end panel has been shown

    private void Start()
    {
        CurrentLevel = SceneManager.GetActiveScene().buildIndex;
        data = DataSaver.loadlocklevel();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!stoped)
        {
            animator.SetTrigger("Flagdown");
            RBplayer.isKinematic = true;
            stoped = true;
        }
        tp.finishtime();

        player.isTrigger = true;
        RBplayer.isKinematic = false;
        LevelUpEvent.levelUp();
        mainhud.gameObject.SetActive(false);
        compasshud.gameObject.SetActive(false);
          FindAnyObjectByType<SMScript>().playtrack("goal");
        if (!endPanelShown)
        {
            StartCoroutine("ShowEndPannel");
        }
    }

    IEnumerator ShowEndPannel()
    {
        endPanelShown = true; // Set the flag to indicate that the end panel is being shown
        ccs.toggleview(false);
        yield return new WaitForSeconds(2);
        finnalpannel.SetActive(true);
        
        // Calculate stars earned based on conditions
        if (NoAimAssist)
        {
            starsEarned++;
        }

        if (Intime)
        {
            starsEarned++;
        }

        Debug.Log("currentlevel " + CurrentLevel);
        Debug.Log("highest level  " + data.CurrentLevel);
        if(data.CurrentLevel <= CurrentLevel-1)
        {
            data.CurrentLevel++;
        }
        if(data.starsInlevels[CurrentLevel - 1] < starsEarned)
        {
            data.starsInlevels[CurrentLevel - 1] = starsEarned;
        }
        
        LevelLocker datatosave = new LevelLocker();
        datatosave.starsperlevel = data.starsInlevels;
        datatosave.CurrentLevel = data.CurrentLevel;
        DataSaver.ProgressData(datatosave);
    }

    public void closeendpan()
    {
        finnalpannel.SetActive(false);
    }
}
