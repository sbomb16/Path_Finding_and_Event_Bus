using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatedFiring
{
    public Vector3 CalculateFiringSolution(Vector3 start, Vector3 end, float muzzleVel, Vector3 gravity)
    {
        Vector3 delta = end - start;

        float a = gravity.sqrMagnitude;
        float b = -4 * (Vector3.Dot(gravity, delta) + muzzleVel * muzzleVel);
        float c = 4 * delta.sqrMagnitude;

        float b2minus4ac = (b * b) - (4 * (a * a));

        if (b2minus4ac < 0)
        {
            return Vector3.zero;
        }

        float time0 = Mathf.Sqrt((-b + Mathf.Sqrt(b2minus4ac)) / (2 * a));
        float time1 = Mathf.Sqrt((-b - Mathf.Sqrt(b2minus4ac)) / (2 * a));

        float ttt;
        if (time0 < 0)
        {
            if (time1 < 0)
            {
                return Vector3.zero;
            }
            else
            {
                ttt = time1;
            }
        }
        else
        {
            if (time1 < 0)
            {
                ttt = time0;
            }
            else
            {
                //ttt = (time1 + time0) / 2;
                ttt = Mathf.Max(time0, time1);
            }
        }
        Vector3 numerator = delta * 2 - gravity * (ttt * ttt);
        float denominator = 2 * muzzleVel * ttt;

        return numerator / denominator;

    }
}


