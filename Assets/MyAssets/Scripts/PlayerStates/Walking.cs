using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : BaseState
{
    private MovementSM _sm;
    public Walking(MovementSM stateMachine) : base("Walking", stateMachine)
    {
        _sm = stateMachine;
    }
    public override void Enter()
    {
        _sm.characterAnimation.Play("Walk");
        Debug.Log("walking");
    }
    public override void UpdateLogic()
    {
        
    }
}
