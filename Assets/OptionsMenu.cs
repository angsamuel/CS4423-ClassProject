using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class OptionsMenu : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    void Start(){

        if(PlayerPrefs.GetInt("set default volume2") == 0){
            masterSlider.value = .5f;
            musicSlider.value = .5f;
            sfxSlider.value = .5f;
            PlayerPrefs.SetInt("set default volume2",1);
        }


        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    }

    public void SetMasterVolume(){
        SetVolume("MasterVolume", masterSlider);
    }

    public void SetSFXVolume(){
        SetVolume("SFXVolume", sfxSlider);
    }

    public void SetMusicVolume(){
        SetVolume("MusicVolume", musicSlider);
    }

    public void SetVolume(string name, Slider slider){
        float volume = Mathf.Log10(slider.value) * 20;
        if(slider.value == 0){
            volume = -80;
        }
        mixer.SetFloat(name,volume);
        PlayerPrefs.SetFloat(name,slider.value);
    }

    

}
