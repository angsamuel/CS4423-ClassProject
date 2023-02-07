using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : MonoBehaviour
{
    public GameObject foodPelletPrefab;
    public GameObject shrinkPelletPrefab;


    void Start(){
        GeneratePellets();
   
    }

    //float timeTracker = 0;
    void Update(){

    }

    void ExampleMethod(){
        return;

        //asdjkhasdopajs

    }


    void GeneratePellets(){

        StartCoroutine(GeneratePelletsRoutine());
    
        IEnumerator GeneratePelletsRoutine(){
            Debug.Log("GENERATION START!");

            
            
            while(true){
                Vector2 randomPosition = new Vector2(Random.Range(-5f,5f),Random.Range(-5f,5f));
                yield return new WaitForSeconds(2f);
                GameObject newPellet = Instantiate(foodPelletPrefab,randomPosition,Quaternion.identity);
                Destroy(newPellet,60);
            }




        }
    }
    
}
