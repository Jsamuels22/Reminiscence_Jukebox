using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourLerper : MonoBehaviour
{
    public Color red;
    public Color green;

    // change the colour of the song in the playlist manager scene depending on position
    void Update()
    {
        float pX = transform.position.x;

        GetComponent<Image>().color = Color.Lerp(red, green, pX);

    }
}
