using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public float TargetSpeed = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //This allows the Camera's pivot to target the player smoothly.
        transform.position = Vector3.Lerp(transform.position, Target.position, Time.deltaTime * TargetSpeed);
    }
}
