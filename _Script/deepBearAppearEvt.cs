using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deepBearAppearEvt : MonoBehaviour
{
    public GameObject bearEvt;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("deepBearAppear", 0);
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("deepBearAppear", 0) == 1)
        {
            bearEvt.SetActive(true);  //임시??
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerPrefs.SetInt("deepBearAppear", 1);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerPrefs.SetInt("deepBearAppear", 0);
    }
}
