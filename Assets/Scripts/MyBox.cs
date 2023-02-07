using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBox : MonoBehaviour
{
    public void ChangeColor(Color c){
        GetComponent<SpriteRenderer>().color = c;
    } 
}
