using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    public Image  BlackScreen; //MenuScreen,
    public float fadeSpeed = 5f;
    public bool fadeToBlack, fadeFromBlack, menuScreen;
    public TextMeshProUGUI couldHealth;
    public Image cloudStatic;
    public GameObject pauseMenuScreen, continueButton;

    public void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.PauseUnpause();
        if(PlayerPrefs.HasKey("Continue"))
        {
            continueButton.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(fadeToBlack)
        {
            BlackScreen.color = new Color(BlackScreen.color.r, BlackScreen.color.g, BlackScreen.color.b, 
                Mathf.MoveTowards(BlackScreen.color.a, 1f, fadeSpeed * Time.deltaTime)) ;
            if(BlackScreen.color.a == 1f)
            {
                fadeToBlack = false;
            }

            
        }
        
        if (fadeFromBlack)
        {
            BlackScreen.color = new Color(BlackScreen.color.r, BlackScreen.color.g, BlackScreen.color.b,
                Mathf.MoveTowards(BlackScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
           
            if (BlackScreen.color.a == 0f)
            {
                fadeFromBlack = false;
            }

            
        }
          

    }

    void MenuAndPause()
    {
        if (Input.GetButtonDown("Jump"))
        {
            //pauseMenuScreen = true;
        }
    }

    public void starGame()
    {
        GameManager.instance.PauseUnpause();

        PlayerPrefs.SetInt("Continue", 0);
    }
    public void Continue()
    {
        GameManager.instance.RespawnCo();
        GameManager.instance.PauseUnpause();
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
