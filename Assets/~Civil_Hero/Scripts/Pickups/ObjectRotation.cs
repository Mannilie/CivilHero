using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour 
{
    public float RotateValue;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //This allows the pickup to simply rotate in a stable manner which is to use Quaternion.
        RotateValue -= Time.deltaTime * 350;
        transform.rotation = Quaternion.Euler(0, RotateValue, 0);
	}
}
