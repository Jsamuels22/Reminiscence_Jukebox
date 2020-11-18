using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlaylist : MonoBehaviour
{
    PlaylistSelection playlistSelection;

    private void Awake()
    {
        MoveToLeft();
        CheckList();
        //MoveToRight();
    }




    public void MoveToLeft()
    {
        transform.parent = GameObject.Find("RedListContent").transform;
    }


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


    //public void MoveToRight()
    //{
    //        transform.parent = GameObject.Find("GreenListContent").transform;
        
    //}
}




