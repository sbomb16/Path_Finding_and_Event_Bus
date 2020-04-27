using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Separation : SteeringBehavior
{

    public Kinematics character;
    public GameObject target;

    public Kinematics[] avoid;

    public float maxAccel = 50f;
    public float threshold = 2f;
    public float decay = 3f;
    public float distance;
    float strength;

    public Vector3 direction;      

    public override SteeringOutput GetSteering()
    {

        SteeringOutput result = new SteeringOutput();

        if(avoid != null)
        {
            foreach (Kinematics c in avoid)
            {

                //Debug.Log(c);
                direction = character.transform.position - c.transform.position;
                distance = direction.magnitude;

                //Debug.Log(distance);

                if (distance < threshold)
                {

                    strength = Mathf.Max(decay / (distance * distance), maxAccel);

                    //Debug.Log(strength);

                    direction.Normalize();
                    result.linear += strength * direction;

                }
                else if (distance > threshold)
                {

                    strength = Mathf.Max(decay / (distance * distance), maxAccel);
                    //Debug.Log(strength);

                    direction.Normalize();

                    //Debug.Log(direction);
                    result.linear -= strength * direction;

                }
            }
        }
        else
        {
            direction = character.transform.position - target.transform.position;
            distance = direction.magnitude;

            //Debug.Log(distance);

            if (distance < threshold)
            {

                strength = Mathf.Min(decay / (distance * distance), maxAccel);

                Debug.Log(strength);

                direction.Normalize();
                result.linear += strength * direction;

            }
            else if (distance > threshold)
            {

                strength = Mathf.Min(decay / (distance * distance), maxAccel);

                direction.Normalize();

                Debug.Log(direction);
                result.linear -= strength * direction;

            }
        }

        return result;

    }
}
