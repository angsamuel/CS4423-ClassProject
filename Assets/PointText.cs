using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointText : MonoBehaviour
{
    public Text pointText;

    void Start(){
        GameObject.FindGameObjectWithTag("Player").GetComponent<Character>().pointEvent.AddListener(SetPointText);

        //add a listener with mismatched number of arguments
        //avoid this if possible
        //GameObject.FindGameObjectWithTag("Player").GetComponent<Character>().pointEvent.AddListener(delegate{AddTwoNumbers(1,2);});
    }



    public void SetPointText(int p){
        pointText.text = p.ToString();
    }

    public void AddTwoNumbers(int a, int b){
        Debug.Log(a+b);
    }
}
