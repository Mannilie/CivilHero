using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public GameObject Player_Stats_Data_Sync;
    public bool Found;
    public bool Score;
    public bool Score_Lose;
    public bool Best;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Simply displays our player stats data to this current gameObject's text.
        if (Found == false)
        {
            if (GameObject.Find("Player_Stats_Data_Sync"))
            {
                Player_Stats_Data_Sync = GameObject.Find("Player_Stats_Data_Sync");
                Found = true;
            }
        }

        if (Player_Stats_Data_Sync != null)
        {
            if (Score == true)
            {
                gameObject.GetComponent<Text>().text = "Score: " + Player_Stats_Data_Sync.GetComponent<PlayerStats>().Score.ToString("F0");
            }

            if (Score_Lose == true)
            {
                gameObject.GetComponent<Text>().text = "" + Player_Stats_Data_Sync.GetComponent<PlayerStats>().Score.ToString("F0");
            }

            if (Best == true)
            {
                gameObject.GetComponent<Text>().text = "" + Player_Stats_Data_Sync.GetComponent<PlayerStats>().Best.ToString("F0");
            }
        }
    }
}
