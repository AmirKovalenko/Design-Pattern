using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingState : State
{
    public StandingState(GameObject actorRef) : base(actorRef)
    {

    }

    public override void HandleState(KeyCode input)
    {
        base.HandleState(input);
    }
}
