﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMini : MonoBehaviour
{

    public GameObject puzzleWin_obj;
    public GameObject GM, GMM, GMS;
    public GameObject SGM;
    public GameObject point_obj;

    public int num1_i, num2_i, num3_i, num4_i, number_i;
    public int[] num_i, numC_i;
    public int pass_i,coin_i;
    public GameObject[] button_obj, pass_obj;
    public Sprite[] num_spr;
    public GameObject numImg_obj, japan_obj, rock_obj, hint_obj;
    public Sprite[] color_spr;



    public Sprite[] cutS_spr;
    public int dr_i=0;
    public GameObject cutS_obj;
    public GameObject ori_obj;
    public GameObject con_obj;

    // Start is called before the first frame update
    void Start()
    {
        SetRandColor();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Space)&& dr_i>=1)
        {
            if (dr_i==1)
            {

                cutS_obj.GetComponent<SpriteRenderer>().sprite = cutS_spr[1];
                Invoke("WaitCut2", 1.2f);
            }
            else
            {
                ori_obj.SetActive(true);
                cutS_obj.SetActive(false);
                puzzleWin_obj.SetActive(false);
                PlayerPrefs.SetInt("escdont", 0);
                GMM.GetComponent<CharMove>().canMove = true;
                PlayerPrefs.SetInt("cursorActive", 0);
                GM.GetComponent<CheckPlayer>().ItemSettings();
                SGM.GetComponent<SoundEvt>().soundItemSuccess();
                japan_obj.SetActive(false);
            }
        }
    }

    public void Button1()
    {

        if (PlayerPrefs.GetInt("waitting", 0) == 0)
        {
            pass_i = 0;
            setNum();
        }
    }
    public void Button2()
    {

        pass_i = 1;
        setNum();
        if (PlayerPrefs.GetInt("waitting", 0) == 0)
        {
        }
    }
    public void Button3()
    {
        if (PlayerPrefs.GetInt("waitting", 0) == 0)
        {
            pass_i = 2;
            setNum();
        }
    }
    public void Button4()
    {
        if (PlayerPrefs.GetInt("waitting", 0) == 0)
        {
            pass_i = 3;
            setNum();
        }
    }
    public void ButtonD1()
    {
        if (PlayerPrefs.GetInt("waitting", 0) == 0)
        {
            pass_i = 4;
            setNum();
        }
    }
    public void ButtonD2()
    {
        if (PlayerPrefs.GetInt("waitting", 0) == 0)
        {
            pass_i = 5;
            setNum();
        }
    }
    public void ButtonD3()
    {
        if (PlayerPrefs.GetInt("waitting", 0) == 0)
        {
            pass_i = 6;
            setNum();
        }
    }
    public void ButtonD4()
    {
        if (PlayerPrefs.GetInt("waitting", 0) == 0)
        {
            pass_i = 7;
            setNum();
        }
    }

    void setNum()
    {

        SGM.GetComponent<SoundEvt>().soundItemWndSelect();
        if (number_i<4)
        {
            num_i[number_i] = pass_i;
            number_i++;
            button_obj[pass_i].SetActive(false);
            pass_obj[number_i - 1].SetActive(true);
        }
        PlayerPrefs.SetInt("waitting",1);
        SGM.GetComponent<SoundEvt>().soundItemWndSelect();

        if (number_i==4)
        {
            Invoke("Wait", 1f);
        }
        else
        {
            PlayerPrefs.SetInt("waitting", 0);
        }

    }

    void Wait()
    {
        if (number_i == 4)
        {
            //0 7 4 6
            int a = 0;
            if (num_i[0] == numC_i[EventScenes.randColorF_i[0]])//06
            {
                a++;
            }
            if (num_i[1] == numC_i[EventScenes.randColorF_i[1]])//64
            {
                a++;
            }
            if (num_i[2] == numC_i[EventScenes.randColorF_i[2]])//47
            {
                a++;
            }
            if (num_i[3] == numC_i[EventScenes.randColorF_i[3]])//70
            {
                a++;
            }
            if (a == 4)
            {

                ori_obj.SetActive(false);
                cutS_obj.GetComponent<SpriteRenderer>().sprite = cutS_spr[0];
                cutS_obj.SetActive(true);
                con_obj.SetActive(false);


                Invoke("WaitCut", 1.2f);
            }
            else
            {
                SGM.GetComponent<SoundEvt>().soundItemFail();
                coin_i--;
                if (coin_i == 0)
                {
                    ClosePuzzle();
                }
                else
                {
                    for (int i = 0; i < 8; i++)
                    {
                        button_obj[i].SetActive(true);
                    }
                    numImg_obj.GetComponent<SpriteRenderer>().sprite = num_spr[coin_i];

                    pass_obj[0].SetActive(false);
                    pass_obj[1].SetActive(false);
                    pass_obj[2].SetActive(false);
                    pass_obj[3].SetActive(false);
                }
            }
            number_i = 0;
        }

        PlayerPrefs.SetInt("waitting", 0);

    }

    public void ShowPuzzle()
    {
        coin_i = 3;
        coin_i = 3;
        numImg_obj.GetComponent<SpriteRenderer>().sprite = num_spr[coin_i];
        puzzleWin_obj.SetActive(true);
        PlayerPrefs.SetInt("escdont", 1);
        coin_i = 3;
        numImg_obj.GetComponent<SpriteRenderer>().sprite = num_spr[coin_i];

        PlayerPrefs.SetInt("cursorActive", 1);
        PlayerPrefs.Save();
        Cursor.visible = true;
    }

    public void ClosePuzzle()
    {
        PlayerPrefs.SetInt("cursorActive", 0);
        GMM.GetComponent<CharMove>().canMove = true;
        puzzleWin_obj.SetActive(false);
        PlayerPrefs.SetInt("escdont", 0);
        for (int i = 0; i < 8; i++)
        {
            button_obj[i].SetActive(true);
        }
        pass_obj[0].SetActive(false);
        pass_obj[1].SetActive(false);
        pass_obj[2].SetActive(false);
        pass_obj[3].SetActive(false);
        puzzleWin_obj.SetActive(false);
        PlayerPrefs.SetInt("escdont", 0);
        rock_obj.SetActive(true);
        number_i = 0;
        SGM.GetComponent<SoundEvt>().soundItemFail();

    }

    void ClearPuzzle()
    {

    }

    //도감 삑삑삑소리 버튼 누를 때
    //얻어지는 소리공통 실패하는 소리 공통


    public void ShowHint()
    {
        if (hint_obj.activeSelf)
        {
            hint_obj.SetActive(false);
        }
        else
        {
            hint_obj.SetActive(true);
            SGM.GetComponent<SoundEvt>().soundStart();
        }
    }

    /// <summary>
    ///  색깔설정
    /// </summary>
    void SetRandColor()
    {
        for (int i = 0; i < 4; i++)
        {
            pass_obj[i].GetComponent<SpriteRenderer>().sprite = color_spr[EventScenes.randColorF_i[i]];
        }


        Debug.Log(EventScenes.randColorF_i[0]);

        Debug.Log(EventScenes.randColorF_i[1]);

        Debug.Log(EventScenes.randColorF_i[2]);

        Debug.Log(EventScenes.randColorF_i[3]);

    }



    void WaitCut()
    {
        dr_i = 1;
    }
    void WaitCut2()
    {
        dr_i = 2;
    }
}
