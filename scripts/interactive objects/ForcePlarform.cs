
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
    public void Clicked3d()
    {

        Panel.SetActive(true);
        SecondCam.LookAt = TransformForcePlat;
        SecondCam.Follow = TransformForcePlat;
        animator.Play("ViewOtherEnt");
        FindAnyObjectByType<CutScene>().MainHud.SetActive(false);
        hidePlats.GetComponent<UImanager>().ActivateControl(false);
    }
    public void setDelay()
    {
        ExecutionDeley = DelaySlider.value;
        Panel.SetActive(false);
        animator.Play("PlayerCam");
        delayValue.text = ExecutionDeley.ToString("0.0");
        FindAnyObjectByType<CutScene>().MainHud.SetActive(true);
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
        //player.AddForce(force * 2);
        yield return null;
    }


    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
            player = other.GetComponent<Rigidbody>();
            collided = true;
         //  StartCoroutine(ExeDel());
        player.AddForce(force * 2);

    }
    private void Start()
    {
        delayValue.text = ExecutionDeley.ToString("0.0");
    }


   
    void Update()
    {

       
        //Debug.Log(this.name +" = "+ collided);
        //if (collided)
        //{ 
        //if (timer >= ExecutionDeley) { 
           
        //    player.isKinematic = true;
        //    player.isKinematic = false;
        //    player.AddForce(force * 2);
        //    collided = false;
        //}
        //else
        //{
        //    timer = timer + (1 * Time.deltaTime);

        //}
        //}
      
        
       

    }
}
