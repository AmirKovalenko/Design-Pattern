using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    public GameObject actor;
    public State(GameObject actorRef) //consturctor - is called when creating a new instance of a state
    {
        actor = actorRef;
    }
    public virtual void HandleState(KeyCode input)
    {
        
    }

}
