using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public GameObject Root;
    public GameObject Infinite_Level;
    public GameObject Portal_Level;
    public Transform Spawn_Level;
    public bool StartDeleteTime;
    public float DeleteTime = 20;
    public bool NatureLevel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //This gets rid of the old infinite level
		if(StartDeleteTime == true)
        {
            if(DeleteTime < 0)
            {
                Destroy(Root);
            }
            else
            {
                DeleteTime -= Time.deltaTime;
            }
        }
	}

    void OnTriggerEnter(Collider Col)
    {
        //This instantiates a new level once the player has entered our trigger.
        if(Col.gameObject.tag == "Player")
        {
            if (NatureLevel == true)
            {
                GameObject.Find("Player_Stats_Data_Sync").GetComponent<PlayerStats>().Spawns += 1;
                if (GameObject.Find("Player_Stats_Data_Sync").GetComponent<PlayerStats>().Spawns == 3)
                {
                    GameObject Infinite_Level_Clone = Instantiate(Portal_Level, Spawn_Level.position, Spawn_Level.rotation);
                }
                else
                {
                    GameObject Infinite_Level_Clone = Instantiate(Infinite_Level, Spawn_Level.position, Spawn_Level.rotation);
                }
            }
            else
            {
                GameObject Infinite_Level_Clone = Instantiate(Infinite_Level, Spawn_Level.position, Spawn_Level.rotation);
            }
            DeleteTime = 20;
            StartDeleteTime = true;

        }
    }
}
