using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour {

    public GameObject mouse;

    private float launchForce;
    public bool launched = false;

    Rigidbody rigid;
    public Kinematics kin;

    void Launch()
    {

        if(launched == false)
        {
            launched = true;

            rigid = GetComponent<Rigidbody>();

            CalculatedFiring calcFire = new CalculatedFiring();

            Vector3 targetVect = calcFire.CalculateFiringSolution(transform.position, mouse.transform.position, launchForce, Physics.gravity);

            if (targetVect != Vector3.zero)
            {

                rigid.AddForce(targetVect.normalized * launchForce, ForceMode.VelocityChange);

            }
        }      
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Side1" && launched == false)
        {
            kin.enabled = false;
            launchForce = 15;
            Debug.Log("Attempted to launch!");
            mouse = GameObject.Find("Path4");
            Launch();
            Invoke("ResetLaunched", 3);
        }
        else if (other.tag == "Side2" && launched == false)
        {
            kin.enabled = false;
            launchForce = 15;
            Debug.Log("Attempted to launch!");
            mouse = GameObject.Find("Path2");
            Launch();
            Invoke("ResetLaunched", 3);
        }
        else if (other.tag == "Side3" && launched == false)
        {
            kin.enabled = false;
            launchForce = 15;
            Debug.Log("Attempted to launch!");
            mouse = GameObject.Find("Path7");
            Launch();
            Invoke("ResetLaunched", 3);
        }
        else if (other.tag == "Side4" && launched == false)
        {
            kin.enabled = false;
            launchForce = 15;
            Debug.Log("Attempted to launch!");
            mouse = GameObject.Find("Path6");
            Launch();
            Invoke("ResetLaunched", 3);
        }
        else if(other.tag == "Side1" || other.tag == "Side2" && launched == true)
        {
            Debug.Log("Can't re-launch!");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Platform")
        {
            kin.enabled = true;            
        }
    }

    void ResetLaunched()
    {
        launched = false;
    }
}