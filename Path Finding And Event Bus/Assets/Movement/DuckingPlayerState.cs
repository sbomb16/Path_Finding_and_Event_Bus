using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckingPlayerState : IPlayerStates {

	public void Enter(Player player)
    {
        Debug.Log("Entered Ducking");
        player.mCurrentState = this;

        Rigidbody rbPlayer = player.GetComponent<Rigidbody>();
        rbPlayer.transform.localScale = new Vector3(1, 0.5f, 1);
    }

    public void Execute(Player player)
    {
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            // transition to ducking
            StandingPlayerState standingState = new StandingPlayerState();

            Rigidbody rbPlayer = player.GetComponent<Rigidbody>();
            rbPlayer.transform.localScale = new Vector3(1, 1f, 1);

            standingState.Enter(player);           

        }
        if (Input.GetKey(KeyCode.Space))
        {
            JumpingPlayerState jumpingState = new JumpingPlayerState();

            Rigidbody rbPlayer = player.GetComponent<Rigidbody>();
            rbPlayer.transform.localScale = new Vector3(1, 1f, 1);

            jumpingState.Enter(player);
        }
    }
}
