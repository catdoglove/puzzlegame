using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMatch : MonoBehaviour
{
    public Sprite[] piece1_spr, piece2_spr, piece3_spr, piece4_spr;
    public int p1_i, p2_i, p3_i, p4_i;

    public Sprite[] pieceOri_spr;
    public int p_i;

    public GameObject[] piece_obj;
    public GameObject[] pieceOri_obj;
    public GameObject select_obj, back_obj;

    public int selet_i;

    public int name_i;

    public GameObject SGM;

    int fi = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (fi==1)
        {

        }
        else
        {

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (selet_i == 0)
            {

            }
            else
            {
                SGM.GetComponent<SoundEvt>().soundItemWndAD();
                int k = selet_i;
                selet_i--;
                int i = 0;
                while (i == 0)
                {
                    if (piece_obj[selet_i].activeSelf)
                    {
                        select_obj.transform.position = piece_obj[selet_i].transform.position;
                        i = 1;
                    }
                    else
                    {

                        if (selet_i == 0)
                        {
                            i = 1;
                            selet_i = k;
                        }
                        else
                        {
                            selet_i--;
                        }

                    }
                }
            }

        }
        else
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            /*
            while (i == 0)
            {
                if (piece_obj[selet_i].activeSelf)
                {
                    select_obj.transform.position = piece_obj[selet_i].transform.position;
                    i = 1;
                }
                else
                {

                    if (selet_i == 0)
                    {
                        i = 1;
                        selet_i = k;
                    }
                    else
                    {
                        selet_i--;
                    }

                }
            }
            */
        }
        else
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            /*
            while (i == 0)
            {
                if (piece_obj[selet_i].activeSelf)
                {
                    select_obj.transform.position = piece_obj[selet_i].transform.position;
                    i = 1;
                }
                else
                {

                    if (selet_i == 0)
                    {
                        i = 1;
                        selet_i = k;
                    }
                    else
                    {
                        selet_i--;
                    }

                }
            }
            */

        }
        else
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {

            if (selet_i == 11)
            {

            }
            else
            {
                SGM.GetComponent<SoundEvt>().soundItemWndAD();
                selet_i++;
                int k = selet_i;
                int i = 0;
                while (i == 0)
                {
                    if (piece_obj[selet_i].activeSelf)
                    {
                        select_obj.transform.position = piece_obj[selet_i].transform.position;
                        i = 1;
                    }
                    else
                    {

                        if (selet_i == 11)
                        {
                            i = 1;
                            selet_i = k;
                        }
                        else
                        {
                            selet_i++;
                        }

                    }
                }

            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            string str= piece_obj[selet_i].name;
            name_i= int.Parse(str.Substring(0, 1));
            int name2_i = int.Parse(str.Substring(1, 1))-1;

            SGM.GetComponent<SoundEvt>().soundItemWndSelect();

            switch (name_i)
            {
                case 0:
                    break;
                case 1:
                    if (p1_i==-1)
                    {
                        piece_obj[selet_i].SetActive(false);
                        pieceOri_obj[name_i - 1].SetActive(true);
                        pieceOri_obj[name_i - 1].GetComponent<SpriteRenderer>().sprite = piece1_spr[name2_i];

                        p1_i = selet_i;
                        
                        
                    }
                    else
                    {
                        if (3 == selet_i)
                        {
                            piece_obj[p1_i].SetActive(true);

                            pieceOri_obj[name_i - 1].SetActive(false);
                            p1_i = -1;
                            SGM.GetComponent<SoundEvt>().soundItemWndSelectNO();



                        }
                        else
                        {
                            piece_obj[selet_i].SetActive(false);
                            piece_obj[p1_i].SetActive(true);
                            pieceOri_obj[name_i - 1].GetComponent<SpriteRenderer>().sprite = piece1_spr[name2_i];

                            p1_i = selet_i;
                        }
                    }
                    break;
                case 2:
                    if (p2_i == -1)
                    {
                        piece_obj[selet_i].SetActive(false);
                        pieceOri_obj[name_i - 1].SetActive(true);
                        pieceOri_obj[name_i - 1].GetComponent<SpriteRenderer>().sprite = piece2_spr[name2_i];
                        
                        p2_i = selet_i;
                    }
                    else
                    {
                        if (4 == selet_i)
                        {
                            piece_obj[p2_i].SetActive(true);

                            pieceOri_obj[name_i - 1].SetActive(false);
                            p2_i = -1;
                            SGM.GetComponent<SoundEvt>().soundItemWndSelectNO();
                        }
                        else
                        {
                            piece_obj[selet_i].SetActive(false);
                            piece_obj[p2_i].SetActive(true);
                            pieceOri_obj[name_i - 1].GetComponent<SpriteRenderer>().sprite = piece2_spr[name2_i];

                            p2_i = selet_i;
                        }
                    }
                    break;
                case 3:
                    if (p3_i == -1)
                    {
                        piece_obj[selet_i].SetActive(false);
                        pieceOri_obj[name_i - 1].SetActive(true);
                        pieceOri_obj[name_i - 1].GetComponent<SpriteRenderer>().sprite = piece3_spr[name2_i];
                        
                        p3_i = selet_i;

                    }
                    else
                    {
                        if (8 == selet_i)
                        {
                            piece_obj[p3_i].SetActive(true);

                            pieceOri_obj[name_i - 1].SetActive(false);
                            p3_i = -1;
                            SGM.GetComponent<SoundEvt>().soundItemWndSelectNO();
                        }
                        else
                        {
                            piece_obj[selet_i].SetActive(false);
                            piece_obj[p3_i].SetActive(true);
                            pieceOri_obj[name_i - 1].GetComponent<SpriteRenderer>().sprite = piece3_spr[name2_i];

                            p3_i = selet_i;
                        }
                    }
                    break;
                case 4:
                    if (p4_i == -1)
                    {


                        piece_obj[selet_i].SetActive(false);
                        pieceOri_obj[name_i - 1].SetActive(true);
                        pieceOri_obj[name_i - 1].GetComponent<SpriteRenderer>().sprite = piece4_spr[name2_i];
                        
                        p4_i = selet_i;
                    }
                    else
                    {
                        if (11 == selet_i)
                        {
                            piece_obj[p4_i].SetActive(true);

                            pieceOri_obj[name_i - 1].SetActive(false);
                            p4_i = -1;
                            SGM.GetComponent<SoundEvt>().soundItemWndSelectNO();
                        }
                        else
                        {
                            piece_obj[selet_i].SetActive(false);
                            piece_obj[p4_i].SetActive(true);
                            pieceOri_obj[name_i - 1].GetComponent<SpriteRenderer>().sprite = piece4_spr[name2_i];

                            p4_i = selet_i;
                        }
                    }
                    break;
                default:
                    break;
            }
            SelectS();
        }
        if (p1_i==9&& p2_i == 5 && p3_i == 4 && p4_i == 10 )
        {
                fi = 1;
            SGM.GetComponent<SoundEvt>().soundItemSuccess();
            Invoke("Wait",2f);
        }


        }
    } 

    void Wait()
    {
        back_obj.SetActive(false);
    }

    void SelectS()
    {

        int k = selet_i;
        int i = 0;
        while (i == 0)
        {
            selet_i--;
            if (selet_i<0)
            {
                selet_i = 0;
            }
            if (piece_obj[selet_i].activeSelf)
            {
                select_obj.transform.position = piece_obj[selet_i].transform.position;
                i = 1;
            }
            else
            {

                if (selet_i <= 0)
                {
                    while (i == 0)
                    {
                        selet_i++;
                        if (piece_obj[selet_i].activeSelf)
                        {
                            select_obj.transform.position = piece_obj[selet_i].transform.position;
                            i = 1;
                        }
                    }
                }

            }
        }
    }
}
