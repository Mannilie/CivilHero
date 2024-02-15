using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMovement : MonoBehaviour
{
    public GameObject Player;
    public GameObject Level_Speed_Data;
	// Use this for initialization
	void Start ()
    {

        Player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Every infinite level that is instantiated moves backwards with the speed rate of a Level_Speed_Data object.
        Level_Speed_Data = GameObject.Find("Level_Speed_Data");
        if (Player.GetComponent<PlayerController>().PlayerDead == false)
        {
            transform.position -= new Vector3(0, 0, Time.deltaTime * Level_Speed_Data.GetComponent<LevelSpeed>().Speed);
        }
	}
}
