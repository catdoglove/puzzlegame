using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMini : MonoBehaviour
{

    public GameObject puzzleWin_obj;
    public GameObject GM, GMM, GMS;
    public GameObject SGM;
    public GameObject point_obj;

    public int num1_i, num2_i, num3_i, num4_i, number_i;
    public int[] num_i;
    public int pass_i,coin_i;
    public GameObject[] button_obj, pass_obj;
    public Sprite[] num_spr;
    public GameObject numImg_obj;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Button1()
    {
        pass_i = 0;
        setNum();
    }
    public void Button2()
    {
        pass_i = 1;
        setNum();
    }
    public void Button3()
    {
        pass_i = 2;
        setNum();
    }
    public void Button4()
    {
        pass_i = 3;
        setNum();
    }
    public void ButtonD1()
    {
        pass_i = 4;
        setNum();
    }
    public void ButtonD2()
    {
        pass_i = 5;
        setNum();
    }
    public void ButtonD3()
    {
        pass_i = 6;
        setNum();
    }
    public void ButtonD4()
    {
        pass_i = 7;
        setNum();
    }

    void setNum()
    {
        if (number_i<4)
        {
            num_i[number_i] = pass_i;
            number_i++;
            button_obj[pass_i].SetActive(false);
        }
        if (number_i==4)
        {
            //0 7 4 6
            int a = 0;
            if (num_i[0]==0)
            {
                a++;
            }
            if (num_i[1] == 7)
            {
                a++;
            }
            if (num_i[2] == 4)
            {
                a++;
            }
            if (num_i[3] == 6)
            {
                a++;
            }
            if (a == 4)
            {
                puzzleWin_obj.SetActive(false);
            }
            coin_i--;
            if (coin_i==0)
            {

            }
        }
    }

    public void ShowPuzzle()
    {
        coin_i = 3;

        puzzleWin_obj.SetActive(true);
    }

    public void ClosePuzzle()
    {
        for (int i = 0; i < 7; i++)
        {
            button_obj[i].SetActive(true);
        }
        puzzleWin_obj.SetActive(false);
    }
}
