using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit(){
        Application.Quit(); //this does not work in the editor
    }
}
