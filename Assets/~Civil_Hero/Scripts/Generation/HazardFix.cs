using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardFix : MonoBehaviour
{
    public GameObject[] Hazards;
	// Use this for initialization
	void Start ()
    {
        //Prevents a bug where if the player where to destroy a bin, it would appear destroyed on the next infinite level.
        Hazards[0].SetActive(true);
        Hazards[1].SetActive(true);
        Hazards[2].SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
