using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpeed : MonoBehaviour
{
    public float Speed = 4;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Simply adds more speed for the infinite level to move faster.
        Speed += Time.deltaTime * 1;
	}
}
