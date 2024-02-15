using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Transform Player_Pivot;
    public float TargetSpeed = 10;
    public float RotationSpeed = 10;
    public int WhichBin;

    public bool PlayerDead;
    public bool Armed;
    public bool Collected;
    public GameObject Explosion_Effect;

    public GameObject[] Items;
    public Animator Right_Arm;

    public GameObject Player_Model;
    public GameObject Player_Fell;
    public GameObject PLAYER_INPUT;
    public GameObject Touch_Input_Canvas;

    public Animation Right_Arm_Throw;

    public bool StartCollectedTime;
    private float CollectedTime = 0.1f;

    public GameObject Game_Canvas;
    public GameObject Lose_Canvas;
    public GameObject Portal_Canvas;

    private float LoseScreenTime = 2;
    public bool SetTimeFreeze;

    public bool SetSkateSoundOff = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        PlayerSmoothness();

        //Stops certain parts of the game and justifies to all scripts that the player is dead.
        if(PlayerDead == true)
        {
            if (SetSkateSoundOff == false)
            {
                GameObject.Find("Skate_Sound").GetComponent<AudioSource>().enabled = false;
                SetSkateSoundOff = true;
            }
            PLAYER_INPUT.SetActive(false);
            Touch_Input_Canvas.SetActive(false);
            Player_Model.SetActive(false);
            Player_Fell.SetActive(true);
            if(LoseScreenTime <= 0)
            {
                if(SetTimeFreeze == false)
                {
                    Time.timeScale = 0;
                    Game_Canvas.SetActive(false);
                    Lose_Canvas.SetActive(true);
                    SetTimeFreeze = true;
                }
                LoseScreenTime = 0;
            }
            else
            {
                LoseScreenTime -= Time.deltaTime;
            }
        }

        //To display a result when the player is armed and able to pass through the bins
        if(Armed == true)
        {
            if (Player_Model.activeSelf == true)
            {
                Right_Arm.SetBool("Armed", true);
            }
            if(WhichBin == 0)
            {
                Items[0].SetActive(true);
            }

            if (WhichBin == 1)
            {
                Items[1].SetActive(true);
            }

            if (WhichBin == 2)
            {
                Items[2].SetActive(true);
            }
        }
        else
        {
            if (Player_Model.activeSelf == true)
            {
                Right_Arm.SetBool("Armed", false);
            }
            Items[0].SetActive(false);
            Items[1].SetActive(false);
            Items[2].SetActive(false);
        }

        if(StartCollectedTime == true)
        {
            if(CollectedTime < 0)
            {
                Collected = false;
                CollectedTime = 2;
                StartCollectedTime = false;
            }
            else
            {
                Collected = true;
                CollectedTime -= Time.deltaTime;
            }
        }
	}

    void PlayerSmoothness()
    {
        //Smoothly sets this transform's position and rotation to the main transform that is moving with the raycast.
        transform.position = Vector3.Lerp(transform.position, Player_Pivot.position, Time.deltaTime * TargetSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation, Player_Pivot.rotation, Time.deltaTime * RotationSpeed);
    }

    void OnTriggerEnter (Collider Col)
    {
        //Allows interactions to happen once from a trigger's tag.
        if(Col.gameObject.tag == "Portal")
        {
            GameObject.Find("Portal_Sound").GetComponent<AudioSource>().Play();
            Portal_Canvas.SetActive(true);
            SceneManager.LoadScene("Level_2");
        }

        if(Col.gameObject.tag == "Nature")
        {
            if(Armed == false)
            {
                WhichBin = 0;
                Armed = true;
                GameObject.Find("Pickup_Sound").GetComponent<AudioSource>().Play();
                Right_Arm_Throw.Play("Player_Throw");
                Col.gameObject.SetActive(false);
            }
        }

        if (Col.gameObject.tag == "Recycle")
        {
            if (Armed == false)
            {
                WhichBin = 1;
                Armed = true;
                GameObject.Find("Pickup_Sound").GetComponent<AudioSource>().Play();
                Right_Arm_Throw.Play("Player_Throw");
                Col.gameObject.SetActive(false);
            }
        }

        if (Col.gameObject.tag == "Garbage")
        {
            if (Armed == false)
            {
                WhichBin = 2;
                Armed = true;
                GameObject.Find("Pickup_Sound").GetComponent<AudioSource>().Play();
                Right_Arm_Throw.Play("Player_Throw");
                Col.gameObject.SetActive(false);
            }
        }

        if (Col.gameObject.tag == "NatureBin")
        {
            if (Armed == true)
            {
                if (WhichBin != 0)
                {
                    PlayerDead = true;
                }
                else
                {
                    Right_Arm_Throw.Play("Player_Throw");
                    GameObject.Find("Player_Stats_Data_Sync").GetComponent<PlayerStats>().Score += 1;
                    StartCollectedTime = true;
                    Collected = true;
                    Armed = false;
                }
            }
            else
            {
                if (Collected == false)
                {
                    PlayerDead = true;
                }
            }
            GameObject.Find("Explosion_Sound").GetComponent<AudioSource>().pitch = Random.Range(1, 1.3f);
            GameObject.Find("Explosion_Sound").GetComponent<AudioSource>().Play();
            GameObject.Find("Rocks_Sound").GetComponent<AudioSource>().Play();
            GameObject Explosion_Effect_Clone = Instantiate(Explosion_Effect, Col.gameObject.GetComponent<RootObject>().Root.transform.position, Col.gameObject.GetComponent<RootObject>().Root.transform.rotation);
            Explosion_Effect_Clone.GetComponent<ColorIdentify>().WhichBin = 0;
            Explosion_Effect_Clone.transform.parent = Col.gameObject.GetComponent<RootObject>().Infinite_Level.transform;
            Col.gameObject.GetComponent<RootObject>().Root.SetActive(false);
        }

        if (Col.gameObject.tag == "RecycleBin")
        {
            if (Armed == true)
            {
                if (WhichBin != 1)
                {
                    PlayerDead = true;
                }
                else
                {
                    Right_Arm_Throw.Play("Player_Throw");
                    GameObject.Find("Player_Stats_Data_Sync").GetComponent<PlayerStats>().Score += 1;
                    StartCollectedTime = true;
                    Collected = true;
                    Armed = false;
                }
            }
            else
            {
                if (Collected == false)
                {
                    PlayerDead = true;
                }
            }
            GameObject.Find("Explosion_Sound").GetComponent<AudioSource>().pitch = Random.Range(1, 1.3f);
            GameObject.Find("Explosion_Sound").GetComponent<AudioSource>().Play();
            GameObject.Find("Rocks_Sound").GetComponent<AudioSource>().Play();
            GameObject Explosion_Effect_Clone =  Instantiate(Explosion_Effect, Col.gameObject.GetComponent<RootObject>().Root.transform.position, Col.gameObject.GetComponent<RootObject>().Root.transform.rotation);
            Explosion_Effect_Clone.GetComponent<ColorIdentify>().WhichBin = 1;
            Explosion_Effect_Clone.transform.parent = Col.gameObject.GetComponent<RootObject>().Infinite_Level.transform;
            Col.gameObject.GetComponent<RootObject>().Root.SetActive(false);
        }

        if (Col.gameObject.tag == "GarbageBin")
        {
            if (Armed == true)
            {
                if (WhichBin != 2)
                {
                    PlayerDead = true;
                }
                else
                {
                    Right_Arm_Throw.Play("Player_Throw");
                    GameObject.Find("Player_Stats_Data_Sync").GetComponent<PlayerStats>().Score += 1;
                    StartCollectedTime = true;
                    Collected = true;
                    Armed = false;
                }
            }
            else
            {
                if (Collected == false)
                {
                    PlayerDead = true;
                }
            }
            GameObject.Find("Explosion_Sound").GetComponent<AudioSource>().pitch = Random.Range(1, 1.3f);
            GameObject.Find("Explosion_Sound").GetComponent<AudioSource>().Play();
            GameObject.Find("Rocks_Sound").GetComponent<AudioSource>().Play();
            GameObject Explosion_Effect_Clone =  Instantiate(Explosion_Effect, Col.gameObject.GetComponent<RootObject>().Root.transform.position, Col.gameObject.GetComponent<RootObject>().Root.transform.rotation);
            Explosion_Effect_Clone.GetComponent<ColorIdentify>().WhichBin = 2;
            Explosion_Effect_Clone.transform.parent = Col.gameObject.GetComponent<RootObject>().Infinite_Level.transform;
            Col.gameObject.GetComponent<RootObject>().Root.SetActive(false);
        }
    }
}
