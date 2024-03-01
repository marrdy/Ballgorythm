using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using Cinemachine;
using TMPro;
public class SMScript : MonoBehaviour
{
    public float musicVolume = 1;
    public float sfxVolume = 1;
    public float vlvolume = 1;
    public Sounds[] SoundTracks;
    public float SensitivityX = 10;
    public float SensitivityY = 1;
    public static SMScript instance;
    public TMP_FontAsset[] Font;
    public int selectedFont;
    
   
    
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach(Sounds s in SoundTracks)
        {
            s.source = this.gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.clip = s.clip;
            s.source.loop = s.loop;
        }
        
    }

    void Update()
    {   
        
        CinemachineFreeLook [] CTIM= FindObjectsOfType<CinemachineFreeLook>();
            foreach (CinemachineFreeLook item in CTIM)
            {
                item.m_XAxis.m_MaxSpeed = SensitivityX;
                item.m_YAxis.m_MaxSpeed = SensitivityY;
        
                
            }
        
    }
    void Start()
    {
        playtrack("Theme");
    }
    public void playtrack(string name)
    {
        Sounds s = Array.Find(SoundTracks,Sounds =>Sounds.name == name);
        s.source.Play();
    }
  public void MusicVolume(float v)
{
  
    foreach (Sounds s in SoundTracks)
    {
      
        if (s.type == Sounds.SoundType.Music)
        {
            s.source.volume = v;
        }
    }
    musicVolume = v;
}

 public void SFXVolume(float v)
{
  
    foreach (Sounds s in SoundTracks)
    {
      
        if (s.type == Sounds.SoundType.SFX)
        {
            s.source.volume = v;
        }
    }
    playtrack("FPbell");
    sfxVolume = v;
}
    public void setFont() 
    {
    
    }
}
