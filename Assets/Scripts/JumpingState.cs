using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class JumpingState : State
{
    public bool isJumping;
    public float jumpForce;
    public JumpingState(GameObject actorRef, bool isJumping,float jumpForce) : base(actorRef)
    {
        this.isJumping = isJumping;
        this.jumpForce = jumpForce;
    }

    public override void HandleState(KeyCode input)
    {
        base.HandleState(input);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isJumping)
            {
                isJumping = true;
                actor.transform.Translate(Vector2.up * jumpForce * Time.deltaTime);
                Debug.Log("Jumping");
            }
            else if (isJumping)
            {
                Debug.Log("Not Jumping");
            }

        }
    }
}
