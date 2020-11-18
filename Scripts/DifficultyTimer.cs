using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyTimer : MonoBehaviour
{


    public enum Difficulties { easy, medium, hard };
    public static Difficulties Difficulty = Difficulties.medium;

    public float timeTaken = 0;
    public bool resetTimer = false;
    public bool startTimer = false;
    public int difficultyCounter = 0;


    AnimationSpeed animationSpeed;

    private void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Anim");
        if (go)
        {
            animationSpeed = GameObject.FindGameObjectWithTag("Anim").GetComponent<AnimationSpeed>();
        }
    }


    public void StartTimer(bool isOn)
    {
        if (isOn)
            startTimer = true;
        Debug.Log(startTimer);
     
    }


    void Update()
    {
        if (startTimer == true)
        {
            timeTaken += Time.deltaTime;
        }
    }

    public void ResumeTimer()
    {
        startTimer = true;
    }

    
    // at the end of the tutorual, the difficulty is tested by measuring the time taken, then one of three
    // difficulty levels are set
    public void TestDifficulty()
    {
        

        if (timeTaken < 35)
        {
            SetHardDifficulty(true); 
        

        }

        if (timeTaken > 35 && timeTaken < 55)
        {
            SetMediumDifficulty(true);


        }

        if (timeTaken > 55)
        {
            SetEasyDifficulty(true);

        }

        Debug.Log("DifficultyTested");

        // difficulty is saved in PlayerPrefs
        PlayerPrefs.SetInt("Difficulty Level", (int)Difficulty);

        Debug.Log("TutorialDifficultySet" + (int)Difficulty);

        int DifficultyLevel = PlayerPrefs.GetInt("Difficulty Level");

        // the animation speeds of each difficulty level are set below
        switch (DifficultyLevel)
        {
            case 0:
                animationSpeed.animSpeed = 0.5f;
                Debug.Log("Difficulty Level" + DifficultyLevel);
                Debug.Log("Easy");
                Debug.Log("animationSpeed" + animationSpeed.animSpeed);
                break;

            case 1:
                animationSpeed.animSpeed = 1f;
                Debug.Log("Difficulty Level" + DifficultyLevel);
                Debug.Log("Medium");
                Debug.Log("animationSpeed" + animationSpeed.animSpeed);
                break;

            case 2:
                animationSpeed.animSpeed = 1.5f;
                Debug.Log("Difficulty Level" + DifficultyLevel);
                Debug.Log("Hard");
                Debug.Log("animationSpeed" + animationSpeed.animSpeed);
                break;


        }

        PlayerPrefs.SetFloat("Difficulty Level", animationSpeed.animSpeed);

    }



    #region
    public void SetHardDifficulty(bool isOn)
    {
        if (isOn)
            Difficulty = Difficulties.hard;
    }
    public void SetMediumDifficulty(bool isOn)
    {
        if (isOn)
            Difficulty = Difficulties.medium;
    }
    public void SetEasyDifficulty(bool isOn)
    {
        if (isOn)
            Difficulty = Difficulties.easy;
    }
    #endregion

}


