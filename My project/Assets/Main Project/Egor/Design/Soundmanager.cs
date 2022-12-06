using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Soundmanager : MonoBehaviour
{
    [SerializeField] Image musicOnIcon;
    [SerializeField] Image musicOffIcon;
    public AudioSource musicAudio;
    private bool musicMute = false;

    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;
    public AudioSource soundAudio;
    private bool soundMute = false;

    void Start()
    {
        if(!PlayerPrefs.HasKey("musicMute"))
        {
            PlayerPrefs.SetInt("musicMute", 0);
            Load();
        }
        else
        {
            Load();
        }

        UpdateMusicButtonIcon();

        if (!PlayerPrefs.HasKey("soundMute"))
        {
            PlayerPrefs.SetInt("soundMute", 0);
            LoadSound();
        }
        else
        {
            LoadSound();
        }

        UpdateAudioButtonIcon();

        switch (musicMute)
        {
            case true:
                musicAudio.Play();
                break;
            case false:
                musicAudio.Pause();
                break;
        }


        //AudioListener.pause = muted;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0) && !soundMute)
            soundAudio.Play();
            
    }
    public void OnMusicButtonPress()
    {
        if(musicMute == false)
        {
            musicMute = true;
            musicAudio.Pause();
            //AudioListener.pause = true;
        }
        else
        {
            musicMute = false;
            musicAudio.Play();
            //AudioListener.pause = false;
        }

        Save();
        UpdateMusicButtonIcon();
    }

    private void UpdateMusicButtonIcon()
    {
        if(musicMute == false)
        {
            musicOnIcon.enabled = true;
            musicOffIcon.enabled = false;
        }
        else
        {
            musicOnIcon.enabled = false;
            musicOffIcon.enabled = true;
        }
    }

    public void OnAudioButtonPress()
    {
        if (soundMute == false)
        {
            soundMute = true;
        }
        else
        {
            soundMute = false;
        }

        SaveSound();
        UpdateAudioButtonIcon();
    }

    private void UpdateAudioButtonIcon()
    {
        if (soundMute == false)
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
        }
        else
        {
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;
        }
    }
    private void LoadSound()
    {
        musicMute = PlayerPrefs.GetInt("soundMute") == 1;
    }


    private void SaveSound()
    {
        PlayerPrefs.SetInt("soundMute", musicMute ? 1 : 0);
    }

    private void Load()
    {
        musicMute = PlayerPrefs.GetInt("musicMute") == 1;
    }


    private void Save()
    {
        PlayerPrefs.SetInt("musicMute", musicMute ? 1 : 0);
    }
}
