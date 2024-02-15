using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTime : MonoBehaviour
{
    public float TimeToDelete = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Simply deletes this gameobject for performance
		if(TimeToDelete < 0)
        {
            Destroy(gameObject);
        }
        else
        {
            TimeToDelete -= Time.deltaTime;
        }
	}
}
