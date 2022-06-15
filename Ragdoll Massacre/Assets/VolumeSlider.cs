using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            load();
        }
        else
        {
            load();
        }
    }

    // Update is called once per frame
    public void changeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        save();
    }

    public void load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    public void save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
