using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOnClick : MonoBehaviour
{


    tutorialSpawn tutorialSpawn;


    private void Start()
    {
        tutorialSpawn = GameObject.FindGameObjectWithTag("Spawner").GetComponent<tutorialSpawn>();
    }

    // when a player taps a circle, play the sound and destroy the circle, then spawn the next circle
    private void OnMouseDown()
    {
        SoundManager.PlaySound(tutorialSpawn.counter);

        Destroy(gameObject);

        tutorialSpawn.tutorialSpawnObjects();

 


    }
}
