using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : State
{
    public float speed;
    public MovingState(GameObject actorRef, float speed) : base(actorRef)
    {
        this.speed = speed;
    }

    public override void HandleState(KeyCode input)
    {
        base.HandleState(input);
        if (input == (KeyCode.D))
        {
            actor.transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        if (input == (KeyCode.A))
        {
            actor.transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }
}
