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
    public LevelData data;
    private bool endPanelShown = false;
    public Image star2;
    public Image star3;
    private void Start()
    {
        CurrentLevel = SceneManager.GetActiveScene().buildIndex;
        data = DataSaver.loadlocklevel();
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
        // Calculate stars earned based on conditions
        if (Intime)
        {
            starsEarned++;
            star2.color = Color.yellow;
        }

        
        if (data.CurrentLevel <= CurrentLevel - 1)
        {
            data.CurrentLevel++;
        }
        if (data.starsInlevels[CurrentLevel - 1] < starsEarned)
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