using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneSwitcher : MonoBehaviour
{
    private Scene Scene;
    private PauseMenu pauseMenu;
    PlaylistSelection playlistSelection;




    private void Start()
    {
        Scene = SceneManager.GetActiveScene();


        pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<PauseMenu>();
        playlistSelection = GameObject.FindGameObjectWithTag("Singleton").GetComponent<PlaylistSelection>();


    }


    public void GoHome()
    {
        pauseMenu.Resume();
        SceneManager.LoadScene(0);
        Debug.Log("Go Home");
    }

    public void StartGame()
    {

        pauseMenu.Resume();

        ////DEBUG to load tutorial
        //SceneManager.LoadScene(1);


        if (PlayerPrefs.GetInt("FIRSTTIMEOPENING", 1) == 1)
        {
            Debug.Log("First Time Opening");

            //Set first time opening to false
            PlayerPrefs.SetInt("FIRSTTIMEOPENING", 0);

            //Do your stuff here
            SceneManager.LoadScene(1);

            Debug.Log("Start Tutorial");
        }
        else
        {
            Debug.Log("NOT First Time Opening");

            //Do your stuff here
            SceneManager.LoadScene(2);
            Debug.Log("Load Song Selection");
        }

    }

    public void StartTutorial()
    {
        pauseMenu.Resume();
        SceneManager.LoadScene(1);
        Debug.Log("Start Tutorial");
    }

    public void TutorialEnd()
    {
        pauseMenu.Resume();
        SceneManager.LoadScene(2);
        Debug.Log("Load Song Selection");
    }

    public void LoadMainGame()
    {
        pauseMenu.Resume();
        SceneManager.LoadScene(3);
        Debug.Log("Load Main Game");
    }


    public void ReloadScene()
    {
        pauseMenu.Resume();
        SceneManager.LoadScene(Scene.name);
        Debug.Log("Reload Scene");
    }

    public void LoadPlaylist()
    {
        pauseMenu.Resume();
        SceneManager.LoadScene(4);
        Debug.Log("LoadPlaylist");
    }

    public void ExitPlaylist()
    {

        pauseMenu.Resume();
        playlistSelection.CheckPlaylist();
 

        SceneManager.LoadScene(0);
        Debug.Log("ExitPlaylist");
    }


    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
