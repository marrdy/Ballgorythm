using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
using playerscript;
public class Goalscript : MonoBehaviour
{
    public Animator animator;
    public GameObject finnalpannel;
    public Collider player;
    public Rigidbody RBplayer;
    public LevelIncrementor LevelUpEvent;
    public int CurrentLevel;
    public bool quizdone = false;
    public bool Intime = true;
    bool stoped = false;
    public timerPush tp;
    public Canvas mainhud;
    public Canvas blackcanvas;
    public CinemaCamScript ccs;
    public int starsEarned = 1;
    public Canvas compasshud;
    
    private bool endPanelShown = false;
    public Image star2;
    public Image star3;
    public LevelData lvldata;
    private void Start()
    {
        CurrentLevel = SceneManager.GetActiveScene().buildIndex;
        lvldata = DataSaver.loadLevel(lvldata.stars);
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger("Flagdown");
        if (!stoped)
        {
            RBplayer.isKinematic = true;
            stoped = true;
        }
    

        player.isTrigger = true;
        RBplayer.isKinematic = false;
        if (!player.GetComponent<PlayerMovement>().freePlayMode)
        {
            tp.finishtime();
            LevelUpEvent.levelUp();
            mainhud.gameObject.SetActive(false);
        }
     
        if (!endPanelShown)
        {
            StartCoroutine("ShowEndPannel");
        }
        FindAnyObjectByType<SMScript>().playtrack("goal");
    }

    IEnumerator ShowEndPannel()
    {
        endPanelShown = true; // Set the flag to indicate that the end panel is being shown
        ccs.toggleview(false);
        yield return new WaitForSeconds(2);
        if (!player.GetComponent<PlayerMovement>().freePlayMode)
        {
            finnalpannel.SetActive(true);
            updatedata();
        }
        else 
        {
            stoped = false;
            player.isTrigger = false;
            ccs.toggleview(true);
            endPanelShown = false;
            player.transform.position = player.GetComponent<PlayerMovement>().startpos;
            player.GetComponent<PlayerMovement>().again();
        }

    }
    public void updatedata() 
    {
        lvldata.stars[SceneManager.GetActiveScene().buildIndex - 1]++;
        if (lvldata.currentlvl == SceneManager.GetActiveScene().buildIndex) 
        {
            lvldata.currentlvl++;
        }
        if (Intime) 
        {
            lvldata.stars[SceneManager.GetActiveScene().buildIndex - 1]++;
            star2.color = Color.yellow;
        }
        DataSaver.SaveLevel(lvldata);

    }
    public void closeendpan()
    {
        finnalpannel.SetActive(false);
    }
}