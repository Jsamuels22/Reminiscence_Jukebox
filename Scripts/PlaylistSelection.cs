using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaylistSelection : MonoBehaviour
{
    public static PlaylistSelection Instance { get; private set; }
    public GameObject parent;

    public Vector3 songPosition;

    public List<string> stringPlaylist = new List<string>();

    // create singleton, start by adding the default songs to its list
    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else if (Instance != null)
        {
            Destroy(gameObject);
        }

        stringPlaylist.Add("Cupid");
        stringPlaylist.Add("SinginInTheRain");
        stringPlaylist.Add("ComeFlyWithMe");

    }


    // when exiting the playlist selection scene, clear the string list and re-fil;
    public void CheckPlaylist() 
    {

        stringPlaylist.Clear();

        FillPlaylist();
    }

    //find the playlist gameObject, get the names of its children and add it to a list of strings
    public void FillPlaylist()
    {

        parent = GameObject.FindGameObjectWithTag("Playlist");

        int children = parent.transform.childCount;

        for (int i = 0; i < children; ++i)
        {

            stringPlaylist.Add(parent.transform.GetChild(i).name);

        }


        foreach (var x in stringPlaylist)
        {
            Debug.Log(x);

        }



    }

}

     

    

