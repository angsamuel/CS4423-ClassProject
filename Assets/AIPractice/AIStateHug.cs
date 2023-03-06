using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateHug : AIState
{
    public AIStateHug(AI newAI):base(newAI){
    }

    public override void UpdateState(){
        if(ai.FindTarget()){
            ai.creature.MoveToward(ai.FindTarget().transform.position);
        }else{
            ai.creature.Stop();
            ai.ChangeState(ai.patrolState);
        }
        
    }
    public override void BeginState()
    {
        ai.SetColorHug();
    }
}
