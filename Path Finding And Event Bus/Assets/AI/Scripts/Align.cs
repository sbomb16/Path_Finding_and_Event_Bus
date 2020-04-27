using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Align : SteeringBehavior {

    public Kinematics character;
    public GameObject target;

    public float maxAngularAccel = 100f;
    public float maxRotation = 45f;

    public float targetRad = 1f;
    public float slowRad = 10f;

    public float timeToTarget = 0.1f;

    public float rotation;
    public float rotationSize;

    public float angularAccel;

    public override SteeringOutput GetSteering()
    {
        SteeringOutput result = new SteeringOutput();

        if (!target)
        {

            //result.angular = 0;
            //result.linear = Vector3.zero;
            return result;

        }
        else
        {

            rotation = Mathf.DeltaAngle(character.transform.rotation.eulerAngles.y, target.transform.rotation.eulerAngles.y);
            rotationSize = Mathf.Abs(rotation);

            float targetRotation = 0.0f;

            if (rotationSize > slowRad)
            {
                targetRotation = maxRotation;
            }

            else
            {
                targetRotation = maxRotation * rotationSize / slowRad;
            }

            targetRotation *= rotation / rotationSize;

            float currentAngularVelocity = float.IsNaN(character.angularVel) ? 0f : character.angularVel;

            result.angular = targetRotation - currentAngularVelocity;
            result.angular /= timeToTarget;

            angularAccel = Mathf.Abs(result.angular);

            if (angularAccel > maxAngularAccel)
            {
                result.angular /= angularAccel;
                result.angular *= maxAngularAccel;
            }

            result.linear = Vector3.zero;

            return result;

        }
    }
}
