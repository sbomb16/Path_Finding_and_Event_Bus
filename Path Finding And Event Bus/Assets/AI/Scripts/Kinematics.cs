using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kinematics : MonoBehaviour {

    // Position comes from attached gameobject
    // Rotation as well
    public Vector3 linearVel;
    public float angularVel; // Degrees

    public GameObject aiTarget;
    public Kinematics kinTarget;
    public GameObject[] aiTargets;
    public Kinematics[] kinTargets;

    public Kinematics[] avoidance;

    //GameObject[] myPath;

    public float maxSpeed;
    public float angVelMax;

    public float maxAccel;
    public float maxRot;

    public float targetRad;
    public float slowRad;

    public float threshold;
    public float decay;

    public bool flee;

    public float fleeX = 5f;
    public float fleeZ = 5f;

    public string movementType;

    public Vector3 angularInc;

    public Node start;

    public Node goal;

    Graph myGraph;

    //Align aligning;

    // Align looking;

    SteeringOutput moving;
    SteeringOutput turning;
    public SteeringOutput movement;

    Seek_And_Flee seeking;
    Arrival arrive;
    Face facing;
    Path_Follow pathFollow;
    Look_Where_Going looky;
    Align aligned;
    Separation separate;
    Pursue pursuing;
    CollisionAvoidance avoid;
    Obstacle_Avoidance obstacles;
    Blended_Steering flocking;
    //Pathfinder finding;

    public BehaviorAndWeight[] behaviors; 

    // Use this for initialization
    void Start () {

        arrive = new Arrival();
        aligned = new Align();
        looky = new Look_Where_Going();
        facing = new Face();
        pathFollow = new Path_Follow();
        seeking = new Seek_And_Flee();
        separate = new Separation();
        pursuing = new Pursue();
        avoid = new CollisionAvoidance();
        obstacles = new Obstacle_Avoidance();
        flocking = new Blended_Steering();
        //finding = new Pathfinder();

        behaviors = new BehaviorAndWeight[4];


        Graph myGraph = new Graph();

        myGraph.Build();

        List<Connection> path = Dijkstra.pathfind(myGraph, start, goal);

        // path is a list of connections - convert this to gameobjects for the FollowPath steering behavior

        aiTargets = new GameObject[path.Count + 1];

        int i = 0;

        foreach (Connection c in path)

        {

            Debug.Log("from " + c.getFromNode() + " to " + c.getToNode() + " @" + c.getCost());

            aiTargets[i] = c.getFromNode().gameObject;

            i++;

        }

        aiTargets[i] = goal.gameObject;

    }
	
	// Update is called once per frame
	void Update () {

        if (float.IsNaN(angularVel))
        {
            angularVel = 0.0f;
        }

        SteeringOutput moving = new SteeringOutput();
        SteeringOutput turning = new SteeringOutput();

        seeking.character = this;
        seeking.target = aiTarget;

        SteeringOutput movement = new SteeringOutput();

        switch (movementType)
        {
            case "Seek":
                moving = seeking.GetSteering();

                if (moving == null)
                {
                    movement.linear = Vector3.zero;
                }
                else
                {
                    movement.linear = moving.linear;
                    movement.angular = turning.angular;
                }

                break;

            case "Flee":
                flee = true;

                moving = seeking.GetSteering();

                if (moving == null)
                {
                    movement.linear = Vector3.zero;
                }
                else
                {
                    movement.linear = moving.linear;
                    movement.angular = turning.angular;
                }

                break;

            case "Arrive":
                moving = arrive.GetSteering();

                if (moving == null)
                {
                    movement.linear = Vector3.zero;
                }
                else
                {
                    movement.linear = moving.linear;
                    movement.angular = turning.angular;
                }

                break;

            case "Face":

                facing.target = aiTarget;
                facing.character = this;

                //moving = seeking.GetSteering();
                turning = facing.GetSteering();

                movement.linear = Vector3.zero;
                movement.angular = turning.angular;

                break;

            case "Seek Align":                

                aligned.character = this;
                aligned.target = aiTarget;

                moving = seeking.GetSteering();
                turning = aligned.GetSteering();

                movement.linear = moving.linear;
                movement.angular = turning.angular;

                break;

            case "Seek Face":
                facing.character = this;
                facing.target = aiTarget;

                moving = seeking.GetSteering();
                turning = facing.GetSteering();

                if (moving == null)
                {
                    movement.linear = Vector3.zero;
                }
                else
                {
                    movement.linear = moving.linear;
                    movement.angular = turning.angular;
                }

                break;

            case "Seek Look":

                looky.character = this;
                looky.target = aiTarget;

                //Debug.Log(looky.GetSteering());
                if(looky.GetSteering() == null)
                {
                    moving = seeking.GetSteering();
                    movement.linear = moving.linear;
                    movement.angular = 0;
                }
                else
                {
                    moving = seeking.GetSteering();
                    turning = looky.GetSteering();

                    //Debug.Log(looky.GetSteering());

                    movement.linear = moving.linear;
                    movement.angular = turning.angular;
                }               

                break;

            case "Arrive Align":

                aligned.character = this;
                aligned.target = aiTarget;
                

                moving = arrive.GetSteering();
                turning = aligned.GetSteering();

                if (moving == null)
                {
                    movement.linear = Vector3.zero;
                }
                else
                {
                    movement.linear = moving.linear;
                    movement.angular = turning.angular;
                }

                break;

            case "Arrive Face":

                facing.character = this;
                facing.target = aiTarget;

                moving = arrive.GetSteering();
                turning = facing.GetSteering();

                movement.linear = moving.linear;
                movement.angular = turning.angular;

                break;

            case "Arrive Look":

                looky.character = this;
                //looky.target = aiTarget;

                arrive.character = this;
                arrive.target = aiTarget;                

                moving = arrive.GetSteering();
                turning = looky.GetSteering();

                movement.linear = moving.linear;
                movement.angular = turning.angular;

                Debug.Log(movement.angular);

                break;

            case "Path Follow":

                pathFollow.path = aiTargets;
                pathFollow.character = this;

                pathFollow.maxAccel = maxAccel;
                pathFollow.maxSpeed = maxSpeed;

                pathFollow.targetRad = targetRad;
                pathFollow.slowRad = slowRad;

                moving = pathFollow.GetSteering();

                movement.linear = moving.linear;

                break;

            case "Path Follow Face":
                
                pathFollow.path = aiTargets;
                pathFollow.character = this;

                pathFollow.maxAccel = maxAccel;
                pathFollow.maxSpeed = maxSpeed;

                pathFollow.targetRad = targetRad;
                pathFollow.slowRad = slowRad;

                moving = pathFollow.GetSteering();

                aiTarget = pathFollow.target;

                facing.character = this;
                facing.target = aiTarget;

                turning = facing.GetSteering();

                movement.linear = moving.linear;
                movement.angular = turning.angular;

                break;

            case "Separate":

                separate.character = this;
                separate.avoid = kinTargets;

                separate.threshold = threshold;
                separate.decay = decay;

                //separate.avoid = avoidance;

                moving = separate.GetSteering();

                movement.linear = moving.linear;
                movement.angular = 0;

                break;

            case "Pursue":

                pursuing.character = this;
                pursuing.target = aiTarget;

                moving = pursuing.GetSteering();

                movement.linear = moving.linear;
                movement.angular = 0;

                break;

            case "Avoidance":
                avoid.character = this;
                avoid.targets = kinTargets;

                kinTarget = avoid.firstTarget;

                moving = avoid.GetSteering();
                
                movement.linear = moving.linear;
                
                movement.angular = 0;                

                break;

            case "Obstacles":

                obstacles.character = this;
                //obstacles.target = aiTarget;

                looky.character = this;
                looky.target = obstacles.target;

                moving = obstacles.GetSteering();
                turning = looky.GetSteering();

                movement.linear = moving.linear;
                movement.angular = turning.angular;

                break;

            case "Flocking":

                arrive.character = this;
                arrive.target = aiTarget;

                arrive.maxAccel = maxAccel;
                arrive.maxSpeed = maxSpeed;

                arrive.targetRad = targetRad;
                arrive.slowRad = slowRad;

                looky.character = this;

                obstacles.character = this;

                separate.character = this;
                separate.avoid = kinTargets;

                separate.threshold = threshold;
                separate.decay = decay;

                behaviors[0] = new BehaviorAndWeight();

                behaviors[0].behavior = arrive;
                behaviors[0].weight = 35f;

                behaviors[1] = new BehaviorAndWeight();

                behaviors[1].behavior = separate;
                behaviors[1].weight = 1f;

                behaviors[2] = new BehaviorAndWeight();

                behaviors[2].behavior = looky;
                behaviors[2].weight = 50f;

                behaviors[3] = new BehaviorAndWeight();

                behaviors[3].behavior = obstacles;
                behaviors[3].weight = 10f;

                flocking.behaviors = behaviors;

                flocking.maxAccel = maxAccel;
                flocking.maxRotation = maxRot;

                moving = flocking.GetSteering();

                movement.linear = moving.linear;
                movement.angular = moving.angular;

                break;

            case "Path Finding":

                looky.character = this;
                pathFollow.character = this;

                pathFollow.slowRad = slowRad;
                pathFollow.targetRad = targetRad;

                pathFollow.path = aiTargets;

                pathFollow.maxAccel = maxAccel;
                pathFollow.maxSpeed = maxSpeed;

                pathFollow.character = this;                

                moving = pathFollow.GetSteering();

                movement.linear = moving.linear;
                movement.angular = moving.angular;

                break;

            default:

                facing.character = this;
                facing.target = aiTarget;
                

                moving = seeking.GetSteering();
                turning = aligned.GetSteering();

                if (moving == null)
                {
                    movement.linear = Vector3.zero;
                }
                else
                {
                    movement.linear = moving.linear;
                    movement.angular = turning.angular;
                }

                break;

        }

        // Update linear and angular velocities
        
        //Debug.Log(movement.angular);

        linearVel += movement.linear * Time.deltaTime;
        angularVel += movement.angular * Time.deltaTime;

        //angularInc *= Mathf.Rad2Deg;

        transform.position += linearVel * Time.deltaTime * maxSpeed;        

        angularInc = new Vector3(0, angularVel * Time.deltaTime * angVelMax, 0);
        //Debug.Log(angularInc)

        

        if(!float.IsNaN(angularInc.y))
        {
            transform.eulerAngles += angularInc;
        }

        //Debug.Log(linearVel);

        if (linearVel.magnitude > maxSpeed) 
        {

            linearVel.Normalize();
            linearVel *= maxSpeed;

        }

    }
}
