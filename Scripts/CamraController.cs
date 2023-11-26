using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CamraController : MonoBehaviour
{

    public static CamraController instance;
    // Start is called before the first frame update
    public CinemachineBrain theCMBrain;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
