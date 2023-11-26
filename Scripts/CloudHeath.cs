using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CloudHeath : MonoBehaviour
{
    
    public GameObject cloud;

    public int  maxStatis, changeStatis;

    public Sprite[] cloudStatice;
    public static int currentStatis { get; set; }
    //[SerializeField] AudioClip[] cloudVoice;
    //AudioSource cloudAudio;
    public static CloudHeath instance;
   public GameObject gameManager;
    
    private void Awake()
    {
        instance = this;
        //DialogControler.instance.cloudTextBubble.SetActive(true);
        CloudOnOff();
        cloud.SetActive(true);
        
    }

    // Start is called before the first frame update
    void Start()
    {
       currentStatis = maxStatis;
       changeStatis = currentStatis;
        //cloudAudio = GetComponent<AudioSource>();

        //PlayerPrefs.SetInt("CloudHeath", currentStatis);
    }
    void OnDisable()
    {
        //PlayerPrefs.SetInt("CloudHeath", currentStatis);
    }
    void OnEnable()
    {
        //currentStatis = PlayerPrefs.GetInt("CloudHeath", currentStatis);
    }
    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }



    public void Uses()
    {
        
        currentStatis --;
        //this tracks clouds health
        if(currentStatis <= 0)
        {
            currentStatis = 0;
            CloudControl.instance.cloudMovespeed = 0;
            CloudCatcher.instance.cloudSpeed = 0;
            //cloud.SetActive(false);

        }
        //THis is controlling talk bubbles
        if(changeStatis > currentStatis )
        {
            CloudOnOff();
            changeStatis = currentStatis;
        }

    }

    public void UpdateUI()
    {
        //currentStatis = currentStatis.ToString();

        UiManager.instance.couldHealth.text = currentStatis.ToString();

        switch(currentStatis)
        {
            case 10:
                
                DialogControler.instance.text.text = DialogControler.instance.lines[0];
                // DialogControler.instance.fadeSpeed = DialogControler.instance.timeTofade;
                UiManager.instance.cloudStatic.sprite = cloudStatice[0];
                //CloudOnOff();

                break;
            case 9:
               // DialogControler.instance.cloudTextBubble.SetActive(true);
                DialogControler.instance.text.text = DialogControler.instance.lines[1];
                // DialogControler.instance.fadeSpeed = DialogControler.instance.timeTofade;
                //CloudOnOff();
                UiManager.instance.cloudStatic.sprite = cloudStatice[0];

                break;
            case 8:
                //DialogControler.instance.cloudTextBubble.SetActive(true);
                DialogControler.instance.text.text = DialogControler.instance.lines[2];
                // DialogControler.instance.fadeSpeed = DialogControler.instance.timeTofade;
               //CloudOnOff();
                UiManager.instance.cloudStatic.sprite = cloudStatice[0];

                break;
            case 7:
               // DialogControler.instance.cloudTextBubble.SetActive(true);
                DialogControler.instance.text.text = DialogControler.instance.lines[3];
               // DialogControler.instance.fadeSpeed = DialogControler.instance.timeTofade;
               // CloudOnOff();
                UiManager.instance.cloudStatic.sprite = cloudStatice[1];
                
                break;
            case 6:
               // DialogControler.instance.cloudTextBubble.SetActive(true);
                DialogControler.instance.text.text = DialogControler.instance.lines[4];
                // DialogControler.instance.fadeSpeed = DialogControler.instance.timeTofade;
             //  CloudOnOff();
                UiManager.instance.cloudStatic.sprite = cloudStatice[1];

                break;
            case 5:
               // DialogControler.instance.cloudTextBubble.SetActive(true);
                DialogControler.instance.text.text = DialogControler.instance.lines[5];
                // DialogControler.instance.fadeSpeed = DialogControler.instance.timeTofade;
              //CloudOnOff();
                UiManager.instance.cloudStatic.sprite = cloudStatice[2];
                break;
            case 4:
              //  DialogControler.instance.cloudTextBubble.SetActive(true);
                DialogControler.instance.text.text = DialogControler.instance.lines[6];
                // DialogControler.instance.fadeSpeed = DialogControler.instance.timeTofade;
              //CloudOnOff();
                UiManager.instance.cloudStatic.sprite = cloudStatice[3];

                break;
            case 3:
              //  DialogControler.instance.cloudTextBubble.SetActive(true);
                DialogControler.instance.text.text = DialogControler.instance.lines[7];
                // DialogControler.instance.fadeSpeed = DialogControler.instance.timeTofade;
              // CloudOnOff();
                UiManager.instance.cloudStatic.sprite = cloudStatice[3];

                break;
            case 2:
              // DialogControler.instance.cloudTextBubble.SetActive(true);
                DialogControler.instance.text.text = DialogControler.instance.lines[8];
                // DialogControler.instance.fadeSpeed = DialogControler.instance.timeTofade;
              // CloudOnOff();
                UiManager.instance.cloudStatic.sprite = cloudStatice[3];
                break;
            case 1:
                DialogControler.instance.cloudTextBubble.SetActive(true);
                DialogControler.instance.text.text = DialogControler.instance.lines[9];
                // DialogControler.instance.fadeSpeed = DialogControler.instance.timeTofade;
               //CloudOnOff();
                UiManager.instance.cloudStatic.sprite = cloudStatice[3];
                break;
            case 0:
                
                SceneManager.LoadScene(4);
                Destroy(gameManager);
                
                break;



        }
    }
    public void CloudOnOff()
    {
        StartCoroutine(WaitSomeSec(5));

    }

    IEnumerator WaitSomeSec(float duration)
    {
        DialogControler.instance.cloudTextBubble.SetActive(true);
        yield return new WaitForSeconds(duration);
        DialogControler.instance.cloudTextBubble.SetActive(false);
    }


}
