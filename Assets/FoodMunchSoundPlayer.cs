using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FoodMunchSoundPlayer : MonoBehaviour
{
    AudioSource audioSource;
    void Awake(){
        audioSource = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        FoodPellet.onAnyFoodEaten += (PlayMunchSound);
    }

    void OnDisable()
    {
        FoodPellet.onAnyFoodEaten -= (PlayMunchSound);
    }

    void PlayMunchSound(){
        audioSource.Play();
    }



}
