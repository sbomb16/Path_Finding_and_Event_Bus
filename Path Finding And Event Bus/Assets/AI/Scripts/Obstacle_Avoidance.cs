using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Avoidance : SteeringBehavior
{

    public Kinematics character;

    public GameObject target;

    public float avoidDistance = 5f;

    public float lookAhead = 5f;

    public Vector3 ray;

    //public Kinematics character;
    //public GameObject targetFound;    

	public override SteeringOutput GetSteering()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(character.transform.position, character.transform.TransformDirection(Vector3.forward), out hit, avoidDistance, layerMask))
        {
            //Debug.DrawRay(character.transform.position, character.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
            target = hit.collider.gameObject;
        }
        else
        {
            Debug.DrawRay(character.transform.position, character.transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            //Debug.Log("Did not Hit");
        }

        SteeringOutput result = new SteeringOutput();

        if (!target)
        {
            //Debug.Log("Oops");
            result.linear = Vector3.zero;
            result.angular = 0;
            return result;
        }

        float dotResult = Vector3.Dot(character.linearVel.normalized, target.transform.position);

        //Debug.Log(dotResult);

        if (dotResult < -0.9 && dotResult > -1.1)
        {
            result.linear = -target.transform.right * 3;
            //result.angular = -5;
        }
        else
        {
            result.linear = target.transform.right * 3;
            //result.angular = 5;
        }

        return result;

    }
}
