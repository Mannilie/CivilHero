using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int Score;
    public int Best;
    public int Spawns;
    // Use this for initialization
    void Start ()
    {
        //Syncs the player stats through out the game
        if (GameObject.Find("Player_Stats_Data_Sync"))
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.name = "Player_Stats_Data_Sync";
            DontDestroyOnLoad(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Score > Best)
        {
            Best = Score;
        }
    }
}
