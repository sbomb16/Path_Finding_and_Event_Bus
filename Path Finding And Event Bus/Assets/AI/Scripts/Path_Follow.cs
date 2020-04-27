using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path_Follow : Arrival
{

    public GameObject[] path;
    //public GameObject[] path2;

    float targetChangeRad = 2f;
    public int currTarIndex;
    bool reverse = false;

    int randTarget;
    //public bool reset = true;

    void Start()
    {
        //ReversePath();
    }

    public override SteeringOutput GetSteering()
    {
        
        if (target == null)
        {
            //Debug.Log(currTarIndex);
            currTarIndex = 0;
            target = path[0];
        }
        

        Debug.Log(currTarIndex);
        //Debug.Log(target);
        //Debug.Log(path[0]);

        Vector3 vectToTarget = target.transform.position - character.transform.position;
        float distToTarget = vectToTarget.magnitude;

        //Debug.Log(distToTarget);
        if(distToTarget < targetChangeRad && reverse == true)
        {
            currTarIndex--;
            if (currTarIndex <= 0)
            {
                Debug.Log("I shouldnt be in here yet");
                currTarIndex = 0;
                reverse = false;
            }
        }
        else if (distToTarget < targetChangeRad && reverse == false)
        {
            currTarIndex++;

            if (currTarIndex > path.Length - 1)
            {
                Debug.Log("I shouldnt be in here yet");
                currTarIndex--;
                reverse = true;                
            }
        }
        //else
        //{
        //    currTarIndex--;
        //    if (currTarIndex <= 0)
        //    {
        //        Debug.Log("I shouldnt be in here yet");
        //        currTarIndex = 1;
        //        reverse = false;
        //    }
        //}

        target = path[currTarIndex];

        //Debug.Log(target);

        return base.GetSteering();

    }

    //public void ReversePath()
    //{
    //    int counter = path.Length;
    //    for(int i = 0; i < counter; i++)
    //    {
    //        path2[i] = path[counter];
    //        counter--;
    //    }
    //}
}
