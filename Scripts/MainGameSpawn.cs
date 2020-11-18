using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameSpawn : MonoBehaviour
{


    public int maxSpawn;
    public List<GameObject> spawnPool;
    public GameObject quad;

    public bool spawnAllowed = false;

    AnimationSpeed animationSpeed;
    DifficultyTimer difficultyTimer;

    private void Awake()
    {
        animationSpeed = GameObject.FindGameObjectWithTag("Anim").GetComponent<AnimationSpeed>();
        difficultyTimer = GameObject.FindGameObjectWithTag("Timer").GetComponent<DifficultyTimer>();

        //load difficulty level from PlayerPrefs
        float DifficultyLevel = PlayerPrefs.GetFloat("Difficulty Level");

        Debug.Log("MainGameSpawn GetDifficultyLevel" + DifficultyLevel);

        animationSpeed.animSpeed = DifficultyLevel;
        Debug.Log("animation speed is " + animationSpeed.animSpeed);

    }

    //circles can spawn when start is pushed
    public void StartButton()
    {
        spawnAllowed = true;
       
        Debug.Log(spawnAllowed);
    }

    public void Update()
    {
        //when the difficulty counter starts, the timer starts to count up
        if (difficultyTimer.difficultyCounter > 0){
            difficultyTimer.startTimer = true;
        }
    }


    //spawn a random circle, selected from a predetermined pool of items, within the boundaries
    //of a quad
    public void MainSpawn() { 

        int randomCircle = 0;
        GameObject toSpawn;
        MeshCollider c = quad.GetComponent<MeshCollider>();

        float screenX, screenY;
        Vector2 pos;

        // each time a circle spawns, count up
        difficultyTimer.difficultyCounter += 1;
        Debug.Log(difficultyTimer.difficultyCounter);


            for (int i = 0; i<maxSpawn; i++)
            {
                randomCircle = Random.Range(0, spawnPool.Count);
                toSpawn = spawnPool[randomCircle];

                screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
                screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
                pos = new Vector2(screenX, screenY);
                Instantiate(toSpawn, pos, toSpawn.transform.rotation);
                

            }


    }
        

}
