using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
    public GameObject PLAYER_INPUT;
    public Transform Player_Pivot;
    public Transform Raycast_Left;
    public Transform Raycast_Right;
    public float Speed = 4;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Moves a raycast left and right by lerping so the main player pivot can be capped to where the ramp is.
		if(PLAYER_INPUT.GetComponent<PlayerInput>().MovingLeft == true || PLAYER_INPUT.GetComponent<PlayerInput>().MovingRight == true)
        {
            if(PLAYER_INPUT.GetComponent<PlayerInput>().MovingLeft == true)
            {
                transform.position = Vector3.Lerp(transform.position, Raycast_Left.position, Time.deltaTime * Speed);
            }

            if (PLAYER_INPUT.GetComponent<PlayerInput>().MovingRight == true)
            {
                transform.position = Vector3.Lerp(transform.position, Raycast_Right.position, Time.deltaTime * Speed);
            }
        }

        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.forward, out hit, 100))
        {
            Player_Pivot.position = hit.point;
            Player_Pivot.up = hit.normal;
        }
	}
}
