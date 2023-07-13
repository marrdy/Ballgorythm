using System;
using UnityEngine;
using UnityEngine.Audio;

public class SMScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Sounds[] SoundTracks;
   public static SMScript instance;
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
    void Start()
    {
        playtrack("Theme");
    }
    public void playtrack(string name)
    {
        Sounds s = Array.Find(SoundTracks,Sounds =>Sounds.name == name);
        s.source.Play();
    }
}
