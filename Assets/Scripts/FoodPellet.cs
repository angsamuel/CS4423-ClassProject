using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPellet : MonoBehaviour
{


    public void Eat(GameObject charObject){
        Debug.Log("EAT");

        //grow the character
        charObject.transform.localScale *= 1.1f;

        //play the sound
        GetComponent<AudioSource>().pitch = Random.Range(.7f,1.3f);
        
        //play our sound
        GetComponent<AudioSource>().Play();
        
        //get rid of the food
        //teleport so that the sound can finish playing
        transform.position = new Vector3(1000000,0,0);

        //destroy five seconds later
        Destroy(this.gameObject,5);
    }
}
