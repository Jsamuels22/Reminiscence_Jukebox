using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSpeed : MonoBehaviour
{

    Animator anim;
    public float animSpeed;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
 
    public void Update()
    {
        anim.speed = animSpeed; 
    }

    // speed up or slow down the circle animation
    public void SpeedUp()
    {
        Debug.Log("speedUp");
        animSpeed += 0.2f;
        Debug.Log(animSpeed);
    }

    public void SlowDown()
    {
        Debug.Log("slowdown");
        animSpeed -= 0.2f;
        Debug.Log(animSpeed);

    }

}
