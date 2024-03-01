using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class DialogContentClass : MonoBehaviour
{
    public dialogclass dclass;
    public bool FollowObject;
    public GameObject PointAt;
    public voiceline s;
    SMScript sms;

    private bool wasPointAtActive = false; // Flag to track the previous state
    private void Start()
    {
       
           
        
    }
    private void Awake()
    {
        bool stop = false;
        int count = 0;
        while (sms == null && !stop)
        {

            sms = FindAnyObjectByType<SMScript>();
            count++;
            stop = count >= 1000;
        }
        
        s.volume = sms.vs.vlvolume;
        s.source = this.gameObject.AddComponent<AudioSource>();
        s.source.clip = s.clip;
        s.source.volume = s.volume;
        s.source.clip = s.clip;
        s.source.loop = s.loop;
        
    }
    private void OnEnable()
    {
        if (wasPointAtActive) 
        {
            s.source.Play();
        }
        else if (!FollowObject) 
        {
            s.source.Play();
        }
       
    }
    void Update()
    {
        if (FollowObject)
        {
            bool isPointAtActive = PointAt != null && PointAt.activeInHierarchy;

            if (isPointAtActive && !wasPointAtActive)
            {
                // PointAt went from inactive to active
                // Call your method here
                YourMethodToExecuteOnce();
            }

            if (isPointAtActive)
            {
                transform.position = PointAt.transform.position;
            }
            else
            {
                Vector3 offScreenPos = new Vector3(-10000f, -10000f, 0f);
                transform.position = offScreenPos;
            }

            // Update the flag for the next frame
            wasPointAtActive = isPointAtActive;
        }
    }

    // Define the method you want to execute once
    private void YourMethodToExecuteOnce()
    {
        s.source.Play();
    }
}

[System.Serializable]
public class dialogclass
{
    public TMP_Text dialogtext;
    public GameObject DialogLocalTrigger;
}

[System.Serializable]
public class voiceline
{
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;
    [HideInInspector]
    public AudioSource source;
    public bool loop;
}
