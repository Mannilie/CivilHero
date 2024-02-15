using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject PLAYER_INPUT;
    public bool Left;
    public bool Right;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Controls are dependent on EventSystems which means that it's click to move.
    public void OnPointerDown (PointerEventData eventData)
    {
        if(Left == true)
        {
            PLAYER_INPUT.GetComponent<PlayerInput>().MovingLeft = true;
        }

        if (Right == true)
        {
            PLAYER_INPUT.GetComponent<PlayerInput>().MovingRight = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (Left == true)
        {
            PLAYER_INPUT.GetComponent<PlayerInput>().MovingLeft = false;
        }

        if (Right == true)
        {
            PLAYER_INPUT.GetComponent<PlayerInput>().MovingRight = false;
        }
    }
}
