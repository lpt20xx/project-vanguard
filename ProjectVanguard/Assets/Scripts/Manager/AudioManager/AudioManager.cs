using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;
    public static int gameBGMCount = 0;
    

    private void Awake()
    {
        this.CheckInstance();
    }

    private void Start()
    {
        this.PlayMainMenuBGM();
        //this.GetGameBGMCount();
    }

    private void PlayMainMenuBGM()
    {
        PlayMusic("MainMenuBGM");
    }

    public int GetGameBGMCount()
    {
        foreach (var music in musicSounds)
        {
            if (music.name.Contains("GameBGM")){
                gameBGMCount++;
            }
        }

        return gameBGMCount;
    }

    private void CheckInstance()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name  == name);

        if (s != null)
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
        else
        {
            Debug.Log("Sound Not Found");
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s != null)
        {
            sfxSource.clip = s.clip;
            sfxSource.PlayOneShot(s.clip);
        }
        else
        {
            Debug.Log("Sound Not Found");
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
