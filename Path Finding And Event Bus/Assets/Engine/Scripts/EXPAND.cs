using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPAND : MonoBehaviour {

    private bool mIsQuitting;
    public GameObject rb;

    private void OnEnable()
    {
        EventBus.StartListening("expand", Expand);
    }

    private void OnApplicationQuit()
    {
        mIsQuitting = true;
    }

    private void OnDisable()
    {
        if (mIsQuitting == false)
        {
            EventBus.EndListening("expand", Expand);
        }
    }

    void Expand()
    {
        gameObject.transform.localScale += new Vector3(1, 1, 1);
        Debug.Log("EXPAND!");
    }
}
