using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousBar : MonoBehaviour
{
    public Transform barTransform;

    [Range(0f,1f)]
    public float progress = 0f;
    void Start(){
      SetBar();
    }

    void SetBar(){
        barTransform.localScale = new Vector3(progress,1,1);
    }
    
    void Update(){
        SetBar();
    }
}
