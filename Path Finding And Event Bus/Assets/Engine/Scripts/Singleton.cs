﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T mInstance;
    public static bool mIsQuitting;

    public static T Instance
    {
        get
        {
            if(mInstance == null)
            {
                mInstance = FindObjectOfType<T>();

                if(mInstance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    mInstance = obj.AddComponent<T>();
                }
            }
            return mInstance;
        }
    }

    public virtual void Awake()
    {
        if(mInstance == null)
        {
            mInstance = this as T;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
