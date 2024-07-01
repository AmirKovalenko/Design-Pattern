using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using static UnityEditor.VersionControl.Asset;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isJumping = false;
    [SerializeField] private bool isCrouching = false;
    private State currentState;
    [SerializeField] KeyCode input = KeyCode.None;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.None) && currentState is not CrouchState)  //standing state
        {
            currentState = new StandingState(gameObject);
            input = KeyCode.None;
        }

        else if (Input.GetKeyDown(KeyCode.C))
        {
            if (!isCrouching) 
            {
                currentState = new CrouchState(gameObject, speed, isCrouching);  //crouch state
                speed = speed * 0.5f;
                isCrouching = true;
                input = KeyCode.C;
            }
            else if (isCrouching)
            {
                currentState = new CrouchState(gameObject, speed, isCrouching);
                speed = speed * 2.0f;
                isCrouching = false;
                input = KeyCode.C;
            }

        }

        else if (Input.GetKey(KeyCode.A))
        {
            if (currentState is CrouchState)
            {
                currentState = new CrouchMovingState(gameObject, speed, isCrouching);   //left crouch moving state
                input = KeyCode.A;
            }
            else
            {
                currentState = new MovingState(gameObject, speed);        //left moving state
                input = KeyCode.A;
            }
        }

        else if (Input.GetKey(KeyCode.D))
        {
            if (currentState is CrouchState)
            {
                currentState = new CrouchMovingState(gameObject, speed, isCrouching);  //right crouch moving state
                input = KeyCode.D;
            }
            else
            {
                currentState = new MovingState(gameObject, speed);       //right moving state
                input = KeyCode.D;
            }
        }

        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isJumping)
            {
                currentState = new JumpingState(gameObject, isJumping, jumpForce);  //jumping state
                isJumping = true;
                input = KeyCode.Space;
            }
            else if (isJumping)
            {
                currentState = new JumpingState(gameObject, isJumping, jumpForce);
                isJumping = false;
                input = KeyCode.Space;
            }
        }

        currentState.HandleState(input);
    }

    private void OnColliderEnter2D(Collider other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
        }
        else
            isJumping = true;
    }
}
