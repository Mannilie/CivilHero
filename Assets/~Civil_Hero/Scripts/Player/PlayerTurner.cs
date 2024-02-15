using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurner : MonoBehaviour
{
    public GameObject PLAYER_INPUT;
    public Transform Player_Turn_Initial;
    public Transform Player_Turn_Left;
    public Transform Player_Turn_Right;
    public float TurnSpeed = 10;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Gives the player more of a feel that we're skating left and right
		if(PLAYER_INPUT.GetComponent<PlayerInput>().MovingLeft == true || PLAYER_INPUT.GetComponent<PlayerInput>().MovingRight == true)
        {
            if(PLAYER_INPUT.GetComponent<PlayerInput>().MovingLeft == true)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Player_Turn_Left.rotation, Time.deltaTime * TurnSpeed);
            }

            if (PLAYER_INPUT.GetComponent<PlayerInput>().MovingRight == true)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Player_Turn_Right.rotation, Time.deltaTime * TurnSpeed);
            }
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Player_Turn_Initial.rotation, Time.deltaTime * TurnSpeed);
        }
	}
}
