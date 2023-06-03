using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Goalscript : MonoBehaviour
{
    float delay = 0;
    public GameObject finnalpannel;
    public Collider player;
    public Rigidbody RBplayer;
    public LevelIncrementor LevelUpEvent;
    bool showpan;
    bool stoped = false;
    bool done = false;
    PlayerMovement pp;
    private void OnTriggerEnter(Collider other)
    {
        if (!stoped)
        {
            RBplayer.isKinematic = true;
            stoped = true;
        }
        player.isTrigger = true;
        RBplayer.isKinematic = false;
        showpan = true;
        LevelUpEvent.levelUp();
        FindAnyObjectByType<CutScene>().MainHud.SetActive(false);
        if (FindObjectOfType<CinemaCamScript>())
        {
            FindObjectOfType<CinemaCamScript>().toggleview(false);
        }

      
    }
    private void Update()
    {
     
        if (showpan)
        {
            delay = delay + (1 * Time.deltaTime);
        }
        if(delay>=2&&!done)
        {
            finnalpannel.SetActive(true);
            done = true;
        }
      
    }



}
