using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour {

    public GameObject mouse;

    public float xMin = -25f;
    public float xMax = 25f;

    public float yMin = 5f;
    public float yMax = 1f;

    public float zMin = -10f;
    public float zMax = 20f;

    float newX;
    float newY;
    float newZ;

	// Use this for initialization
	void Start () {

        NewMousePos(mouse);

	}

    public void NewMousePos(GameObject mgMouse)
    {
        newX = Random.Range(xMin, xMax);
        newY = Random.Range(yMin, yMax);
        newZ = Random.Range(zMin, zMax);

        mgMouse.gameObject.transform.position = new Vector3(newX, newY, newZ);
    }
	
	
}
