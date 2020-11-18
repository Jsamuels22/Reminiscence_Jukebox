using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static AudioClip CmajScale0, CmajScale1, CmajScale2, CmajScale3,
        CmajScale4, CmajScale5, CmajScale6, CmajScale7, Glenn_Miller_In_The_Mood;
    static AudioSource audioSource;
   

    // Start is called before the first frame update
    void Start()
    {

        CmajScale0 = Resources.Load<AudioClip>("CmajScale0");
        CmajScale1 = Resources.Load<AudioClip>("CmajScale1");
        CmajScale2 = Resources.Load<AudioClip>("CmajScale2");
        CmajScale3 = Resources.Load<AudioClip>("CmajScale3");
        CmajScale4 = Resources.Load<AudioClip>("CmajScale4");
        CmajScale5 = Resources.Load<AudioClip>("CmajScale5");
        CmajScale6 = Resources.Load<AudioClip>("CmajScale6");
        CmajScale7 = Resources.Load<AudioClip>("CmajScale7");


        audioSource = GetComponent<AudioSource>();

    }




    public static void PlaySound(int clip)
    {
        switch (clip)
        {
            case 1:
                audioSource.PlayOneShot(CmajScale0);
                break;

            case 2:
                audioSource.PlayOneShot(CmajScale1);
                break;

            case 3:
                audioSource.PlayOneShot(CmajScale2);
                break;

            case 4:
                audioSource.PlayOneShot(CmajScale3);
                break;

            case 5:
                audioSource.PlayOneShot(CmajScale4);
                break;

            case 6:
                audioSource.PlayOneShot(CmajScale5);
                break;

            case 7:
                audioSource.PlayOneShot(CmajScale6);
                break;

            case 8:
                audioSource.PlayOneShot(CmajScale7);
                break;
        }

    }
}
