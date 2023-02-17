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
    public override void UpdateLogic()
    {
        _sm.characterAnimation.Play("Walk");
    }
}
