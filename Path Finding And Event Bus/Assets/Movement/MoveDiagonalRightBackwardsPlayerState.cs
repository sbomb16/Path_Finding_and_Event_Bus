using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDiagonalRightBackwardsPlayerState : IPlayerStates
{

    public void Enter(Player player)
    {
        Debug.Log("Entered Moving Diagonal Backwards Right");
        player.mCurrentState = this;
    }

    public void Execute(Player player)
    {
        Rigidbody rbPlayer = player.GetComponent<Rigidbody>();
        rbPlayer.AddForce(10, 0, -10);

        if (!Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            MoveRightPlayerState movingRight = new MoveRightPlayerState();
            movingRight.Enter(player);
        }

        if (!Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            MoveBackwardsPlayerState movingBackwards = new MoveBackwardsPlayerState();
            movingBackwards.Enter(player);
        }

        if(!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S))
        {
            StandingPlayerState standingState = new StandingPlayerState();
            standingState.Enter(player);
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
