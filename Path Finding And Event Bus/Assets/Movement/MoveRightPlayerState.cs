using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRightPlayerState : IPlayerStates
{

    public void Enter(Player player)
    {
        Debug.Log("Entered Moving Right");
        player.mCurrentState = this;
    }

    public void Execute(Player player)
    {
        Rigidbody rbPlayer = player.GetComponent<Rigidbody>();
        rbPlayer.AddForce(10, 0, 0);

        if (!Input.GetKey(KeyCode.D))
        {
            StandingPlayerState standingState = new StandingPlayerState();
            standingState.Enter(player);
        }
        if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            MoveDiagonalRightForwardPlayerState movingForwardRight = new MoveDiagonalRightForwardPlayerState();
            movingForwardRight.Enter(player);
        }
        if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            MoveDiagonalRightBackwardsPlayerState movingBackwardsRight = new MoveDiagonalRightBackwardsPlayerState();
            movingBackwardsRight.Enter(player);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            // transition to ducking
            DuckingPlayerState duckingState = new DuckingPlayerState();
            duckingState.Enter(player);

        }

        if (Input.GetKey(KeyCode.Space) && player.onGround == true)
        {
            JumpingPlayerState jumpingState = new JumpingPlayerState();
            jumpingState.Enter(player);
        }
    }
}
