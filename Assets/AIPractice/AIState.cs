using UnityEngine;
using UnityEngine.Events;

public abstract class AIState 
{   
    protected AI ai;
    protected float stateTimer = 0;
    public AIState(AI newAI){
        ai = newAI;
        stateTimer = 0;
    }
    public void UpdateStateBase(){
        stateTimer += Time.fixedDeltaTime;
        UpdateState();
    }

    public abstract void UpdateState();
    public abstract void BeginState();
    
}
