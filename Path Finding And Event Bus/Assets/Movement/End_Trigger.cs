using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End_Trigger : MonoBehaviour {

    float boysCollected;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag.ToString() == "Boy")
        {
            boysCollected++;
            Debug.Log(boysCollected);
        }
        if(boysCollected == 5)
        {
            SceneManager.LoadScene(4);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.tag.ToString() == "Boy")
        {
            boysCollected--;
        }
    }


}
