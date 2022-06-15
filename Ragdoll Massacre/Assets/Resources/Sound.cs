using System;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{ 
        public AudioClip clip;
        public String name;
        [Range(0f,1f)]
        public float volume;
        [Range(0f, 3f)]
        public float pitch;
        [HideInInspector]
        public AudioSource source;
        public bool loop;
}
