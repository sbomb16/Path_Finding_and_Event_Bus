using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour {

    private bool mIsQuitting;
    private bool goUp = false;
    private bool finish = false;
    public GameObject ammoDrum;

    private void OnEnable()
    {
        EventBus.StartListening("takeout", ReloadGun);
    }

    private void OnApplicationQuit()
    {
        mIsQuitting = true;
    }

    private void OnDisable()
    {
        if (mIsQuitting == false)
        {
            EventBus.EndListening("takeout", ReloadGun);
        }
    }

    void ReloadGun()
    {
        
        ammoDrum.transform.localPosition = new Vector3(0, -30, 0);
                      
    }
}
