﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderCaveEvent : MonoBehaviour
{
    float spiderX;
    public GameObject WebTrapfirst, spiderPosition, chaseArea, spiderChaseSpr, spiderDownSpr, charFallSpr;
    bool caveCheck;

    /// <summary>
    /// spiderAppearDown : 거미 추격씬 마지막 부분 거미
    /// spiderChaseRun : 거미 서식지 넘어지는 부분 거미
    /// autoBGstart : 자동배경전환 시작 체크
    /// spiderWebWalk : 거미줄콜라이더 접근 체크
    /// </summary>
    void Start()
    {
        //WebTrapfirst.SetActive(false);
        PlayerPrefs.SetInt("spiderAppearDown", 0);
        PlayerPrefs.SetInt("spiderChaseRun", 0);
        PlayerPrefs.SetInt("spiderWebWalk", 0);
        StartCoroutine("SpiderChaseStart");

    }


    void Update()
    {

        StartCoroutine("spiderEvtStart");

        //거미내려오는부분
        if (PlayerPrefs.GetInt("spiderAppearDown", 0) == 1)
        {
            spiderDownSpr.SetActive(true);
        }

        //거미서식지 탈출
        if (PlayerPrefs.GetInt("spiderChaseRun", 0) == 1)
        {
            spiderChaseSpr.SetActive(true);
            charFallSpr.SetActive(true);
        }



        if (PlayerPrefs.GetInt("autoBGstart", 0) == 1)
        {
            StartCoroutine("ShowWeb");
            StartCoroutine("SpiderChaseEnd");
            chaseArea.SetActive(false);
        }
        
        
        if (PlayerPrefs.GetInt("spiderWebWalk", 0) == 1 || PlayerPrefs.GetInt("autoBGstart", 0) == 99)
        {
            spiderPositionX();
        }
        else if (PlayerPrefs.GetInt("spiderWebWalk", 0) == 0)
        {
        }
    }


    /// <summary>
    /// 거미가 쫓아오는 함수 (X값)
    /// </summary>
    public void spiderPositionX()
    {
        spiderX = spiderPosition.transform.position.x;
        spiderX = spiderX + 0.03f;
        spiderPosition.transform.position = new Vector3(spiderX, spiderPosition.transform.position.y);
    }

    IEnumerator spiderEvtStart()
    {
        if (PlayerPrefs.GetInt("spiderEventStart", 0) == 1)
        {
            Debug.Log("시작");
        }
        yield return new WaitForSeconds(0.1f);

    }



    IEnumerator ShowWeb() //거미줄 초반부분은 처음에 안나와야함 
    {
        yield return new WaitForSeconds(5f);
        WebTrapfirst.SetActive(true);
    }


    /// <summary>
    /// 거미 추적씬 시작
    /// </summary>
    /// <returns></returns>
    IEnumerator SpiderChaseStart()
    {
           while (true)
           {
            if (PlayerPrefs.GetInt("autoBGstart", 0) == 1)
            {
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                }
                else
                {
                    spiderPositionX();
                }

            }
            yield return new WaitForSeconds(0.01f);
        }           
    }


    /// <summary>
    /// 거미 추적씬 종료로 인한 맵 마감 
    /// </summary>
    /// <returns></returns>
    IEnumerator SpiderChaseEnd()
    {
        yield return new WaitForSeconds(7f); //나중에 시간늘려야함

        if (caveCheck == false)
        {
            caveCheck = true;
            PlayerPrefs.SetInt("autoBGstart", 99);
        }

    }

}
