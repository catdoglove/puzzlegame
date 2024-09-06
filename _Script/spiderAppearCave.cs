using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderAppearCave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerPrefs.SetInt("spiderAppearDown", 1);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerPrefs.SetInt("spiderAppearDown", 0);
    }
}
