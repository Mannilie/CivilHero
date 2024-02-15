using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardActivator : MonoBehaviour
{
    public int WhichHazard;
    public GameObject[] Hazards;
	// Use this for initialization
	void Start ()
    {
        //Randomizes the bins on the start function each time the new Infinite level object is instantiated.
        WhichHazard = Random.Range(0, 3);
        if(WhichHazard == 0)
        {
            Hazards[0].SetActive(true);
            Hazards[1].SetActive(false);
            Hazards[2].SetActive(false);
        }
        if (WhichHazard == 1)
        {
            Hazards[0].SetActive(false);
            Hazards[1].SetActive(true);
            Hazards[2].SetActive(false);
        }
        if (WhichHazard == 2)
        {
            Hazards[0].SetActive(false);
            Hazards[1].SetActive(false);
            Hazards[2].SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
