using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenOptions : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    public Toggle isFullScreen;
    Resolution[] resolutions;
    void Start(){
        resolutions = Screen.resolutions;
        isFullScreen.isOn = Screen.fullScreen;
        for(int i = 0; i<resolutions.Length; i++){
            string resolutionString = resolutions[i].width.ToString() + "x" + resolutions[i].height.ToString();
            resolutionDropdown.options.Add(new Dropdown.OptionData(resolutionString));

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height){
                resolutionDropdown.value = i;
            }

        }
    }


    public void SetResolution(){
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height,isFullScreen.isOn);
    }
}
