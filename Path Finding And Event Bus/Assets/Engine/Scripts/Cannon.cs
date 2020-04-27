using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

    private bool mIsQuitting;
    public Rigidbody cannonBall;
    public Rigidbody rb;

    private void OnEnable()
    {
        EventBus.StartListening("shoot", ShootCannon);
    }

    private void OnApplicationQuit()
    {
        mIsQuitting = true;
    }

    private void OnDisable()
    {
        if(mIsQuitting == false)
        {
            EventBus.EndListening("shoot", ShootCannon);
        }
    }

    void ShootCannon()
    {
        Rigidbody cannonShot;        
        rb = gameObject.GetComponent<Rigidbody>();
        //rb.useGravity = true;
        // rb.AddForce(new Vector3(0, 500, 500));
        cannonShot = Instantiate(cannonBall, rb.transform);
        cannonShot.useGravity = true;
        cannonShot.AddForce(new Vector3(0, 0, 100000));
        Debug.Log("Shot the cannon!");
    }
}
