using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftPlayerState : IPlayerStates
{

    public void Enter(Player player)
    {
        Debug.Log("Entered Moving Left");
        player.mCurrentState = this;
    }

    public void Execute(Player player)
    {
        Rigidbody rbPlayer = player.GetComponent<Rigidbody>();
        rbPlayer.AddForce(-10, 0, 0);

        if (!Input.GetKey(KeyCode.A))
        {
            StandingPlayerState standingState = new StandingPlayerState();
            standingState.Enter(player);
        }

        if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            MoveDiagonalLeftForwardPlayerState movingDiagonalLeftForward = new MoveDiagonalLeftForwardPlayerState();
            movingDiagonalLeftForward.Enter(player);
        }
        if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            MoveDiagonalLeftBackwardsPlayerState movingBackwardsLeft = new MoveDiagonalLeftBackwardsPlayerState();
            movingBackwardsLeft.Enter(player);
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
