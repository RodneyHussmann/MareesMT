using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogControler : MonoBehaviour
{
    public static DialogControler instance;
    public GameObject cloud;

    public int currentStatis;
    
    public GameObject cloudTextBubble;
    public TextMeshProUGUI text;
    public string[] lines;
    public float textSpeed;
   

    //[SerializeField] AudioClip[] cloudVoice;
    //AudioSource cloudAudio;


    private void Awake()
    {
        instance = this;
        cloudTextBubble.SetActive(false);
        //cloudTextBubble.SetActive(true);
    }

    
    void Start()
    {
        currentStatis = CloudHeath.currentStatis;
        //currentStatis = CloudHeath.instance.currentStatis;
       
    }

    
    void Update()
    {
        //UpdateUI();

    }
    public void Uses()
    {
        currentStatis--;

        if (currentStatis <= 0)
        {
            currentStatis = 0;
            
        }
    }



    

    
        
}
