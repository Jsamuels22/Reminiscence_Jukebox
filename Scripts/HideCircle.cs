using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCircle : MonoBehaviour
{
    CircleCollider2D circleCollider2D;
    SpriteRenderer spriteRenderer;

    public static bool CircleOff = false;


    private void Start()
    {
        circleCollider2D = gameObject.GetComponent<CircleCollider2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // circles are hidden when not needed
    public void Update()
    {
        if (CircleOff == false)
        {

            circleCollider2D.enabled = true;
            spriteRenderer.enabled = true;
            //Debug.Log("Hide Circle Circle off" + CircleOff);

        }
        else
        {
            circleCollider2D.enabled = false;
            spriteRenderer.enabled = false;
            Debug.Log("Hide Circle" + CircleOff);

        }

    
    }


}
