using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScore : MonoBehaviour
{
    public bool Found;
	// Use this for initialization
	void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Because all the data is synced, it always saves meaning that score would always need to reset each time you die while best is kept.
        if (Found == false)
        {
            if (GameObject.Find("Player_Stats_Data_Sync"))
            {
                GameObject.Find("Player_Stats_Data_Sync").GetComponent<PlayerStats>().Score = 0;
                Found = true;
            }
        }
    }
}
