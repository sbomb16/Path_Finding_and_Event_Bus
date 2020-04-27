using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpPlayerState : IPlayerStates
{

    public void Enter(Player player)
    {
        Debug.Log("Entered Double Jumping");
        player.mCurrentState = this;

        Rigidbody rbPlayer = player.GetComponent<Rigidbody>();
        rbPlayer.AddForce(0, 10, 0, ForceMode.VelocityChange);
    }

    public void Execute(Player player)
    {
        if (player.onGround == true)
        {
            // transition to ducking
            StandingPlayerState standingState = new StandingPlayerState();

            Rigidbody rbPlayer = player.GetComponent<Rigidbody>();
            rbPlayer.transform.localScale = new Vector3(1, 1f, 1);

            standingState.Enter(player);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            DivingPlayerState divingState = new DivingPlayerState();
            divingState.Enter(player);
        }
    }
}
