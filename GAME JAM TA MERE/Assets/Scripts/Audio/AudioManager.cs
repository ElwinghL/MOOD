using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] Sounds;
    public static AudioManager Instance;
    void Awake()
    {
        //Make the object last through scenes
        DontDestroyOnLoad(gameObject);

        //Make sure that there is only one instance at any given time
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
          Destroy(gameObject);
            return;
        }

        //Instantiatiate all Sounds declared in the inspector
        foreach (Sound s in Sounds)
        {
            s.Source = gameObject.AddComponent<AudioSource>();
            s.Source.clip = s.Clip;

            s.Source.volume = s.Volume;
            s.Source.pitch = s.Pitch;
            s.Source.loop = s.Loop;
        }
    }

    void Start()
    {
        Play("MainTheme");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(Sounds, sound => sound.Name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound not found" );
        }
        s.Source.Play();
    }

    public void Stop()
    {

        foreach (Sound s in Sounds)
        {
            s.Source.Stop();
        }
    }
}
