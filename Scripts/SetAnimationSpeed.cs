using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimationSpeed : MonoBehaviour
{

    Animator circleAnim;
    AnimationSpeed animationSpeed;
    public float animateSpeed;

    
    private void Awake()
    {
        circleAnim = GetComponent<Animator>();
    }

    private void Start()
    {
        animationSpeed = GameObject.FindGameObjectWithTag("Anim").GetComponent<AnimationSpeed>();

    }

    //find the animation speed from the Animation controller game object and set the circle animation speed
    private void Update()
    {
        animateSpeed = animationSpeed.animSpeed;
        circleAnim.speed = animateSpeed;
    }

}
