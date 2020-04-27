using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursue : Seek_And_Flee {

    public Vector3 direction;
    public float distance;
    public float prediction;

    public float maxPrediction = 2f;
    
    public override SteeringOutput GetSteering()
    {
        direction = target.transform.position - character.transform.position;
        distance = direction.magnitude;

        float speed = character.linearVel.magnitude;

        if (speed <= distance / maxPrediction)
        {
            prediction = maxPrediction;
            
        }
        else
        {
            prediction = distance / speed;
        }

        //Debug.Log(speed);
        //Debug.Log(prediction);

        Kinematics myTarget = target.GetComponent(typeof(Kinematics)) as Kinematics;

        if(myTarget == null)
        {
            return base.GetSteering();
        }
        else
        {
            target.transform.position += myTarget.linearVel * prediction;

            return base.GetSteering();
        }        
    }


	
}
