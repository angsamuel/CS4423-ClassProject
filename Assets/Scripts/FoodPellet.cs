using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class FoodPellet : MonoBehaviour
{
    public FoodPelletSO foodPelletSO;

    public static float growFactor = 1.1f;

    public static event Action onAnyFoodEaten;

    void Start(){
        if(foodPelletSO != null){
            GetComponent<SpriteRenderer>().color = foodPelletSO.color;
        }
        
    }



    public void Eat(GameObject charObject){
        if(foodPelletSO != null){
            foodPelletSO.numberPickedUp += 1;
        }
        //grow the character
        charObject.transform.localScale *= growFactor;

        //play the sound
        //GetComponent<AudioSource>().pitch = UnityEngine.Random.Range(.7f,1.3f);
        
        //play our sound
        //GetComponent<AudioSource>().Play();
        
        //get rid of the food
        //teleport so that the sound can finish playing
        transform.position = new Vector3(1000000,0,0);
        
        onAnyFoodEaten.Invoke();

        //destroy five seconds later
        Destroy(this.gameObject,5);
    }
}
