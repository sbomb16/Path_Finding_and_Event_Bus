using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivingPlayerState : IPlayerStates
{

    public void Enter(Player player)
    {
        Debug.Log("Entered Diving");
        player.mCurrentState = this;

        Rigidbody rbPlayer = player.GetComponent<Rigidbody>();
        Debug.Log(rbPlayer.velocity.normalized);
        if(rbPlayer.velocity.normalized.z == 0 && rbPlayer.velocity.normalized.x == 0)
        {
            Debug.Log("Diving Forward");
            rbPlayer.AddForce(0, 0, 10, ForceMode.VelocityChange);
        }
        if(rbPlayer.velocity.normalized.z > 0 && rbPlayer.velocity.normalized.x == 0)
        {
            Debug.Log("Diving Forward");
            rbPlayer.AddForce(0, 0, 10, ForceMode.VelocityChange);
        }
        if(rbPlayer.velocity.normalized.z < 0 && rbPlayer.velocity.normalized.x == 0)
        {
            Debug.Log("Diving Backwards");
            rbPlayer.AddForce(0, 0, -10, ForceMode.VelocityChange);
        }
        if(rbPlayer.velocity.normalized.x > 0 && rbPlayer.velocity.normalized.z == 0)
        {
            Debug.Log("Diving Right");
            rbPlayer.AddForce(10, 0, 0, ForceMode.VelocityChange);
        }
        if(rbPlayer.velocity.normalized.x < 0 && rbPlayer.velocity.normalized.z == 0)
        {
            Debug.Log("Diving Left");
            rbPlayer.AddForce(-10, 0, 0, ForceMode.VelocityChange);
        }
        if (rbPlayer.velocity.normalized.z > 0.05 && rbPlayer.velocity.normalized.x > .05)
        {
            Debug.Log("Diving Forward Right " + rbPlayer.velocity.normalized);
            rbPlayer.AddForce(5, 0, 5, ForceMode.VelocityChange);
        }
        if (rbPlayer.velocity.normalized.z > 0.05 && rbPlayer.velocity.normalized.x < -.05)
        {
            Debug.Log("Diving Forward Left " + rbPlayer.velocity.normalized);
            rbPlayer.AddForce(-5, 0, 5, ForceMode.VelocityChange);
        }
        if (rbPlayer.velocity.normalized.z < -.05 && rbPlayer.velocity.normalized.x > 0.05)
        {
            Debug.Log("Diving Backwards Right " + rbPlayer.velocity.normalized);
            rbPlayer.AddForce(5, 0, -5, ForceMode.VelocityChange);
        }
        if (rbPlayer.velocity.normalized.z < -.05 && rbPlayer.velocity.normalized.x < -.05)
        {
            Debug.Log("Diving Backwards Left " + rbPlayer.velocity.normalized);
            rbPlayer.AddForce(-5, 0, -5, ForceMode.VelocityChange);
        }
    }

    public void Execute(Player player)
    {
        if (player.onGround == true){
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                DuckingPlayerState duckingState = new DuckingPlayerState();
                duckingState.Enter(player);
            }
            else
            {
                StandingPlayerState standingState = new StandingPlayerState();
                standingState.Enter(player);
            }
        }
    }
}
