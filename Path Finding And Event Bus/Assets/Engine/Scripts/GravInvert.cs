using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravInvert : MonoBehaviour {

    private bool mIsQuitting;
    //public Rigidbody rb;
    public float invertGrav = -1f;
    public float currGrav = -9.8f;

    private void OnEnable()
    {
        EventBus.StartListening("inverse", InverseGrav);
    }

    private void OnApplicationQuit()
    {
        mIsQuitting = true;
    }

    private void OnDisable()
    {
        if (mIsQuitting == false)
        {
            EventBus.EndListening("inverse", InverseGrav);
        }
    }

    void InverseGrav()
    {
        currGrav *= invertGrav;
        Physics.gravity = new Vector3(0, currGrav, 0);
        Debug.Log("Gravity Inversed!");
    }
}
