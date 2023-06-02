
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class CinemaCamScript : MonoBehaviour
{

   
    
    public Animator animator;
    public Button ChangeViewButton;
    public CinemachineFreeLook goal;
    public CinemachineFreeLook player;
    private bool toggleLookGoal = false;
  
    public void toggleview(bool toggleOnPlayer)
    {
;        if (toggleOnPlayer)
        {
           
            animator.Play("PlayerCam");
        }
        else
        {
            Debug.Log("untoggled");  
            animator.Play("GoalCam");  
        }
    }

    public void toggleButton()
    {
        toggleview(toggleLookGoal);
        toggleLookGoal = !toggleLookGoal;
    }

    // Update is called once per frame
    void Update()
    {

      
        
    }
}
