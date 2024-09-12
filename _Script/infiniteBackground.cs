using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infiniteBackground : MonoBehaviour
{

    public float BG_speed, float1, float2;//배경 속도
    public Transform[] BG_images; //배경들
    bool webCheck;

    float BGleftX = 0f; //배경 끝의 X값
    float BGrightX = 0f; //배경시작 끝의 X값
    float screenX; //게임 화면의 X값 절반
    float screenY; //게임 화면의 Y값 절반


    void Start()
    {
        screenY = Camera.main.orthographicSize;
        screenX = screenY * Camera.main.aspect;

        BGleftX = -(screenX * float1);
        BGrightX = screenX * float2 * BG_images.Length;

        PlayerPrefs.SetInt("autoBGstart", 0);

    }

    /// <summary>
    /// 거미줄 닿았을 때 배경 속도 조절
    /// </summary>
    public void webBGSpeed()
    {
        if (PlayerPrefs.GetInt("spiderWebWalk", 0) == 1 && webCheck ==false)
        {
            BG_speed = BG_speed - 2f;
            webCheck = true;
        }
        else if (PlayerPrefs.GetInt("spiderWebWalk", 0) == 0 && webCheck == true)
        {
            BG_speed = BG_speed + 2f;
            webCheck = false;
        }
    }




    /// <summary>
    /// 자동 배경 전환
    /// </summary>
    void Update()
    {
        webBGSpeed();

        if  (PlayerPrefs.GetInt("autoBGstart", 0) == 1)
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                for (int i = 0; i < BG_images.Length; i++)
                {
                    BG_images[i].position += new Vector3(-BG_speed, 0, 0) * Time.deltaTime;

                    if (BG_images[i].position.x < BGleftX)
                    {
                        Vector3 nextPos = BG_images[i].position;
                        nextPos = new Vector3(nextPos.x + BGrightX, nextPos.y, nextPos.z);
                        BG_images[i].position = nextPos;
                    }
                }
            }
        }
        else if (PlayerPrefs.GetInt("autoBGstart", 0) == 99)
        {
          //  Debug.Log("맵빠져나오기");
        }
    }
}
