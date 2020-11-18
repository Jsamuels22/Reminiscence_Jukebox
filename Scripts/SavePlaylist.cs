using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI.Extensions;

public class SavePlaylist : MonoBehaviour
{

    ReorderableList reorderableList;

    public static bool EmptyPlaylist = false;
    public GameObject playlistIsEmptyUI;


    public GameObject playlistSlot;


    private void Start()
    {
        reorderableList = GameObject.FindGameObjectWithTag("Dragable").GetComponent<ReorderableList>();
        
    }

    private void Update()
    {
        if (playlistSlot.transform.childCount > 0)
        {

            EmptyPlaylist = false;
            reorderableList.IsDraggable = true;
            reorderableList.IsDropable = true;



        }
        else
        {
            EmptyPlaylist = true;
            reorderableList.IsDraggable = false;
            reorderableList.IsDropable = false;
            playlistIsEmptyUI.SetActive(true);
            Debug.Log("PlaylistEmpty");
        }
    }


}
