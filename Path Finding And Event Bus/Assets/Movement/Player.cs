using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public IPlayerStates mCurrentState;
    public bool onGround = false;

	// Use this for initialization
	void Start () {
        mCurrentState = new StandingPlayerState();
	}

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag.ToString() == "Platform")
        {
            onGround = true;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if(collision.collider.tag.ToString() == "Platform")
        {
            onGround = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        mCurrentState.Execute(this);
	}
}
