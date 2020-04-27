using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anvil : MonoBehaviour {

    private bool mIsQuitting;
    public Rigidbody rb;

    private void OnEnable()
    {
        EventBus.StartListening("drop", DropAnvil);
    }

    private void OnApplicationQuit()
    {
        mIsQuitting = true;
    }

    private void OnDisable()
    {
        if (mIsQuitting == false)
        {
            EventBus.EndListening("drop", DropAnvil);
        }
    }

    void DropAnvil()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.useGravity = true;
        Debug.Log("Anvil Dropped!");
    }
}
