using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MusicControl : MonoBehaviour {
    public AudioClip MusicClip;
    public AudioSource MusicSource;
    public Image Muted;
    public Sprite playSprite;
    public Sprite muteSprite;
    // Use this for initialization

    public float play;
    private static bool created = false;
    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
       
    }
    void Start () {
        MusicSource.clip = MusicClip;
        Muted = GameObject.FindGameObjectWithTag("MusicButton").GetComponent<Image>();
        MusicControlButton();

    }
	
	// Update is called once per frame
	
       

   
    public void MusicControlButton()
    {
        if (PlayerPrefs.GetFloat("Mute") == 0f)
        {
            PlayerPrefs.SetFloat("Mute", 1f);
        }
        else if(PlayerPrefs.GetFloat("Mute") == 1f)
        {
            PlayerPrefs.SetFloat("Mute", 0f);
        }
           play = PlayerPrefs.GetFloat("Mute");

        if(play == 0f)
        {
            MusicSource.Play();
            Muted.sprite = playSprite;
        }
        else if(play == 1f)
        {
            MusicSource.Stop();
            Muted.sprite = muteSprite;
            
        }

    }
}
