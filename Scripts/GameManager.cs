using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player,cloudHealth,cloud,camra,ui;

    //public int currentCloudHealth;

    private Vector3 respawnPosition , camSpawnPosition;
    

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(cloudHealth);
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(cloud);
        DontDestroyOnLoad(camra);
        DontDestroyOnLoad(ui);
        
    }

   

    void Start()
    {
        respawnPosition = PlayerController.instance.transform.position;
        camSpawnPosition = CamraController.instance.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
        if(Input.GetButtonDown("Pause"))
        {
            PauseUnpause();
        }

        if(player.transform.position.y <= instance.transform.position.y)
        {
            StartCoroutine(RespawnCo());
        }
    }
     
    public void Respawn()
    {

        StartCoroutine(RespawnCo());

    }

    public IEnumerator RespawnCo()
    {
        UiManager.instance.fadeToBlack = true;
        PlayerController.instance.gameObject.SetActive(false);
        CamraController.instance.theCMBrain.enabled = false;

        
       // UiManager.instance.menuScreen = true;

        yield return new WaitForSeconds(2f);
        PlayerController.instance.transform.position = respawnPosition;
        CamraController.instance.transform.position = camSpawnPosition;
                
        PlayerController.instance.gameObject.SetActive(true);
        CamraController.instance.theCMBrain.enabled = true;
        
        yield return new WaitForSeconds(2f);
        UiManager.instance.fadeFromBlack = true;
        // UiManager.instance.menuScreen = false;
    }

    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        
        respawnPosition = newSpawnPoint;
    }

    public void PauseUnpause()
    {
        if(UiManager.instance.pauseMenuScreen.activeInHierarchy)
        {
            UiManager.instance.pauseMenuScreen.SetActive(false);
            Time.timeScale = 1f;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

        }
        else
        {
            UiManager.instance.pauseMenuScreen.SetActive(true);
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
