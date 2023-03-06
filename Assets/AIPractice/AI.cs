using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{

    [Header("Config")]
    public Color neutralColor;
    public Color hugColor;


    public Creature creature{get; private set;}
    public Creature targetCreature;
    AIState currentState;


    //states=============================================
    //better to set up a dictionary to make this more flexible
    public AIStateWait waitState{get; private set;}
    public AIStatePatrol patrolState{get; private set;}
    public AIStateHug hugState{get; private set;}

    void Start(){
        creature = GetComponent<Creature>();

        //create the states
        waitState = new AIStateWait(this);
        patrolState = new AIStatePatrol(this);
        hugState = new AIStateHug(this);

        ChangeState(waitState);
    }

    public void ChangeState(AIState newState){
        currentState = newState;
        newState.BeginState();
    }

    void FixedUpdate(){
        if(currentState != null){
            currentState.UpdateStateBase();
        }
    }

    public Creature FindTarget(){
        if(targetCreature == null){
            return null;
        }
        if(Vector3.Distance(this.transform.position,targetCreature.transform.position) < 3){
            return targetCreature;
        }
        return null;
    }

    public void SetColorNeutral(){
        creature.GetComponent<SpriteRenderer>().color = neutralColor;
    }
    public void SetColorHug(){
        creature.GetComponent<SpriteRenderer>().color = hugColor;
    }
    public void SetColorPatrol(){
        
    }
}
