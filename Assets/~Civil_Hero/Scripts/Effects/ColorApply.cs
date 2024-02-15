using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorApply : MonoBehaviour
{
    public GameObject Root;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Applies color to this child object based of it's root.
        if (Root.GetComponent<ColorIdentify>().WhichBin == 0)
        {
            gameObject.GetComponent<Renderer>().material = Root.GetComponent<ColorIdentify>().NatureColor;
        }

        if (Root.GetComponent<ColorIdentify>().WhichBin == 1)
        {
            gameObject.GetComponent<Renderer>().material = Root.GetComponent<ColorIdentify>().RecycleColor;
        }

        if (Root.GetComponent<ColorIdentify>().WhichBin == 2)
        {
            gameObject.GetComponent<Renderer>().material = Root.GetComponent<ColorIdentify>().GarbageColor;
        }
    }

    void OnTriggerEnter(Collider Col)
    {
        //Increases performance by deleting this cube when it accidently clips through the floor
        if(Col.gameObject.tag == "Killzone")
        {
            Destroy(gameObject);
        }
    }
}
