using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeChanger : MonoBehaviour
{
    public AudioMixer mixer;
    
    public Slider musicSlider;
    public Slider soundsSlider;

    private void Start()
    {
        mixer.SetFloat("MusicVol", PlayerPrefs.GetFloat("MusicVol"));
        musicSlider.value = (PlayerPrefs.GetFloat("MusicVol") + 40f) / 40f;
        
        mixer.SetFloat("SoundsVol", PlayerPrefs.GetFloat("SoundsVol"));
        soundsSlider.value = (PlayerPrefs.GetFloat("SoundsVol") + 40f) / 40f;

    }

    public void VolumeChangeMusic()
    {
        float volume = musicSlider.value;
        float res = 40f * volume -40f;
        if (res < -37f)
        {
            res = -80f;
        }
        
        PlayerPrefs.SetFloat("MusicVol", res);

        mixer.SetFloat("MusicVol", res);
    }
    
    public void VolumeChangeSounds()
    {
        float volume = soundsSlider.value;
        
        float res = 40f * volume -40f;
        if (res < -37f)
        {
            res = -80f;
        }
        
        PlayerPrefs.SetFloat("SoundsVol", res);

        mixer.SetFloat("SoundsVol", res);
    }
}
