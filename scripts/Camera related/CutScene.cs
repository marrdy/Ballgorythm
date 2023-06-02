using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class CutScene : MonoBehaviour
{
    
    public float SecondsBeforeCutscene = 2;
    float seconds = 0;
    bool cutscenedone = false;
    bool showFirstDialog = false;
    public GameObject MainHud;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   
        
    
    // Update is called once per frame
    void Update()
    {
        if (seconds >= SecondsBeforeCutscene && !cutscenedone)
        {
            FindObjectOfType<CinemaCamScript>().toggleview(true);
            cutscenedone = true;
            showFirstDialog = true;




        }
        else
        {
            seconds = seconds + (1 * Time.deltaTime);

        }
        if (seconds >= SecondsBeforeCutscene + 2 && showFirstDialog)
        {
            MainHud.SetActive(true);
            if (FindObjectOfType<TutorialPannels>().name != null)
            {
                FindObjectOfType<TutorialPannels>().NextButtonPressed(0);
            }
           
            showFirstDialog = false ;
        }
    }
}
