using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundOptions : MonoBehaviour
{

    public AudioMixer audioMixer;
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    void Start(){
        
        if(PlayerPrefs.GetInt("set first time volume") == 0){
            PlayerPrefs.SetInt("set first time volume",1);
            masterSlider.value = .25f;
            musicSlider.value = .25f;
            sfxSlider.value = .25f;
        }else{
            masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
            sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        }
    
    }

    public void SetMasterVolume(){
        SetVolume("MasterVolume",masterSlider.value);
    }

    public void SetMusicVolume(){
        SetVolume("MusicVolume",musicSlider.value);
    }

    public void SetSFXVoume(){
        SetVolume("SFXVolume",sfxSlider.value);
    }


    void SetVolume(string name, float value){
        float volume = Mathf.Log10(value) * 20;
        if(value == 0){
            volume = -80;
        }


        audioMixer.SetFloat(name,volume);
        PlayerPrefs.SetFloat(name,value);
    }


}
