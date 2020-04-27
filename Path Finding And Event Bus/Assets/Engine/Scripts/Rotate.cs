using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private bool mIsQuitting;
    public GameObject barrels;

    private void OnEnable()
    {
        EventBus.StartListening("rotate", RotateBarrels);
    }

    private void OnApplicationQuit()
    {
        mIsQuitting = true;
    }

    private void OnDisable()
    {
        if (mIsQuitting == false)
        {
            EventBus.EndListening("rotate", RotateBarrels);
        }
    }

    void RotateBarrels()
    {
        barrels.transform.Rotate(new Vector3(0, 0, 10));
    }
}
