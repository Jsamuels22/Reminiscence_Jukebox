using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedSongList : MonoBehaviour
{

    private GameObject[] selectedSongs;

    // Start is called before the first frame update
    void Start()
    {
        selectedSongs = new GameObject[transform.childCount];

        //fill array with songs
        for (int i = 0; i < transform.childCount; i++)
        {
            selectedSongs[i] = transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
