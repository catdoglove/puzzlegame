using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caveFeatherEvt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("caveFeatherWalk", 0);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerPrefs.SetInt("caveFeatherWalk", 1);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerPrefs.SetInt("caveFeatherWalk", 0);
    }
}
