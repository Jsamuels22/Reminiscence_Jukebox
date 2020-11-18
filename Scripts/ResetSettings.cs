using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSettings : MonoBehaviour
{

    PlaylistSelection playlistSelection;
    PauseMenu pauseMenu;


    private void Start()
    {
        playlistSelection = GameObject.FindGameObjectWithTag("Singleton").GetComponent<PlaylistSelection>();
        pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<PauseMenu>();

    }

    //reset all settings,  clear the saved playlist and assume it is a users first time opening,
    //this will force a user to play the tutorial before the main game, therefore, allowing on opportunity
    // to set a new difficulty level
    public void ResetAllSettings(bool isOn)
    {
        if (isOn)


            pauseMenu.Resume();
        PlayerPrefs.SetInt("FIRSTTIMEOPENING", 1);

        playlistSelection.stringPlaylist.Clear();

        playlistSelection.stringPlaylist.Add("Cupid");
        playlistSelection.stringPlaylist.Add("SinginInTheRain");

    }
}
