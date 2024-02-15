using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSync : MonoBehaviour 
{

	// Use this for initialization
	void Start ()
    {
        //This allows the gameobject to sync with all scenes as it can then be controlled with other scripts
        if (GameObject.Find("Audio_Sync_Main"))
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.name = "Audio_Sync_Main";
            DontDestroyOnLoad(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
