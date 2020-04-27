using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek_And_Flee : SteeringBehavior
{
    public Kinematics character;
    public GameObject target;

    public Vector3 newPos;

    public Vector3 stayAway;

    void Start()
    {
        //stayAway = new Vector3(character.fleeX, 0, character.fleeZ);
    }    

    public override SteeringOutput GetSteering()
    {

        //Debug.Log(target);

        //newPos = target.transform.position - character.transform.position;

        SteeringOutput result = new SteeringOutput();

        if(character.flee == true)
        {
            // Get direction away from target
            result.linear = character.transform.position - target.transform.position;

            result.linear.Normalize();
            result.linear *= character.maxSpeed;

            return result;
        }
        else
        {
            Debug.Log(target);
            // Get direction to target
            result.linear = target.transform.position - character.transform.position;

            //result.linear.Normalize();
            //result.linear *= character.maxSpeed;           

            return result;
        }        
    }
}
