using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : MonoBehaviour
{
    public List<GameObject> foodPelletPrefabs;
    public GameObject shrinkPelletPrefab;


    void Start(){
        GeneratePellets();
   
    }

    //float timeTracker = 0;
    void Update(){

    }

    void ExampleMethod(){
        return;
    }


    void GeneratePellets(){

        StartCoroutine(GeneratePelletsRoutine());
    
        IEnumerator GeneratePelletsRoutine(){
            Debug.Log("GENERATION START!");
            while(true){ //goes forever
                Vector2 randomPosition = new Vector2(Random.Range(-5f,5f),Random.Range(-5f,5f)); //random position
                yield return new WaitForSeconds(2f);
                GameObject newPellet = Instantiate(foodPelletPrefabs[Random.Range(0,foodPelletPrefabs.Count)],randomPosition,Quaternion.identity);
                Destroy(newPellet,60);
            }

        }
    }
    
}
