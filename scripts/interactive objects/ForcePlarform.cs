
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Cinemachine;
using System.Collections;

public class ForcePlarform : MonoBehaviour
{


    float ExecutionDeley = 0;
    public GameObject Panel;
    public CinemachineFreeLook SecondCam;
    public Button ShowPannel;
    public TMP_Text SliderValue;
    public Slider DelaySlider;
    public TMP_Text delayValue;
    public Animator animator;
    public Transform TransformForcePlat;
    public Rigidbody bump;
    public Vector3 force = new Vector3(1000,0,0);
    public Rigidbody player;
    bool collided = false;
    public GameObject hidePlats;
    public SceneProj sp;
    public PlayerMovement PMVM;
    public CutScene cutScene;
    public Canvas mainhud;
    public void Clicked3d()
    {

        Panel.SetActive(true);
        SecondCam.LookAt = TransformForcePlat;
        SecondCam.Follow = TransformForcePlat;
        animator.Play("ViewOtherEnt");
        mainhud.gameObject.SetActive(false);
        hidePlats.GetComponent<UImanager>().ActivateControl(false);
    }
    public void setDelay()
    {
        ExecutionDeley = DelaySlider.value;
        Panel.SetActive(false);
        animator.Play("PlayerCam");
        delayValue.text = ExecutionDeley.ToString("0.0");
         mainhud.gameObject.SetActive(true);
        hidePlats.GetComponent<UImanager>().ActivateControl(true);
    }
    public void SliderChangeText()
    {
       
        SliderValue.text = DelaySlider.value.ToString("0.0");
    }


    IEnumerator ExeDel()
    {
      
        Debug.Log("hit");
        yield return new WaitForSeconds(3);
       
        yield return null;
    }


    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
            player = other.GetComponent<Rigidbody>();
            collided = true;
        player.AddForce(force * 2);

    }
    private void Start()
    {
        delayValue.text = ExecutionDeley.ToString("0.0");
    }


   
   
}
