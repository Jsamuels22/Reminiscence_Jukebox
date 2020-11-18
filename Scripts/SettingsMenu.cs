using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;
    public Slider volume;


    private void Start()
    {
        volume.value = PlayerPrefs.GetFloat("MasterVolume");
    }


    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);

        PlayerPrefs.SetFloat("MasterVolume", volume);
    }

}
