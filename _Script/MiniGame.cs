﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    public GameObject[] Row1_obj, Row2_obj,Row3_obj,Row4_obj;

    public GameObject[] wood_obj;

    public GameObject select_obj;

    public int x_i, y_i,woodNum_i;

    public bool select_b;

    public int[,] num_i = new int[3,4];

    public int nowSelect_i;

    // Start is called before the first frame update
    void Start()
    {
        x_i = 0;
        y_i = 2;

        num_i[0,2] = 1;
        num_i[1,2] = 2;
        num_i[2,2] = 3;
        num_i[0,3] = 4;
        num_i[1,3] = 5;
        num_i[2,3] = 6;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.A))
        {
            if (x_i>0)
            {
                x_i--;
            }

            if (select_b)
            {
                if (num_i[x_i, y_i] != 0)
                {
                    x_i++;
                }
                SetRow();
            }
            else
            {
                SetSelect();
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (x_i < 2)
            {
                x_i++;
            }

            if (select_b)
            {
                if (num_i[x_i, y_i] != 0)
                {
                    x_i--;
                }
                SetRow();
            }
            else
            {
                SetSelect();
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (y_i > 0)
            {
                y_i--;
            }

            if (select_b)
            {
                if (num_i[x_i, y_i] != 0)
                {
                    y_i++;
                }
                SetRow();
            }
            else
            {
                SetSelect();
            }

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (y_i < 3)
            {
                y_i++;
            }


            if (select_b)
            {
                if (num_i[x_i, y_i] != 0)
                {
                    y_i--;
                }
                SetRow();
            }
            else
            {
                SetSelect();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (num_i[x_i,y_i]!=0)
            {
                if (select_b)
                {
                }
                else
                {
                    select_b = true;
                    nowSelect_i = 0 + num_i[x_i, y_i];
                    num_i[x_i, y_i] = 0;
                }
            }
            else
            {
                if (select_b)
                {
                    select_b = false;
                    num_i[x_i, y_i] = 0 + nowSelect_i;
                    nowSelect_i = 0;
                }
            }
        }


    }


    void SetRow()
    {
        switch (x_i)
        {
            case 0:
                wood_obj[nowSelect_i].transform.position = Row1_obj[y_i].transform.position;
                break;
            case 1:
                wood_obj[nowSelect_i].transform.position = Row2_obj[y_i].transform.position;
                break;
            case 2:
                wood_obj[nowSelect_i].transform.position = Row3_obj[y_i].transform.position;
                break;
            case 3:
                wood_obj[nowSelect_i].transform.position = Row4_obj[y_i].transform.position;
                break;
            default:
                break;
        }

        SetSelect();
    }


    void SetSelect()
    {
        switch (x_i)
        {
            case 0:
                select_obj.transform.position = Row1_obj[y_i].transform.position;
                break;
            case 1:
                select_obj.transform.position = Row2_obj[y_i].transform.position;
                break;
            case 2:
                select_obj.transform.position = Row3_obj[y_i].transform.position;
                break;
            case 3:
                select_obj.transform.position = Row4_obj[y_i].transform.position;
                break;
            default:
                break;
        }
    }

}