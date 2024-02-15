using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIButton : MonoBehaviour
{
    public string CurrentSceneName;
    public GameObject Target_Menu;
    public GameObject Current_Menu;
    public GameObject Game_Canvas;
    public bool isLevel_1;
    public bool StartScreen;
	// Use this for initialization
	void Start ()
    {
        if(StartScreen == true)
        {
            Time.timeScale = 0;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Functions that are simply interacted by this current gameObject's button.
    public void MenuSwitch()
    {
        GameObject.Find("Menu_Select_Sound").GetComponent<AudioSource>().Play();
        Target_Menu.SetActive(true);
        Current_Menu.SetActive(false);
    }

    public void PlayButton()
    {
        GameObject.Find("Menu_Select_Sound").GetComponent<AudioSource>().Play();
        Target_Menu.SetActive(true);
        Time.timeScale = 1;
        Current_Menu.SetActive(false);
    }

    public void TutorialButton()
    {
        GameObject.Find("Menu_Select_Sound").GetComponent<AudioSource>().Play();
        GameObject.Find("Background_Music").GetComponent<AudioSource>().enabled = true;
        GameObject.Find("Skate_Sound").GetComponent<AudioSource>().enabled = true;
        GameObject.Find("Main_Menu_Music").GetComponent<AudioSource>().enabled = false;
        Time.timeScale = 1;
        Game_Canvas.SetActive(true);
        Current_Menu.SetActive(false);
    }

    public void PauseButton()
    {
        GameObject.Find("Menu_Select_Sound").GetComponent<AudioSource>().Play();
        GameObject.Find("Skate_Sound").GetComponent<AudioSource>().enabled = false;
        Target_Menu.SetActive(true);
        Time.timeScale = 0;
        Current_Menu.SetActive(false);
    }

    public void ContinueButton()
    {
        GameObject.Find("Menu_Select_Sound").GetComponent<AudioSource>().Play();
        GameObject.Find("Skate_Sound").GetComponent<AudioSource>().enabled = true;
        Target_Menu.SetActive(true);
        Time.timeScale = 1;
        Current_Menu.SetActive(false);
    }

    public void RestartButton()
    {
        GameObject.Find("Menu_Select_Sound").GetComponent<AudioSource>().Play();
        GameObject.Find("Player_Stats_Data_Sync").GetComponent<PlayerStats>().Spawns = 0;
        if (isLevel_1 == false)
        {
            GameObject.Find("Skate_Sound").GetComponent<AudioSource>().enabled = true;
        }
        else
        {
            GameObject.Find("Background_Music").GetComponent<AudioSource>().enabled = false;
        }
        Time.timeScale = 1;
        SceneManager.LoadScene(CurrentSceneName);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
