using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchMovingState : State
{
    public float speed;
    public bool isCrouching;
    public CrouchMovingState(GameObject actorRef, float speed, bool isCrouching) : base(actorRef)
    {
        this.speed = speed;
        this.isCrouching = isCrouching;
    }

    public override void HandleState(KeyCode input)
    {
        base.HandleState(input);
        if (input == (KeyCode.D))
        {
            if (isCrouching)
            {
                speed = speed * 0.5f;
                actor.transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
        }
        if (input == (KeyCode.A))
        {
            if (isCrouching)
            {
                speed = speed * 0.5f;
                actor.transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
        }

    }
}
