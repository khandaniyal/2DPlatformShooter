using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip theme, playerHit, gunShot;
    static AudioSource aSource;
    void Start()
    {
        theme = Resources.Load<AudioClip>("Theme");
        playerHit = Resources.Load<AudioClip>("playerHit");
        gunShot = Resources.Load<AudioClip>("GunShot");

        aSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame

    void Awake()
    {
           
    }

    public static void playSound(String clip)
    {
        switch (clip)
        {
            case "GunShot":
                aSource.PlayOneShot(gunShot);
                break;
            case "playerHit":
                aSource.PlayOneShot(playerHit);
                break;
        }
    }
}
