using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound[] sounds;

    void Awake()
    {
        Instance = this;
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            
            
        }
    }

    void Start()
    {
            PlaySound("Theme");
            PlaySound("rain");
    }

    public void PlaySound(String soundEffect)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundEffect);
        if (s == null)
            return;
        s.source.Play();
    }
}
