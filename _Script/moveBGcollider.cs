using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBGcollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerPrefs.SetInt("autoBGstart", 1);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
    }
}
