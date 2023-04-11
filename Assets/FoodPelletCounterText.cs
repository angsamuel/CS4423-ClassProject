using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodPelletCounterText : MonoBehaviour
{
    //with player prefs
    public FoodPelletSO foodPelletSo;

    public Text text;
    void Start(){
        text = GetComponent<Text>();
        text.color = foodPelletSo.color;
    }
    void Update(){
        text.text = foodPelletSo.numberPickedUp.ToString();
    }

}
