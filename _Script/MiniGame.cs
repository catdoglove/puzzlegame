using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    public GameObject[] Row1_obj, Row2_obj,Row3_obj,Row4_obj;

    public GameObject[] wood_obj;

    public GameObject select_obj;

    public int x_i, y_i,woodNum_i;

    public bool select_b;

    public int[][] num_i;

    // Start is called before the first frame update
    void Start()
    {
        x_i = 0;
        y_i = 0;

        num_i[0][2] = 1;
        num_i[1][2] = 1;
        num_i[2][2] = 1;
        num_i[3][2] = 1;
        num_i[0][3] = 1;
        num_i[1][3] = 1;
        num_i[2][3] = 1;
        num_i[3][3] = 1;
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
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (x_i < 2)
            {
                x_i++;
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (y_i > 0)
            {
                y_i--;
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
                SetRow();
            }
            else
            {
                SetSelect();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (num_i[x_i][y_i]==1)
            {
                if (select_b)
                {
                    select_b = false;
                }
                else
                {
                    select_b = true;
                }
            }
        }


    }


    void SetRow()
    {
        switch (x_i)
        {
            case 0:
                //Row1_obj[y_i];
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            default:
                break;
        }
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
