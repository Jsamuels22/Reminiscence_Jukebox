using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialSpawn : MonoBehaviour
{

    public int maxSpawn;
    public List<GameObject> spawnPool;
    public GameObject quad;

    DifficultyTimer difficultyTimer;
    public int counter = 0;

    public void Start()
    {
        difficultyTimer = GameObject.FindGameObjectWithTag("Timer").GetComponent<DifficultyTimer>();
    }

    
    //as a circle in the tutorial is spawned, count up
    public void tutorialSpawnObjects()
    {
        counter += 1;

        Debug.Log(counter);

        //if it is not the last circle
        if (counter != 9)
        {

            //spawn a random circle, selected from a predetermined pool of items, within the boundaries
            //of a quad
            int randomCircle = 0;
            GameObject toSpawn;
            MeshCollider c = quad.GetComponent<MeshCollider>();

            float screenX, screenY;
            Vector2 pos;

            for (int i = 0; i < maxSpawn; i++)
            {
                randomCircle = Random.Range(0, spawnPool.Count);
                toSpawn = spawnPool[randomCircle];

                screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
                screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
                pos = new Vector2(screenX, screenY);
                GameObject newCircle = (GameObject)Instantiate(toSpawn, pos, toSpawn.transform.rotation);
                
            }
        }
        else
        {
            //if it is the last circle, stop the timer, and test a players difficulty using the timer
            difficultyTimer.startTimer = false;
            Debug.Log("stopTimer");
            Debug.Log(difficultyTimer.startTimer);
            difficultyTimer.TestDifficulty();
            Debug.Log("TestDifficulty");

            //destroy the spawner when the tutorial ends to stop any more circles spawning
            GameObject.Destroy(this);

        }
     

    }
}







