using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnClickMain : MonoBehaviour
{

    MainGameSpawn mainGameSpawn;



    private void Start()
    {
        mainGameSpawn = GameObject.FindGameObjectWithTag("Spawner").GetComponent<MainGameSpawn>();
    }

    //When a player taps a circle, destroy the circle, then allow a new circle to be spawned
    private void OnMouseDown()
    {
    
        Destroy(gameObject);
        mainGameSpawn.spawnAllowed = true;

        Debug.Log(mainGameSpawn.spawnAllowed);


    }
}
