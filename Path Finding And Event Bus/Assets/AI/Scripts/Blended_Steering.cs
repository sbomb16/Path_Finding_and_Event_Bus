using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorAndWeight
{
    public SteeringBehavior behavior;
    public float weight;
}

public class Blended_Steering : SteeringBehavior {

    public BehaviorAndWeight[] behaviors;

    public float maxAccel = 50f;
    public float maxRotation = 30f;

    public override SteeringOutput GetSteering()
    {
        
        SteeringOutput result = new SteeringOutput();

        
        foreach(BehaviorAndWeight b in behaviors)
        {
            //Debug.Log(b.behavior);
            SteeringOutput s = b.behavior.GetSteering();
            if(s != null)
            {
                result.angular += s.angular * b.weight;
                result.linear += s.linear * b.weight;
            }            
        }

        result.linear = result.linear.normalized * Mathf.Min(maxAccel, result.linear.magnitude);
        float angularAcc = Mathf.Abs(result.angular);
        if(angularAcc > maxAccel)
        {
            result.angular /= angularAcc;
            result.angular *= maxRotation;
        }

        //crop result
        return result;
    }	
}
