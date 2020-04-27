using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDiagonalLeftForwardPlayerState : IPlayerStates
{

    public void Enter(Player player)
    {
        Debug.Log("Entered Moving Diagonal Forward Left");
        player.mCurrentState = this;
    }

    public void Execute(Player player)
    {
        Rigidbody rbPlayer = player.GetComponent<Rigidbody>();
        rbPlayer.AddForce(-10, 0, 10);

        if (!Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W)){

            MoveForwardPlayerState movingForward = new MoveForwardPlayerState();
            movingForward.Enter(player);
        }

        if (!Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)){

            MoveLeftPlayerState movingLeft = new MoveLeftPlayerState();
            movingLeft.Enter(player);
        }

        if(!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A))
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
