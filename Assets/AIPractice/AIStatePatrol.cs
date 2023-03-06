using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStatePatrol : AIState
{   
    float patrolInterval = 1f;
    Vector3 vel;
    public AIStatePatrol(AI newAI):base(newAI){
        
    }
    
    void GenerateRandomVel(){
        vel = new Vector3(Random.Range(-1f,1f),Random.Range(-1f,1f));
    }

    public override void UpdateState(){
        
        //pick new direction after state timer grows to large enough value
        if(stateTimer > patrolInterval){
            stateTimer = 0;
            GenerateRandomVel();
        }
        ai.creature.Move(vel);

        if(ai.FindTarget() != null){
            ai.ChangeState(ai.hugState);
        }
    
    }
    public override void BeginState()
    {
        ai.SetColorNeutral();
    }
}
