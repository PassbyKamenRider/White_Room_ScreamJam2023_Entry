using System.Collections;
using UnityEngine;

public class audioPlayer : MonoBehaviour
{   
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

    public AudioSource audio_keyboard, audio_white_noise, audio_mouse, audio_walk, audio_sit, audio_eat, audio_flush, audio_place,
    audio_light, audio_bed, audio_dream, audio_music;

    public AudioClip audioclip_intense_1, audioclip_intense_2, audioclip_theme;

    private float timer;
    private bool changeClip;

    private void Update() {
        timer += Time.deltaTime;
        if (changeClip && timer >= 64.0f)
        {
            changeClip = false;
            audio_music.clip = audioclip_intense_2;
            audio_music.loop = true;
            audio_music.Play();
        }
    }

    public void play_audio_keyboard()
    {
        audio_keyboard.Play();
    }

    public void play_audio_mouse()
    {
        audio_mouse.Play();
    }

    public void play_audio_walk()
    {
        audio_walk.loop = true; // Ensure it loops
        audio_walk.Play();
    }

    public void stop_audio_walk()
    {
        if (audio_walk.isPlaying)
        {
            float halfDuration = audio_walk.clip.length / 2;

            if (audio_walk.time <= halfDuration)
            {
                // If currently in the first half
                StartCoroutine(StopAfterDelay(audio_walk, halfDuration - audio_walk.time));
            }
            else
            {
                // If currently in the second half
                float remainingTimeInClip = audio_walk.clip.length - audio_walk.time;
                StartCoroutine(StopAfterDelay(audio_walk, remainingTimeInClip));
            }
        }
    }

    IEnumerator StopAfterDelay(AudioSource audioSource, float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSource.Stop();
    }

    public void play_audio_eat()
    {
        audio_eat.Play();
    }

    public void play_audio_sit()
    {
        audio_sit.time = 1.0f;
        audio_sit.Play();
    }


    public void play_audio_flush()
    {
        audio_flush.Play();
    }


    public void play_audio_place()
    {
        audio_place.Play();
    }


    public void play_audio_light()
    {
        audio_light.Play();
    }


    public void play_audio_bed()
    {
        audio_bed.Play();
    }


    private void play_audio_dream_helper()
    {   
        audio_dream.Play();
    }

    public void play_audio_dream()
    {   
        Invoke("play_audio_dream_helper", 4f);
    }

    public void play_audio_music_bad()
    {
        PlayAndLoopMusic();
    }

    public void stop_audio_music_bad()
    {
        audio_music.loop = false;
        audio_music.Stop();
    }


    public void play_audio_music_good()
    {
        audio_music.clip = audioclip_theme;
        audio_music.loop = true;
        audio_music.Play();
    }

    private void PlayAndLoopMusic()
    {
        audio_music.clip = audioclip_intense_1;
        audio_music.loop = false;
        audio_music.Play();
        changeClip = true;
        timer = 0f;
    }





    

}