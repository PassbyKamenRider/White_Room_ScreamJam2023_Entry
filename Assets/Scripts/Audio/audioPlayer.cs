using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    public static audioPlayer instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public AudioSource audio_keyboard, audio_white_noise, audio_mouse, audio_walk;


    public void play_audio_keyboard() {
        audio_keyboard.Play();
    }


    public void play_audio_mouse() {
        audio_mouse.Play();
    }


    public void play_audio_walk() {
        audio_walk.Play();
    }

    public void stop_audio_walk() {
        audio_walk.Stop();
    }
}
