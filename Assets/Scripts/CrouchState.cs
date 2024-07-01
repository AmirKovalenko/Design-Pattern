using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchState : State
{
    public float speed;
    public bool isCrouching;
    public CrouchState(GameObject actorRef, float speed, bool isCrouching) : base(actorRef)
    {
        this.speed = speed;
        this.isCrouching = isCrouching;
    }

    public override void HandleState(KeyCode input)
    {
        base.HandleState(input);

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (!isCrouching)
            {
                isCrouching = true;
                speed = speed * 0.6f;
                Debug.Log("Crouching");
                actor.transform.localScale = new Vector2(1, 0.75f);
            }
            else if (isCrouching)
            {
                isCrouching = false;
                speed = speed * 2.0f;
                Debug.Log("Not Crouching");
                actor.transform.localScale = new Vector2(1, 1);
            }
        }
    }
}
