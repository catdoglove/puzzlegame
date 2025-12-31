using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class labLightSensor : MonoBehaviour
{
    public GameObject labLightImg, realLight;
    public Sprite[] labLightSpr;
    public int num; // 1 : 계단 , 2 : 통로
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        switch(num)
        {
            case 1:
                realLight.SetActive(false);
                break;

            case 2:
                realLight.SetActive(true);
                labLightImg.GetComponent<SpriteRenderer>().sprite = labLightSpr[1];
                break;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (num)
        {
            case 1:
                break;

            case 2:
                labLightImg.GetComponent<SpriteRenderer>().sprite = labLightSpr[0];
                realLight.SetActive(false);
                break;
        }
    }
}
