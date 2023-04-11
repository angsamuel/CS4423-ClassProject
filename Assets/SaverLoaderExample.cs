using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaverLoaderExample : MonoBehaviour
{
    //with player prefs
    public Character character;

    public static SaverLoaderExample singletonCheck;
    

    void Start(){

        DontDestroyOnLoad(this.gameObject);

        if(singletonCheck == null){
            singletonCheck = this;
        }else{  
            Destroy(this.gameObject);
        }        

        SaveSystem.Initialize("default.bin");
        SaveSystem.SetInt(MeepisSaveKeys.pointKey, 0);
        SaveSystem.SetFloat("size", 1);
        SaveSystem.SaveToDisk();

        LoadPlayer();
        
        character.pointEvent.AddListener(SavePlayer);
    }
    void SavePlayer(int points){
        SaveSystem.SetInt(MeepisSaveKeys.pointKey, points);
        SaveSystem.SetFloat("size", character.transform.localScale.x);
        SaveSystem.SaveToDisk();
    }

    void LoadPlayer(){
        character.points = SaveSystem.GetInt(MeepisSaveKeys.pointKey);
        character.transform.localScale = Vector3.one * Mathf.Max(1,SaveSystem.GetFloat("size"));
    }

}
