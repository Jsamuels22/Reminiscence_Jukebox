using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{

    Animator m_Animator;
    tutorialSpawn tutorialSpawn;
    public GameObject continueButton;
    public GameObject InfoText;

    private void Start()
    {
        tutorialSpawn = GameObject.FindGameObjectWithTag("Spawner").GetComponent<tutorialSpawn>();
        m_Animator = gameObject.GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        // At the end of the tutorial, wait one second, animate the "congratualtions" panel
        if (tutorialSpawn.counter == 9)
        {
            InfoText.SetActive(false);
            m_Animator.SetBool("bTutorial", true);
            Debug.Log("StartAnimation");
            StartCoroutine(Continue());
        }


            IEnumerator Continue()
            {
                
                yield return new WaitForSeconds(1f);
                continueButton.SetActive(true);
            }

           

        
    }
}
