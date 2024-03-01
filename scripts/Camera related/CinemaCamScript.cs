
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class CinemaCamScript : MonoBehaviour
{
    public Animator animator;
    public Button ChangeViewButton;
    public CinemachineFreeLook goal;
    public CinemachineFreeLook player;
    public Canvas mainhud;
    public bool FreeCamModeOn;
    public GameObject ForcePanel;
    public GameObject joystickk;
    private bool toggleLookGoal = false;
    bool showPanel =true;
    public void toggleview(bool toggleOnPlayer)
    {
;        if (toggleOnPlayer)
        {
           
            animator.Play("PlayerCam");
        }
        else
        {
           
            animator.Play("GoalCam");  
        }
    }
    public void toggleButton()
    {
        toggleview(toggleLookGoal);
        toggleLookGoal = !toggleLookGoal;
    }
    public void toggleFreeCam()
    {
        if (FreeCamModeOn)
        {
           
            animator.Play("PlayerCam");
            joystickk.gameObject.SetActive(false);
            ForcePanel.SetActive(true);
        }
        else
        {
            animator.Play("FreeCamMode");
            joystickk.gameObject.SetActive(true);
            ForcePanel.SetActive(false);

        }
        FreeCamModeOn = !FreeCamModeOn;
    }
    public void toggleForcePanel()
    {
        if (showPanel)
        {

           ForcePanel.SetActive(true);
            joystickk.SetActive(false);
        }
        else
        {
            ForcePanel.SetActive(false);
            joystickk.SetActive(true);
        }
        FreeCamModeOn = !FreeCamModeOn;
    }
}
