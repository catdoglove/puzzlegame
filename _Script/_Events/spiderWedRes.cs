using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderWedRes : MonoBehaviour
{
    public GameObject WebTrapfirst;
    public bool a;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (a)
        {
            WebTrapfirst.SetActive(true);
            a= false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }
}
