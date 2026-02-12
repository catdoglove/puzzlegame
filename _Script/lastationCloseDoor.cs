using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lastationCloseDoor : MonoBehaviour
{
    public GameObject autoDoorImg, autoDoorImg2;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("doorGoOut", 0);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(PlayerPrefs.GetInt("doorGoOut") == 0)
        {
            autoDoorImg.SetActive(true);
            PlayerPrefs.SetInt("doorGoOut",1);
        }

    }
    void closeDoor()
    {
        autoDoorImg2.SetActive(true);
        autoDoorImg.SetActive(false);
    }
}
