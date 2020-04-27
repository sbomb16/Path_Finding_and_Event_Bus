using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackwardsPlayerState : IPlayerStates
{

    public void Enter(Player player)
    {
        Debug.Log("Entered Moving Backwards");
        player.mCurrentState = this;
    }

    public void Execute(Player player)
    {
        Rigidbody rbPlayer = player.GetComponent<Rigidbody>();
        rbPlayer.AddForce(0, 0, -10);

        if (!Input.GetKey(KeyCode.S))
        {
            StandingPlayerState standingState = new StandingPlayerState();
            standingState.Enter(player);
        }

        if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            MoveDiagonalLeftBackwardsPlayerState movingLeftBackwards = new MoveDiagonalLeftBackwardsPlayerState();
            movingLeftBackwards.Enter(player);
        }

        if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            MoveDiagonalRightBackwardsPlayerState movingRightBackwards = new MoveDiagonalRightBackwardsPlayerState();
            movingRightBackwards.Enter(player);
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
