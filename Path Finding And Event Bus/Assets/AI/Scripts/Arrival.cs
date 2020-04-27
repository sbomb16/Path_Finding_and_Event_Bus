using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrival : SteeringBehavior{

    public Kinematics character;
    public GameObject target;

    public float maxAccel;
    public float maxSpeed;

    public float targetRad;
    public float slowRad;

    public float timeToTarget = .01f;

    public Vector3 direction;
    public float distance;

    public override SteeringOutput GetSteering()
    {
        SteeringOutput result = new SteeringOutput();

        direction = target.transform.position - character.transform.position;

        distance = direction.magnitude;

         if(distance < targetRad)
        {
            character.linearVel = Vector3.zero;
            character.angularVel = 0;
            return null;
        }

        float targetSpeed = 0f;
        if (distance > slowRad)
        {
            targetSpeed = maxSpeed;
        }
        else
        {
            targetSpeed = maxSpeed * (distance - targetRad) / targetRad;
        }

        Vector3 targetVelocity = direction;
        targetVelocity.Normalize();
        targetVelocity *= targetSpeed;

        result.linear = targetVelocity - character.linearVel;
        result.linear /= timeToTarget;

        if(result.linear.magnitude > maxAccel)
        {
            result.linear.Normalize();
            result.linear *= maxAccel;
        }

        //result.angular = 0;
        return result;
    }
}
