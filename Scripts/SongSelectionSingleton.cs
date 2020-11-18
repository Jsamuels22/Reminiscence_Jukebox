using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongSelectionSingleton : MonoBehaviour
{
    public static SongSelectionSingleton Instance { get; private set; }
    public GameObject parent;

   

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
    }


    private void Start()
    {
        
    }



    public List<string> stringSongSelection = new List<string>();

    public void CheckSongSelection()
    {

        stringSongSelection.Clear();

        FillSongSelection();
    }

    public void FillSongSelection()
    {

        parent = GameObject.FindGameObjectWithTag("SongSelection");

        int children = parent.transform.childCount;

        for (int i = 0; i < children; ++i)
        {

            stringSongSelection.Add(parent.transform.GetChild(i).name);

        }




        foreach (var x in stringSongSelection)
        {
            Debug.Log(x);

        }




    }

}

     

    

