using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeUI : MonoBehaviour
{

    public GameObject HiddenHomeUI;

    public static bool RemoveUI = false;

    public void Update()
    {
        // UI on the home screen is hidden when not needed
        if (RemoveUI == false)
        {
            HiddenHomeUI.SetActive(true);
        }
        else
        {
            HiddenHomeUI.SetActive(false);
        }



    }


}
