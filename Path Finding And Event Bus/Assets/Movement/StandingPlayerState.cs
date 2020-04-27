using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingPlayerState : IPlayerStates {

	public void Enter(Player player)
    {
        Debug.Log("Entered Standing");
        player.mCurrentState = this;
    }

   public void Execute(Player player)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            // transition to ducking
            DuckingPlayerState duckingState = new DuckingPlayerState();
            duckingState.Enter(player);
        }

        if (Input.GetKey(KeyCode.W))
        {
            MoveForwardPlayerState movingForward = new MoveForwardPlayerState();
            movingForward.Enter(player);
        }

        if (Input.GetKey(KeyCode.S))
        {
            MoveBackwardsPlayerState movingBackwards = new MoveBackwardsPlayerState();
            movingBackwards.Enter(player);
        }

        if (Input.GetKey(KeyCode.D))
        {
            MoveRightPlayerState movingRight = new MoveRightPlayerState();
            movingRight.Enter(player);
        }

        if (Input.GetKey(KeyCode.A))
        {
            MoveLeftPlayerState movingLeft = new MoveLeftPlayerState();
            movingLeft.Enter(player);
        }

        if (Input.GetKey(KeyCode.Space) && player.onGround == true)
        {
            //player.onGround = false;
            JumpingPlayerState jumpingState = new JumpingPlayerState();
            jumpingState.Enter(player);
        }
    }
}
