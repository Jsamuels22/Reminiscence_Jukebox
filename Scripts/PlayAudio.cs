using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{


    static AudioSource audioSource;
    public static GameObject selectedSong;
    static string selectedSongName;
    public GameObject gameOverUI;
    public float songDuration;
    AnimationSpeed AnimationSpeed;
    DifficultyTimer difficultyTimer;
    public GameObject lastCircle;



    private void Start()
    {


        AnimationSpeed = GameObject.FindGameObjectWithTag("Anim").GetComponent<AnimationSpeed>();

        GameObject go_c = GameObject.FindGameObjectWithTag("Timer");
        if (go_c)
        {
            difficultyTimer = GameObject.FindGameObjectWithTag("Timer").GetComponent<DifficultyTimer>();
        }

        audioSource = GetComponent<AudioSource>();

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (gameObject.transform.GetChild(i).gameObject.activeSelf == true)
            {
                selectedSong = gameObject.transform.GetChild(i).gameObject;
            }
        }

        selectedSongName = selectedSong.name;


        gameOverUI.SetActive(false);

        GameObject child = transform.Find(selectedSongName).gameObject;
        songDuration = child.GetComponent<AudioSource>().clip.length;
  
        Debug.Log("song duration" + songDuration);
    }
    
    public void SongUI()
    {
        GameObject selectedSongIcon = (GameObject)Instantiate(Resources.Load(selectedSongName + "MainGame"));
        selectedSongIcon.transform.parent = GameObject.Find("SongTitleUI").transform;

        RectTransform rt = selectedSongIcon.GetComponent<RectTransform>();
       
        rt.sizeDelta = new Vector2(0, 0);
        selectedSongIcon.transform.localScale = new Vector3(1, 1, 1);
        selectedSongIcon.transform.position = new Vector3(0, 4.5f, 90);
    }


    public void PlaySong()
    {
        SongUI();
        GameObject child = transform.Find(selectedSongName).gameObject;
        child.GetComponent<AudioSource>().Play();
        StartCoroutine(WhenSongEnds()); 
        
    }

    public void PauseSong()
    {
        GameObject child = transform.Find(selectedSongName).gameObject;
        child.GetComponent<AudioSource>().Pause();
    }

    public void ResumeSong()
    {
        GameObject child = transform.Find(selectedSongName).gameObject;
        child.GetComponent<AudioSource>().UnPause();
    }

    public void AudioFinished()
    {
        //gameOverUI.SetActive(true);
        //HideCircle.CircleOff = true;


    }

    IEnumerator WhenSongEnds()
    {
        yield return new WaitForSeconds(songDuration);


        lastCircle = GameObject.FindGameObjectWithTag("Spawnable");
        if (lastCircle)
        {
            Destroy(lastCircle);
        }


        PlayerPrefs.SetFloat("Difficulty Level", AnimationSpeed.animSpeed);
        Debug.Log("new Difficulty Level" + AnimationSpeed.animSpeed);


        gameOverUI.SetActive(true);
  
    }
}
