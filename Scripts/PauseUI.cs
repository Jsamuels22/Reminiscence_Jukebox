using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    public GameObject HiddenPauseUI;

    public static bool RemovePauseUI = true;

    public void Update()
    {

        if (RemovePauseUI == false)
        {

            HiddenPauseUI.SetActive(false);
        }
        else
        {

            HiddenPauseUI.SetActive(true);

        }

    }
}
