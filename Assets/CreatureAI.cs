using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureAI : MonoBehaviour
{
    public Creature myCreature; //the creature we are piloting
    public Creature targetCreature; 

    //State machine====================================================
    //States go here
    CreatureAIState currentState; 
    public CreatureAIIdleState idleState{get; private set;}
    public CreatureAIHugState hugState{get; private set;}
    public CreatureAIPatrolState patrolState{get; private set;}


    public void ChangeState(CreatureAIState newState){
        currentState = newState;
        currentState.BeginStateBase();
    }


    // Start is called before the first frame update
    void Start()
    {
        idleState = new CreatureAIIdleState(this);
        hugState = new CreatureAIHugState(this);
        patrolState = new CreatureAIPatrolState(this);
        currentState = idleState;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentState.UpdateStateBase();
    }

    public Creature GetTarget(){
        
        if(Vector3.Distance(transform.position,targetCreature.transform.position) < 5){
            return targetCreature;
        }else{
            return null;
        }
        
    }
}
