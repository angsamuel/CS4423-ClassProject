using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RezSettings : MonoBehaviour
{
    public Dropdown dropDown;
    Resolution[] resolutions;

    public Toggle toggle;

    

    void Start(){
        toggle.isOn = Screen.fullScreen;
        resolutions = Screen.resolutions;
        dropDown.options = new List<Dropdown.OptionData>();

        for(int i = 0; i<resolutions.Length; i++){
            string resolutionString = resolutions[i].width + "x" + resolutions[i].height;
            dropDown.options.Add(new Dropdown.OptionData(resolutionString));

            //set to be our default
            if(PlayerPrefs.GetInt("set default resolution") == 0){
                if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height){
                    dropDown.value = i;
                    PlayerPrefs.SetInt("set default resolution",1);
                    SetResolution();
                }
            }
        }

        Debug.Log(PlayerPrefs.GetInt("resolution"));
        dropDown.value = PlayerPrefs.GetInt("resolution");
            

        
        
               
    }

    public void SetResolution(){
        Screen.SetResolution(resolutions[dropDown.value].width,resolutions[dropDown.value].height,Screen.fullScreen);
        PlayerPrefs.SetInt("resolution",dropDown.value);
    }

    public void SetFullScreen(){
        Screen.fullScreen = toggle.isOn;
    }
}
