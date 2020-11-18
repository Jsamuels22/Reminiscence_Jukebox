using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;
 
    public bool settingsOn = false;
    DifficultyTimer difficultyTimer;
    PlayAudio playAudio;
    PauseUI pauseUI;

    private void Start()
    {
        GameObject go_c = GameObject.FindGameObjectWithTag("Timer");
        if (go_c)
        {
            difficultyTimer = GameObject.FindGameObjectWithTag("Timer").GetComponent<DifficultyTimer>();
        }
    

        GameObject go_d = GameObject.FindGameObjectWithTag("SongSelection");
        if (go_d)
        {
            playAudio = GameObject.FindGameObjectWithTag("SongSelection").GetComponent<PlayAudio>();
        }

    }

    public void Update()
    {
        //if the pause menu or the settings menu are active, the game is paused
        if (pauseMenuUI.activeSelf || settingsMenuUI.activeSelf)
        {

            GameIsPaused = true;
        }
        else
        {
            GameIsPaused = false;
        }

        if (GameIsPaused)
            {
            Pause();

            }
        else
            {
            Resume();
            }
    }

    //when paused, hide any circles, pause any music and stop time
    public void Pause()
    {
       
        GameObject go = GameObject.FindGameObjectWithTag("Spawnable");
        if (go)
        {
            HideCircle.CircleOff = true;
            Debug.Log("Circle off" + HideCircle.CircleOff);
        }


        GameObject go_d = GameObject.FindGameObjectWithTag("SongSelection");
        if (go_d)
        {
            playAudio.PauseSong();
        }


        Time.timeScale = 0f;

    }

    //when game is resumed, start time and show any circles
    public void Resume()
    {

        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);

        GameObject go = GameObject.FindGameObjectWithTag("Spawnable");
        if (go)
        {
            HideCircle.CircleOff = false;
      
        }
 
        GameIsPaused = false;

    }


    //if settings are on, hide circles, hide home UI, pause the difficulty timer, but allow time to start, so any scene changes can be done
    public void SettingsMenuOn()
    {

        Time.timeScale = 1f;
        settingsOn = true;
        Debug.Log("settingsOn" + settingsOn);

        GameObject go = GameObject.FindGameObjectWithTag("Spawnable");
        if (go)
        {
            HideCircle.CircleOff = true;
            Debug.Log("Circle off" + HideCircle.CircleOff);
        }
        else
        {
            Debug.Log("no Spawnable");
        }


        GameObject go_b = GameObject.FindGameObjectWithTag("HomeUI");
            if (go_b)
            {
                HomeUI.RemoveUI = true;
            }
            else
            {
                 Debug.Log("NoHomeUI");
            }


        Debug.Log("settingsOn" + settingsOn);


        GameObject go_c = GameObject.FindGameObjectWithTag("Timer");
        if (go_c)
        {
            difficultyTimer.startTimer = false;
        }
        else
        {
            Debug.Log("no Timer");
        }


    }

    public void SettingsMenuOff()
    {

        GameObject go_b = GameObject.FindGameObjectWithTag("HomeUI");
        if (go_b)
        {
            StartCoroutine(ShowUI());
            Debug.Log("ShowUI Coroutine");
        }
        else
        {
            
        }

        Debug.Log("settingsOn" + settingsOn);


        IEnumerator ShowUI()
        {
            yield return new WaitForSeconds(1f);
            Debug.Log("ShowUI wait");

            HomeUI.RemoveUI = false;

            Debug.Log("ShowUI");
        }


    }


    public void PauseMenuOff()
    {
        PauseUI.RemovePauseUI = true;
    }

    public void PauseMenuOn()
    {
        StartCoroutine(ShowPauseUI());
        Debug.Log("ShowUI Coroutine");

        IEnumerator ShowPauseUI()
        {
            yield return new WaitForSeconds(1f);
            Debug.Log("ShowUI wait");

            PauseUI.RemovePauseUI = false;

            Debug.Log("ShowPauseUI");
        }
    }
}



