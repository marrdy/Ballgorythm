using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using Cinemachine;
using TMPro;
public class SMScript : MonoBehaviour
{

    public volumeSettings vs;
    public Sounds[] SoundTracks;
    public static SMScript instance;





    void Awake()
    {
      
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        
        foreach (Sounds s in SoundTracks)
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

        CinemachineFreeLook[] CTIM = FindObjectsOfType<CinemachineFreeLook>();
        foreach (CinemachineFreeLook item in CTIM)
        {
            item.m_XAxis.m_MaxSpeed = vs.SensitivityX;
            item.m_YAxis.m_MaxSpeed = vs.SensitivityY;
        }

    }
    void Start()
    {
        loadSettings();
        playtrack("Theme");
    }
    public void playtrack(string name)
    {
        Sounds s = Array.Find(SoundTracks, Sounds => Sounds.name == name);
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
        vs.musicVolume = v;
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
        
        vs.sfxVolume = v;
    }
    public void saveSettings(volumeSettings vset) 
    {
        vs = vset;
        DataSaver.SaveVolSetValue(vs);
    }
    public void loadSettings()
    {
        vs =DataSaver.GetVolSetValue(vs);
        MusicVolume(vs.musicVolume);
        SFXVolume(vs.sfxVolume);
    }

}
[System.Serializable]
public class volumeSettings 
{
    [Range(0f, 1f)]
    public float musicVolume = 1;
    [Range(0f, 1f)]
    public float sfxVolume = 1;
    [Range(0f, 1f)]
    public float vlvolume = 1;
    public float SensitivityX = 10;
    public float SensitivityY = 1;
    public int selectedFont;
    //public TMP_FontAsset[] Font;
}
