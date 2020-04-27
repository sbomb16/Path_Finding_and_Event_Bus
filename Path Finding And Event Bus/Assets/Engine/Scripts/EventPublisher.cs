using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventPublisher : MonoBehaviour {

    public Text ammoText;

    int ammo = 300;

    bool sKeyIsDown = false;
    bool doRotate = false;
    bool reload = false;
    bool noNeed = false;

    void Shoot()
    {

        if (ammo > 0 && sKeyIsDown == true)
        {
            EventBus.TriggerEvent("shoot");
            ammo--;
            Invoke("Shoot", .01f);
        }
        else if(ammo <= 0 && sKeyIsDown == true)
        {
            reload = true;
            noNeed = true;
        }
        
    }
    void RotateBarrels()
    {
        if(doRotate == true)
        {
            EventBus.TriggerEvent("rotate");
            Invoke("RotateBarrels", .01f);
        }        
    }

    void TakeOutMag()
    {
        EventBus.TriggerEvent("takeout");
    }

    void PutMagIn()
    {
        EventBus.TriggerEvent("reload");
    }
    void ResetGun()
    {
        ammo = 300;
        reload = false;
        noNeed = false;
    }

    // Update is called once per frame
    void Update () {

        ammoText.text = ammo.ToString();

        if (Input.GetMouseButtonDown(1) && reload == false)
        {
            doRotate = true;
            sKeyIsDown = true;
            RotateBarrels();
            Debug.Log("Rotate ACTIVATE");
            
        }
        if (Input.GetMouseButtonDown(0) && doRotate == true && reload == false)
        {
            sKeyIsDown = true;
            Debug.Log("Here we are, shoot!");
            Shoot();
        }
        if (Input.GetMouseButtonDown(0) && doRotate == true && reload == true)
        {
            Debug.Log("You gotta reload!");
        }
        if (Input.GetMouseButtonUp(1))
        {
            doRotate = false;
            sKeyIsDown = false;
        }
        if (Input.GetMouseButtonUp(0) && reload == false)
        {
            sKeyIsDown = false;
        }

        if (Input.GetKey("r"))
        {
            reload = true;
            TakeOutMag();
            Invoke("PutMagIn", 3);
            Invoke("ResetGun", 3);
        }

        if (Input.GetKeyDown("w"))
        {
            EventBus.TriggerEvent("drop");
        }
        if (Input.GetKeyDown("g"))
        {
            EventBus.TriggerEvent("inverse");
        }
        if (Input.GetKeyDown("e"))
        {
            EventBus.TriggerEvent("expand");
        }
	}
}
