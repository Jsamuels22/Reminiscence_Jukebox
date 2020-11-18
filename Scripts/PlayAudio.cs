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



        //find the active song by looking at which child of this object is active, and call this "selectedSong"
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


    //find the selected song name, instantiate the correct UI at the top of the screen,
    //depending on the resource name 
    public void SongUI()
    {
        GameObject selectedSongIcon = (GameObject)Instantiate(Resources.Load(selectedSongName + "MainGame"));
        selectedSongIcon.transform.parent = GameObject.Find("SongTitleUI").transform;

        RectTransform rt = selectedSongIcon.GetComponent<RectTransform>();
       
        rt.sizeDelta = new Vector2(0, 0);
        selectedSongIcon.transform.localScale = new Vector3(1, 1, 1);
        selectedSongIcon.transform.position = new Vector3(0, 4.5f, 90);
    }



    //find the selected song and play it
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


    // find how long the selected song is, wait that ammount of time, then show end screen. If there is a circle
    // as the song ends, destroy the circle
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
