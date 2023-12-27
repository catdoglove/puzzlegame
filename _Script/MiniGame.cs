using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class MiniGame : MonoBehaviour
{
    public GameObject[] Row1_obj, Row2_obj,Row3_obj,Row4_obj;

    public GameObject[] wood_obj;

    public GameObject select_obj;

    public int x_i, y_i,woodNum_i;

    public bool select_b;

    public int[,] num_i = new int[3,4];

    public int nowSelect_i;


    public GameObject puzzleWin_obj;
    public GameObject GM, GMM, GMS;
    public GameObject pan;
    public GameObject SGM;

    public bool eazy_b;


    float time = 0;
    public float _size = 1;
    public float _upSizeTime;

    public GameObject movef_obj,moveb_obj;

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

        if (eazy_b)
        {
            num_i[0, 0] = 1;
            num_i[2, 0] = 3;
            num_i[0, 2] = 0;
            num_i[2, 2] = 0;
            num_i[0, 3] = 5;
            num_i[1, 3] = 4;
        }
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {

            time = 1;
            if (x_i>0)
            {
                x_i--;
            }

            if (select_b)
            {
                if (num_i[x_i, y_i] != 0)
                {
                    x_i++;
                    //움직이지 못할 때
                    time = 0;
                }
                else
                {

                    SGM.GetComponent<SoundEvt>().soundItemWndAD();
                }
                SetRow();
            }
            else
            {
                SetSelect();
                SGM.GetComponent<SoundEvt>().soundItemWndAD();
            }
            StopMove();
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            time = 1;
            if (x_i < 2)
            {
                x_i++;
            }

            if (select_b)
            {
                if (num_i[x_i, y_i] != 0)
                {
                    x_i--;
                    //움직이지 못할 때
                    time = 0;
                }
                else
                {

                    SGM.GetComponent<SoundEvt>().soundItemWndAD();
                }
                SetRow();
            }
            else
            {
                SetSelect();
                SGM.GetComponent<SoundEvt>().soundItemWndAD();
            }
            StopMove();
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            time = 1;
            if (y_i > 0)
            {
                y_i--;
            }

            if (select_b)
            {
                time = 1;
                if (num_i[x_i, y_i] != 0)
                {
                    y_i++;
                    //움직이지 못할 때
                    time = 0;
                }
                else
                {

                    SGM.GetComponent<SoundEvt>().soundItemWndAD();
                }
                SetRow();
            }
            else
            {
                SetSelect();
                SGM.GetComponent<SoundEvt>().soundItemWndAD();
            }

            StopMove();
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            time = 1;
            if (y_i < 3)
            {
                y_i++;
            }


            if (select_b)
            {
                if (num_i[x_i, y_i] != 0)
                {
                    y_i--;
                    //움직이지 못할 때
                    time = 0;
                }
                else
                {

                    SGM.GetComponent<SoundEvt>().soundItemWndAD();
                }
                SetRow();
            }
            else
            {
                SetSelect();
                SGM.GetComponent<SoundEvt>().soundItemWndAD();
            }

            StopMove();
        }
        //1t5t3t4t6t2
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
                    SGM.GetComponent<SoundEvt>().soundItemWndSelect();
                }
            }
            else
            {
                if (select_b)
                {
                    select_b = false;
                    num_i[x_i, y_i] = 0 + nowSelect_i;
                    nowSelect_i = 0;
                    SGM.GetComponent<SoundEvt>().soundItemWndSelect();

                    if (num_i[0, 0]==1)
                    {
                        if (num_i[1, 0] == 5)
                        {
                            if (num_i[2, 0] == 3)
                            {
                                if (num_i[0, 1] == 4)
                                {
                                    if (num_i[1, 1] == 6)
                                    {
                                        if (num_i[2, 1] == 2)
                                        {
                                            puzzleWin_obj.SetActive(false);
                                            GM.GetComponent<CheckPlayerEvent>().ItemSettingOnEvent();
                                            pan.SetActive(false);
                                            GMM.GetComponent<CharMove>().canMove = true;
                                            PlayerPrefs.SetInt("escdont", 0);
                                            SGM.GetComponent<SoundEvt>().soundItemSuccess();
                                            PlayerPrefs.SetInt("nowtalk", 0);
                                        }
                                    }
                                }
                            }
                        }
                    }
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

    /// <summary>
    /// 움직일 수 없을 때 바들바들 떤다
    /// </summary>
    void StopMove()
    {
        if (time==0)
        {
            SGM.GetComponent<SoundEvt>().soundItemFail();
        }
        StopCoroutine("FadeIn");
        StartCoroutine("FadeIn");
    }
    
    IEnumerator FadeIn()
    {

        while (time < 1f)
        {
            //Debug.Log(time);
            float a = select_obj.transform.position.x;
            if (time < 0.1f) //특정 위치에서 원점으로 이동
            {
                wood_obj[nowSelect_i].transform.position = movef_obj.transform.position;
            }
            else if (time < 0.2f) // 튕기고
            {
                wood_obj[nowSelect_i].transform.position = moveb_obj.transform.position;
            }
            else
            {
                wood_obj[nowSelect_i].transform.position = select_obj.transform.position;
            }
            //wood_obj[nowSelect_i].transform.position.x / 2f
            time += Time.deltaTime;
            yield return new WaitForSeconds(0.001f);
        }

    }

}
