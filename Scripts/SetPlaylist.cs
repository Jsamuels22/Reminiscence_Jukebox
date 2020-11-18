using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlaylist : MonoBehaviour
{
    PlaylistSelection playlistSelection;

    //on opening of the playlist selection scene, move all songs to one column, read the list and move songs
    //into the playlist
    private void Awake()
    {
        MoveToLeft();
        CheckList();
    }


    //move objects under the parent of RedListContent
    public void MoveToLeft()
    {
        transform.parent = GameObject.Find("RedListContent").transform;
    }


    //Check the singleton, check the list of strings (the songs in the playlist) and move under the parent
    // of GreenListContent
    public void CheckList()
    {
        playlistSelection = GameObject.FindGameObjectWithTag("Singleton").GetComponent<PlaylistSelection>();

        for (int i = 0; i < playlistSelection.stringPlaylist.Count; i++)
        {

            if (name == playlistSelection.stringPlaylist[i])
            {
                transform.parent = GameObject.Find("GreenListContent").transform;
            }

        }
    }

}




