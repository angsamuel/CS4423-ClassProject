using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscreteBar : MonoBehaviour
{
    [Header("Config")]
    public int num = 1;
    [Header("Objects")]
    public Transform layoutTransform;
    public GameObject hpBlockPrefab;
    [Header("Tracking")]
    public List<GameObject> placedBlocks;
    public void SetBar(){
        if(placedBlocks.Count == num){
            return; //all good!
        }
        if(placedBlocks.Count < num){
            while(placedBlocks.Count < num){
                placedBlocks.Add(Instantiate(hpBlockPrefab,layoutTransform)); //add blocks
            }
            return;
        }
        if(placedBlocks.Count > num){
            while(placedBlocks.Count > num){
                Destroy(placedBlocks[placedBlocks.Count-1]); //remove blocks
                placedBlocks.RemoveAt(placedBlocks.Count-1);
            }
            return;
        }
    }

    void Update(){
        SetBar();
    }








}
