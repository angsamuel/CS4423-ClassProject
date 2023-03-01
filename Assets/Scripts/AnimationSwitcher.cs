using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSwitcher : MonoBehaviour
{
    public string currentState = "idle";
    public Animator animator;
    IEnumerator Start(){
        yield return new WaitForSeconds(1f);
        ChangeAnimationState("WalkAnim",5);
    }
    public void ChangeAnimationState(string newState, float transitionTime = .05f,float speed = 1f){
        //Debug.Log(newState);
        animator.speed = speed;
        if(newState == currentState){
            return;
        }
        //Debug.Log(newState);
        
        //animator.CrossFadeInFixedTime(newState,transitionTime);
        animator.Play(newState);
        
        currentState = newState;
    }
}
