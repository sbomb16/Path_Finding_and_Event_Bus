using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardPlayerState : IPlayerStates
{    

    public void Enter(Player player)
    {
        Debug.Log("Entered Moving Forward");
        player.mCurrentState = this;        
    }

    public void Execute(Player player)
    {
        Rigidbody rbPlayer = player.GetComponent<Rigidbody>();
        rbPlayer.AddForce(0, 0, 10);

        if (!Input.GetKey(KeyCode.W))
        {
            StandingPlayerState standingState = new StandingPlayerState();
            standingState.Enter(player);
        }

        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            MoveDiagonalLeftForwardPlayerState movingForwardLeft = new MoveDiagonalLeftForwardPlayerState();
            movingForwardLeft.Enter(player);
        }

        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            MoveDiagonalRightForwardPlayerState movingForwardRight = new MoveDiagonalRightForwardPlayerState();
            movingForwardRight.Enter(player);
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
