using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBasedOnAudio : MonoBehaviour
{


    public float spawnThreshold;
    public int frequency = 330;
    public FFTWindow fftWindow;
    SettingsMenu settingsMenu;

    private float[] samples = new float[1024];

    MainGameSpawn mainGameSpawn;
   
    void Start()
    {
        mainGameSpawn = GameObject.FindGameObjectWithTag("Spawner").GetComponent<MainGameSpawn>();
        settingsMenu = GameObject.FindGameObjectWithTag("SettingsMenu").GetComponent<SettingsMenu>();

    }


    void Update()
    {

        //Adjustment of spawnThreshold with volume
        if (settingsMenu.volume.value < -60f)
        {
            spawnThreshold = 0.0000001f;
        }
        if (settingsMenu.volume.value < -40f && settingsMenu.volume.value >= -60f)
        {
            spawnThreshold = 0.000001f;
        }
        if (settingsMenu.volume.value < -20f && settingsMenu.volume.value >= -40f)
        {
            spawnThreshold = 0.00005f;
        }
        if (settingsMenu.volume.value >= -20f)
        {
            spawnThreshold = 0.0001f;
        }


        
        AudioListener.GetSpectrumData(samples, 0, fftWindow);

        //when a cirlce can be spawned, and the frequency is above the spawnThreshold, spawn a cirlce
        if (mainGameSpawn.spawnAllowed == true)
        {

            if (samples[frequency] > spawnThreshold)
            {
                mainGameSpawn.MainSpawn();

        //if a cirlce is already spawned, do not spawn more
                mainGameSpawn.spawnAllowed = false;
                Debug.Log(mainGameSpawn.spawnAllowed);
            }
        }
              
    }
}
