using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutInMag : MonoBehaviour {

    private bool mIsQuitting;
    private bool goUp = false;
    private bool finish = false;
    public GameObject ammoDrum;

    private void OnEnable()
    {
        EventBus.StartListening("reload", ReplaceMag);
    }

    private void OnApplicationQuit()
    {
        mIsQuitting = true;
    }

    private void OnDisable()
    {
        if (mIsQuitting == false)
        {
            EventBus.EndListening("reload", ReplaceMag);
        }
    }

    void ReplaceMag()
    {
        
        ammoDrum.transform.localPosition = new Vector3(4, -10, -5);
                      
    }
}
