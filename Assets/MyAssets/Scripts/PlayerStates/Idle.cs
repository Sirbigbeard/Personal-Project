using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : BaseState
{
    private MovementSM _sm;

    public Idle(MovementSM stateMachine) : base("Idle", stateMachine)
    {
        _sm = stateMachine;
    }
    public override void UpdatePhysics()
    {

    }
}
