using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChance : MonoBehaviour
{
    public int Chance;
    public GameObject[] Items;
    // Use this for initialization
    void Start ()
    {
        //This allows an item that is already in the scene to activate it self randomly.
        Chance = Random.Range(0, 7);

        if (Chance == 0 || Chance == 1 || Chance == 2)
        {
            if (Chance == 0)
            {
                Items[0].SetActive(true);
                Items[1].SetActive(false);
                Items[2].SetActive(false);
            }

            if (Chance == 1)
            {
                Items[0].SetActive(false);
                Items[1].SetActive(true);
                Items[2].SetActive(false);
            }

            if (Chance == 2)
            {
                Items[0].SetActive(false);
                Items[1].SetActive(false);
                Items[2].SetActive(true);
            }
        }
        else
        {
            Items[0].SetActive(false);
            Items[1].SetActive(false);
            Items[2].SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
