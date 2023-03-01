using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInAudio : MonoBehaviour
{

    public float fadeTime = 1;
    void Start(){
        StartCoroutine(FadeInMusicRoutine());
    }

    IEnumerator FadeInMusicRoutine(){
        AudioSource audioSource = GetComponent<AudioSource>();
        float maxVolume = audioSource.volume;
        float t = 0;
        audioSource.volume = 0;
        audioSource.Play();
        while(t<fadeTime){
            t+=Time.deltaTime;
            yield return null;
            audioSource.volume = Mathf.Lerp(0,maxVolume,t/fadeTime);
        }
        audioSource.volume = maxVolume;
        yield return null;
    }
}
