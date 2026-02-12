using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lastLoopMapStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("lastLoopMapOn", 0);
        PlayerPrefs.SetInt("autoBGstartLast", 0);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (PlayerPrefs.GetInt("lastLoopMapOn") == 0)
        {
            PlayerPrefs.SetInt("lastLoopMapOn", 1); 
            PlayerPrefs.SetInt("autoBGstartLast", 1);

        }

    }
}
