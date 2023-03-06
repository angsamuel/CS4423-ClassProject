using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateWait : AIState
{
    public AIStateWait(AI newAI) : base(newAI){
    }
    public override void UpdateState()
    {
        if(ai.FindTarget() != null){
            ai.ChangeState(ai.hugState);
        }
    }
    public override void BeginState()
    {
        ai.SetColorNeutral();
    }
}
