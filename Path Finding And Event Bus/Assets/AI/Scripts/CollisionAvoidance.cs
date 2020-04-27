using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAvoidance
{
    public Kinematics character;
    public float maxAccel = 5f;

    public Kinematics[] targets;

    public float radius = .1f;

    public Kinematics firstTarget;   

    public float shortestTime;
    public float relativeSpeed;
    public float timeToCollision;
    public float distance;
    public float minSeparation;

    public float firstMinSeparation;
    public float firstDist;

    public Vector3 firstRelativePos;
    public Vector3 firstRelativeVel;

    public Vector3 relativePos;
    public Vector3 relativeVel;

    public virtual SteeringOutput GetSteering()
    {
        shortestTime = float.PositiveInfinity;

        //firstTarget = null;
        
        foreach (Kinematics target in targets)
        {
            relativePos = target.transform.position - character.transform.position;
            relativeVel = character.linearVel - target.linearVel;

            relativeSpeed = relativeVel.magnitude;
            timeToCollision = Vector3.Dot(relativePos, relativeVel) / (relativeSpeed * relativeSpeed);

            distance = relativePos.magnitude;
            minSeparation = distance - relativeSpeed * timeToCollision;

            if(minSeparation > 2 * radius)
            {
                //Debug.Log("1");
                continue;

            }
            else if(timeToCollision > 0 && timeToCollision < shortestTime)
            {

                shortestTime = timeToCollision;

                firstTarget = target;
                firstMinSeparation = minSeparation;
                firstDist = distance;
                firstRelativePos = relativePos;
                firstRelativeVel = relativeVel;
                //Debug.Log(2);
            }
        }

        //if(firstMinSeparation <= 0 || firstDist < 2 * radius)
        //{
        //    relativePos = firstTarget.transform.position - character.transform.position;
        //}
        //else
        //{
        //    relativePos = firstRelativePos + firstRelativeVel * shortestTime;
        //}

        SteeringOutput result = new SteeringOutput();

        if (!firstTarget)
        {
            Debug.Log("Oops");
            result.linear = Vector3.zero;
            result.angular = 0;
            return result;
        }

        float dotResult = Vector3.Dot(character.linearVel.normalized, firstTarget.linearVel.normalized);

        if (dotResult < -0.9 && dotResult > -1.1)
        {
            result.linear = -firstTarget.transform.right;
        }
        else
        {
            result.linear = -firstTarget.linearVel;
        }

        //-target.linearVel;

        relativePos.Normalize(); 

        //result.linear = relativePos * maxAccel;
        result.angular = 0;
        return result;

        


    }
}
