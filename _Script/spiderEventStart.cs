using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderEventStart : MonoBehaviour
{
    int a = 0;
    public GameObject d_obj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerPrefs.SetInt("spiderEventStart", 1);

        if (a==0)
        {

            d_obj.GetComponent<Animator>().Play("ani_npc_spider_change");
            a = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerPrefs.SetInt("spiderEventStart", 0);
    }
}
