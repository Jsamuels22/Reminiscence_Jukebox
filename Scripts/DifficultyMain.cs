using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyMain : MonoBehaviour
{

    DifficultyTimer difficultyTimer;
    AnimationSpeed animationSpeed;



    void Start()
    {
        difficultyTimer = GameObject.FindGameObjectWithTag("Timer").GetComponent<DifficultyTimer>();
        animationSpeed = GameObject.FindGameObjectWithTag("Anim").GetComponent<AnimationSpeed>();
    }

    public void Update()
    {
   
        // after 5 successful taps, adjust the difficulty
         if (difficultyTimer.difficultyCounter >= 5)
         {
            //Debug.Log(resetTimer);
            AdjustDifficulty();
            difficultyTimer.timeTaken = 0;
            difficultyTimer.difficultyCounter = 0;
         }

    }


    // if time taken is over 35 seconds and the animation speed is not already minimum, slow down
    // if time taken is less than 30 seconds and animationspeed is not already maximum, speed up
    public void AdjustDifficulty()
    {

       if (difficultyTimer.timeTaken > 35 && animationSpeed.animSpeed > 0.5f)
        {
            animationSpeed.SlowDown();
            Debug.Log("slowDown, time taken" + difficultyTimer.timeTaken);
        }
     

        if (difficultyTimer.timeTaken <= 30 && animationSpeed.animSpeed < 2.5f)
        {
            animationSpeed.SpeedUp();
            Debug.Log("SpeedUp, time taken" + difficultyTimer.timeTaken);
        }



    }
}
