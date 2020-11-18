using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SongSelection : MonoBehaviour
{
    private GameObject[] songList;
    private int index;
    private PauseMenu pauseMenu;


    private PlaylistSelection playlistSelection;


    private void Start()
    {

        pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<PauseMenu>();

        playlistSelection = GameObject.FindGameObjectWithTag("Singleton").GetComponent<PlaylistSelection>();

        for (int i = 0; i < playlistSelection.stringPlaylist.Count; i++)
        {

            GameObject selectedSong = (GameObject)Instantiate(Resources.Load(playlistSelection.stringPlaylist[i]));
            selectedSong.name = playlistSelection.stringPlaylist[i].ToString();

            RectTransform rt = selectedSong.GetComponent<RectTransform>();
            selectedSong.transform.parent = GameObject.Find("SongWindow").transform;
            rt.sizeDelta = new Vector2(1, 1);
            selectedSong.transform.localScale = new Vector3(1, 1, 1);
            selectedSong.transform.position = new Vector3(0, 1.2f, 0);


        }



        index = PlayerPrefs.GetInt("SongSelected");

        Debug.Log("playerPrefs song selected" + PlayerPrefs.GetInt("SongSelected"));


        songList = new GameObject[transform.childCount];

        //fill array with songs
        for (int i = 0; i < transform.childCount; i++)
        {
            songList[i] = transform.GetChild(i).gameObject;
        }
        //toggle off renderer
        foreach (GameObject go in songList)
        {
            go.SetActive(false);
        }

        if(index >= songList.Length)
        {
            Debug.Log("index too large");
            index = 0;
        }
        
        //toggle on selected song index
        if (songList[index])
        {
            songList[index].SetActive(true);
        }

    }




    public void ToggleLeft()
    {
        //toggle off current song
        songList[index].SetActive(false);

        index--;
        if(index < 0)
        {
            index = songList.Length - 1;
        }


        //toggle on new song
        songList[index].SetActive(true);
    }



    public void ToggleRight()
    {
        //toggle off current song
        songList[index].SetActive(false);

        index++;
        if (index == songList.Length) 
        {
            index = 0;
        }


        //toggle on new song
        songList[index].SetActive(true);
    }


    public void LoadMainGame()
    {

        PlayerPrefs.SetInt("SongSelected", index);
        pauseMenu.Resume();
        SceneManager.LoadScene(3);
        Debug.Log("Load Main Game");
    }
}
