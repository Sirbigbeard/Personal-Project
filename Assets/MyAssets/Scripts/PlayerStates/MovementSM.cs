using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSM : StateMachine
{
    [HideInInspector]
    public Idle idleState;
    [HideInInspector]
    public Walking walkingState;
    public Animation characterAnimation;

    private void Awake()
    {
        idleState = new Idle(this);
        walkingState = new Walking(this);
    }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }
}
