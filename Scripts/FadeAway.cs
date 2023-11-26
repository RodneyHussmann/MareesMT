using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAway : MonoBehaviour
{

    public GameObject scrool;
    public float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        scrool.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        ScroolOff();
    }
    public void ScroolOff()
    {
        StartCoroutine(WaitSomeSec(waitTime));

    }

    IEnumerator WaitSomeSec(float duration)
    {
       // scrool.SetActive(true);
        yield return new WaitForSeconds(duration);
        scrool.SetActive(false);
    }
}
