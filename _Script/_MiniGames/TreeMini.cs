using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TreeMini : MonoBehaviour
{
    public int[] p0_i, p1_i, p2_i, p3_i, p4_i;

    public int selet_i, type_i, level_i;

    public GameObject SGM, GM, GMM, Main;

    public GameObject[] block0_obj, block1_obj, block2_obj, block3_obj, block4_obj;
    public GameObject[] block0T_obj, block1T_obj, block2T_obj, block3T_obj, block4T_obj;
    public GameObject[] block0B_obj, block1B_obj, block2B_obj, block3B_obj, block4B_obj;

    public GameObject[] select_obj, selectOn_obj;

    public GameObject back_obj, main_obj, ori_obj, this_obj, rock_obj, broken_obj, mark_obj;

    public int where_i;

    public Sprite boom_spr;

    public GameObject be_obj;



    public Transform target, target2, target3;   // 회전시킬 오브젝트

    public GameObject puzzleWin_obj;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("cursorActive", 1);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("cursorActive", 1);
    }


    public void SelectButton1()
    {
    }
    public void SelectButton2()
    {
        select_obj[1].SetActive(false);
        select_obj[2].SetActive(false);
        select_obj[0].SetActive(true);
        SGM.GetComponent<SoundEvt>().soundItemWndAD();
    }
    public void SelectButton3()
    {
        select_obj[0].SetActive(false);
        select_obj[2].SetActive(false);
        select_obj[1].SetActive(true);
        SGM.GetComponent<SoundEvt>().soundItemWndAD();
    }
    public void SelectButton4()
    {
        select_obj[0].SetActive(false);
        select_obj[1].SetActive(false);
        select_obj[2].SetActive(true);
        SGM.GetComponent<SoundEvt>().soundItemWndAD();
    }

    public void SelectButton()
    {
        SGM.GetComponent<SoundEvt>().soundItemWndAD();
        Main.GetComponent<MiniBoom>().main_obj = ori_obj;
        Main.GetComponent<MiniBoom>().where_i = where_i;
        Main.GetComponent<MiniBoom>().level_i = level_i;
        Main.GetComponent<MiniBoom>().this_obj = this.gameObject;
        for (int i = 0; i < select_obj.Length; i++)
        {
            select_obj[i].SetActive(true);
        }
        select_obj[0].SetActive(false);

        for (int i = 0; i < select_obj.Length; i++)
        {
            selectOn_obj[i].SetActive(false);
        }
        selectOn_obj[0].SetActive(true);
    }



    public void RotateLeft()
    {
        target.Rotate(0, 0, 45f);   // Z축 기준 +45도 회전
        rottz();
    }

    public void RotateRight()
    {
        target.Rotate(0, 0, -45f);  // Z축 기준 -45도 회전
        rottz();
    }
    public void RotateLeft2()
    {
        target2.Rotate(0, 0, 45f);   // Z축 기준 +45도 회전
        rottz();
    }

    public void RotateRight2()
    {
        target2.Rotate(0, 0, -45f);  // Z축 기준 -45도 회전
        rottz();
    }
    public void RotateLeft3()
    {
        target3.Rotate(0, 0, 45f);   // Z축 기준 +45도 회전
        rottz();
    }

    public void RotateRight3()
    {
        target3.Rotate(0, 0, -45f);  // Z축 기준 -45도 회전
        rottz();
    }

    void rottz()
    {
        SGM.GetComponent<SoundEvt>().soundItemWndAD();
        if (target.rotation.z < 0.01f && target.rotation.z > -0.01f)
        {

            if (target2.rotation.z < 0.01f && target2.rotation.z > -0.01f)
            {

                if (target3.rotation.z < 0.01f && target3.rotation.z > -0.01f)
                {
                    SGM.GetComponent<SoundEvt>().soundItemSuccess();

                    Invoke("Wait", 1.8f);
                }
            }
        }

    }

    public void Up()
    {

        SGM.GetComponent<SoundEvt>().soundItemFail();
        switch (level_i)
        {
            case 0:
                break;
            case 1:
                if (p0_i[where_i] != 1 && p0_i[where_i + 1] != 1)
                {
                    main_obj.transform.position = block0_obj[where_i].transform.position;
                    p0_i[where_i] = 1;
                    p0_i[where_i + 1] = 1;
                    p1_i[where_i] = 0;
                    p1_i[where_i + 1] = 0;
                    MinUp();
                }
                break;
            case 2:
                if (p1_i[where_i] != 1 && p1_i[where_i + 1] != 1)
                {
                    main_obj.transform.position = block1_obj[where_i].transform.position;
                    p1_i[where_i] = 1;
                    p1_i[where_i + 1] = 1;
                    p2_i[where_i] = 0;
                    p2_i[where_i + 1] = 0;
                    MinUp();
                }
                break;
            case 3:
                if (p2_i[where_i] != 1 && p2_i[where_i + 1] != 1)
                {
                    main_obj.transform.position = block2_obj[where_i].transform.position;
                    p2_i[where_i] = 1;
                    p2_i[where_i + 1] = 1;
                    p3_i[where_i] = 0;
                    p3_i[where_i + 1] = 0;
                    MinUp();
                }
                break;
            case 4:
                if (p3_i[where_i] != 1 && p3_i[where_i + 1] != 1)
                {
                    main_obj.transform.position = block3_obj[where_i].transform.position;
                    p3_i[where_i] = 1;
                    p3_i[where_i + 1] = 1;
                    p4_i[where_i] = 0;
                    p4_i[where_i + 1] = 0;
                    MinUp();
                }

                break;
            default:
                break;
        }
    }

    public void UpS()
    {
        SGM.GetComponent<SoundEvt>().soundItemFail();
        switch (level_i)
        {
            case 0:
                break;
            case 1:
                if (p0_i[where_i] != 1)
                {
                    main_obj.transform.position = block0T_obj[where_i - 2].transform.position;
                    p0_i[where_i] = 1;
                    p2_i[where_i] = 0;
                    MinUp();
                }
                break;
            case 2:
                if (p1_i[where_i] != 1)
                {
                    main_obj.transform.position = block1T_obj[where_i - 2].transform.position;
                    p1_i[where_i] = 1;
                    p3_i[where_i] = 0;
                    MinUp();
                }
                break;
            case 3:
                if (p2_i[where_i] != 1)
                {
                    main_obj.transform.position = block2T_obj[where_i - 2].transform.position;
                    p2_i[where_i] = 1;
                    p4_i[where_i] = 0;
                    MinUp();
                }
                break;
            case 4:
                break;
            default:
                break;
        }
    }

    public void UpSB()
    {
        SGM.GetComponent<SoundEvt>().soundItemFail();
        switch (level_i)
        {
            case 0:
                break;
            case 1:
                if (p0_i[where_i] != 1 && p0_i[where_i + 1] != 1 && p0_i[where_i - 1] != 1)
                {
                    main_obj.transform.position = block0B_obj[where_i - 3].transform.position;

                    p0_i[where_i - 1] = 1;
                    p0_i[where_i] = 1;
                    p0_i[where_i + 1] = 1;

                    p1_i[where_i - 1] = 0;
                    p1_i[where_i] = 0;
                    p1_i[where_i + 1] = 0;
                    MinUp();
                }
                break;
            case 2:
                if (p1_i[where_i] != 1 && p1_i[where_i + 1] != 1 && p1_i[where_i - 1] != 1)
                {
                    main_obj.transform.position = block1B_obj[where_i - 3].transform.position;

                    p1_i[where_i - 1] = 1;
                    p1_i[where_i] = 1;
                    p1_i[where_i + 1] = 1;

                    p2_i[where_i - 1] = 0;
                    p2_i[where_i] = 0;
                    p2_i[where_i + 1] = 0;
                    MinUp();
                }
                break;
            case 3:
                if (p2_i[where_i] != 1 && p2_i[where_i + 1] != 1 && p2_i[where_i - 1] != 1)
                {
                    main_obj.transform.position = block2B_obj[where_i - 3].transform.position;
                    p2_i[where_i - 1] = 1;
                    p2_i[where_i] = 1;
                    p2_i[where_i + 1] = 1;

                    p3_i[where_i - 1] = 0;
                    p3_i[where_i] = 0;
                    p3_i[where_i + 1] = 0;
                    MinUp();
                }
                break;
            case 4:
                if (p3_i[where_i] != 1 && p3_i[where_i + 1] != 1 && p3_i[where_i - 1] != 1)
                {
                    main_obj.transform.position = block3B_obj[where_i - 3].transform.position;
                    p3_i[where_i - 1] = 1;
                    p3_i[where_i] = 1;
                    p3_i[where_i + 1] = 1;

                    p4_i[where_i - 1] = 0;
                    p4_i[where_i] = 0;
                    p4_i[where_i + 1] = 0;
                    MinUp();
                }

                break;
            default:
                break;
        }
    }

    void MinUp()
    {
        level_i--;
        this_obj.GetComponent<MiniBoom>().level_i = level_i;
        SGM.GetComponent<SoundEvt>().soundItemWndAD();
        check();
    }


    public void Down()
    {
        SGM.GetComponent<SoundEvt>().soundItemFail();
        switch (level_i)
        {
            case 0:
                if (p1_i[where_i] != 1 && p1_i[where_i + 1] != 1)
                {
                    main_obj.transform.position = block1_obj[where_i].transform.position;
                    p1_i[where_i] = 1;
                    p1_i[where_i + 1] = 1;
                    p0_i[where_i] = 0;
                    p0_i[where_i + 1] = 0;
                    SumDown();
                }
                break;
            case 1:
                if (p2_i[where_i] != 1 && p2_i[where_i + 1] != 1)
                {
                    main_obj.transform.position = block2_obj[where_i].transform.position;
                    p2_i[where_i] = 1;
                    p2_i[where_i + 1] = 1;
                    p1_i[where_i] = 0;
                    p1_i[where_i + 1] = 0;
                    SumDown();
                }
                break;
            case 2:
                if (p3_i[where_i] != 1 && p3_i[where_i + 1] != 1)
                {
                    main_obj.transform.position = block3_obj[where_i].transform.position;
                    p3_i[where_i] = 1;
                    p3_i[where_i + 1] = 1;
                    p2_i[where_i] = 0;
                    p2_i[where_i + 1] = 0;
                    SumDown();
                }
                break;
            case 3:
                if (p4_i[where_i] != 1 && p4_i[where_i + 1] != 1)
                {
                    main_obj.transform.position = block4_obj[where_i].transform.position;
                    p4_i[where_i] = 1;
                    p4_i[where_i + 1] = 1;
                    p3_i[where_i] = 0;
                    p3_i[where_i + 1] = 0;
                    SumDown();
                }
                break;
            case 4:

                break;
            default:
                break;
        }
    }

    public void DownS()
    {
        SGM.GetComponent<SoundEvt>().soundItemFail();
        switch (level_i)
        {
            case 0:
                if (p2_i[where_i] != 1)
                {
                    main_obj.transform.position = block1T_obj[where_i - 2].transform.position;
                    p2_i[where_i] = 1;
                    p0_i[where_i] = 0;
                    SumDown();
                }
                break;
            case 1:
                if (p3_i[where_i] != 1)
                {
                    main_obj.transform.position = block2T_obj[where_i - 2].transform.position;
                    p3_i[where_i] = 1;
                    p1_i[where_i] = 0;
                    SumDown();
                }
                break;
            case 2:
                if (p4_i[where_i] != 1)
                {
                    main_obj.transform.position = block3T_obj[where_i - 2].transform.position;
                    p4_i[where_i] = 1;
                    p2_i[where_i] = 0;
                    SumDown();
                }
                break;
            case 3:
                break;
            case 4:

                break;
            default:
                break;
        }
    }

    public void DownSB()
    {
        SGM.GetComponent<SoundEvt>().soundItemFail();
        switch (level_i)
        {
            case 0:
                if (p1_i[where_i] != 1 && p1_i[where_i + 1] != 1 && p1_i[where_i - 1] != 1)
                {
                    main_obj.transform.position = block1B_obj[where_i - 3].transform.position;
                    p1_i[where_i - 1] = 1;
                    p1_i[where_i] = 1;
                    p1_i[where_i + 1] = 1;

                    p0_i[where_i - 1] = 0;
                    p0_i[where_i] = 0;
                    p0_i[where_i + 1] = 0;
                    SumDown();
                }
                break;
            case 1:
                if (p2_i[where_i] != 1 && p2_i[where_i + 1] != 1 && p2_i[where_i - 1] != 1)
                {
                    main_obj.transform.position = block2B_obj[where_i - 3].transform.position;
                    p2_i[where_i - 1] = 1;
                    p2_i[where_i] = 1;
                    p2_i[where_i + 1] = 1;

                    p1_i[where_i - 1] = 0;
                    p1_i[where_i] = 0;
                    p1_i[where_i + 1] = 0;
                    SumDown();
                }
                break;
            case 2:
                if (p3_i[where_i] != 1 && p3_i[where_i + 1] != 1 && p3_i[where_i - 1] != 1)
                {
                    main_obj.transform.position = block3B_obj[where_i - 3].transform.position;
                    p3_i[where_i - 1] = 1;
                    p3_i[where_i] = 1;
                    p3_i[where_i + 1] = 1;

                    p2_i[where_i - 1] = 0;
                    p2_i[where_i] = 0;
                    p2_i[where_i + 1] = 0;
                    SumDown();
                }
                break;
            case 3:
                if (p4_i[where_i] != 1 && p4_i[where_i + 1] != 1 && p4_i[where_i - 1] != 1)
                {
                    main_obj.transform.position = block4B_obj[where_i - 3].transform.position;
                    p4_i[where_i - 1] = 1;
                    p4_i[where_i] = 1;
                    p4_i[where_i + 1] = 1;

                    p3_i[where_i - 1] = 0;
                    p3_i[where_i] = 0;
                    p3_i[where_i + 1] = 0;
                    SumDown();
                }

                break;
            case 4:

                break;
            default:
                break;
        }
    }
    void SumDown()
    {
        level_i++;
        this_obj.GetComponent<MiniBoom>().level_i = level_i;
        SGM.GetComponent<SoundEvt>().soundItemWndAD();
        check();
    }


    public void R()
    {
        SGM.GetComponent<SoundEvt>().soundItemFail();
        switch (level_i)
        {
            case 0:
                if (p0_i[where_i + 2] != 1)
                {
                    main_obj.transform.position = block0_obj[where_i + 1].transform.position;
                    p0_i[where_i + 2] = 1;
                    p0_i[where_i] = 0;
                    Sum();
                }
                break;
            case 1:
                if (p1_i[where_i + 2] != 1)
                {
                    main_obj.transform.position = block1_obj[where_i + 1].transform.position;
                    p1_i[where_i + 2] = 1;
                    p1_i[where_i] = 0;
                    Sum();
                }
                break;
            case 2:
                if (p2_i[where_i + 2] != 1)
                {
                    main_obj.transform.position = block2_obj[where_i + 1].transform.position;
                    p2_i[where_i + 2] = 1;
                    p2_i[where_i] = 0;
                    Sum();
                }
                break;
            case 3:
                if (p3_i[where_i + 2] != 1)
                {
                    main_obj.transform.position = block3_obj[where_i + 1].transform.position;
                    p3_i[where_i + 2] = 1;
                    p3_i[where_i] = 0;
                    Sum();
                }
                break;
            case 4:
                if (p4_i[where_i + 2] != 1)
                {
                    main_obj.transform.position = block4_obj[where_i + 1].transform.position;
                    p4_i[where_i + 2] = 1;
                    p4_i[where_i] = 0;
                    Sum();
                }
                break;
            default:
                break;
        }
    }
    public void RS()
    {
        SGM.GetComponent<SoundEvt>().soundItemFail();
        switch (level_i)
        {
            case 0:
                if (p0_i[where_i + 1] != 1 && p1_i[where_i + 1] != 1)
                {
                    main_obj.transform.position = block0T_obj[where_i - 1].transform.position;
                    p0_i[where_i + 1] = 1;
                    p0_i[where_i] = 0;
                    p1_i[where_i + 1] = 1;
                    p1_i[where_i] = 0;
                    Sum();
                }
                break;
            case 1:
                if (p1_i[where_i + 1] != 1 && p2_i[where_i + 1] != 1)
                {
                    main_obj.transform.position = block1T_obj[where_i - 1].transform.position;
                    p1_i[where_i + 1] = 1;
                    p1_i[where_i] = 0;
                    p2_i[where_i + 1] = 1;
                    p2_i[where_i] = 0;
                    Sum();
                }
                break;
            case 2:
                if (p2_i[where_i + 1] != 1 && p3_i[where_i + 1] != 1)
                {
                    main_obj.transform.position = block2T_obj[where_i - 1].transform.position;
                    p2_i[where_i + 1] = 1;
                    p2_i[where_i] = 0;
                    p3_i[where_i + 1] = 1;
                    p3_i[where_i] = 0;
                    Sum();
                }
                break;
            case 3:
                if (p3_i[where_i + 1] != 1 && p4_i[where_i + 1] != 1)
                {
                    main_obj.transform.position = block3T_obj[where_i - 1].transform.position;
                    p3_i[where_i + 1] = 1;
                    p3_i[where_i] = 0;
                    p4_i[where_i + 1] = 1;
                    p4_i[where_i] = 0;
                    Sum();
                }
                break;
            case 4:
                break;
            default:
                break;
        }
    }


    public void RSB()
    {
        SGM.GetComponent<SoundEvt>().soundItemFail();
        switch (level_i)
        {
            case 0:
                if (p0_i[where_i + 2] != 1)
                {
                    main_obj.transform.position = block0B_obj[where_i - 2].transform.position;
                    p0_i[where_i + 2] = 1;
                    p0_i[where_i - 1] = 0;
                    Sum();
                }
                break;
            case 1:
                if (p1_i[where_i + 2] != 1)
                {
                    main_obj.transform.position = block1B_obj[where_i - 2].transform.position;
                    p1_i[where_i + 2] = 1;
                    p1_i[where_i - 1] = 0;
                    Sum();
                }
                break;
            case 2:
                if (p2_i[where_i + 2] != 1)
                {
                    main_obj.transform.position = block2B_obj[where_i - 2].transform.position;
                    p2_i[where_i + 2] = 1;
                    p2_i[where_i - 1] = 0;
                    Sum();
                }
                break;
            case 3:
                if (p3_i[where_i + 2] != 1)
                {
                    main_obj.transform.position = block3B_obj[where_i - 2].transform.position;
                    p3_i[where_i + 2] = 1;
                    p3_i[where_i - 1] = 0;
                    Sum();
                }
                break;
            case 4:
                if (p4_i[where_i + 2] != 1)
                {
                    main_obj.transform.position = block4B_obj[where_i - 2].transform.position;
                    p4_i[where_i + 2] = 1;
                    p4_i[where_i - 1] = 0;
                    Sum();
                }
                break;
            default:
                break;
        }
    }

    void Sum()
    {
        where_i++;
        this_obj.GetComponent<MiniBoom>().where_i = where_i;
        SGM.GetComponent<SoundEvt>().soundItemWndAD();
        check();
    }

    public void L()
    {
        SGM.GetComponent<SoundEvt>().soundItemFail();
        switch (level_i)
        {
            case 0:
                if (where_i > 1)
                {
                    if (p0_i[where_i - 1] != 1)
                    {
                        main_obj.transform.position = block0_obj[where_i - 1].transform.position;
                        p0_i[where_i - 1] = 1;
                        p0_i[where_i + 1] = 0;
                        Min();
                    }
                }
                break;
            case 1:
                if (p1_i[where_i - 1] != 1)
                {
                    main_obj.transform.position = block1_obj[where_i - 1].transform.position;
                    p1_i[where_i - 1] = 1;
                    p1_i[where_i + 1] = 0;
                    Min();
                }
                break;
            case 2:
                if (p2_i[where_i - 1] != 1)
                {
                    main_obj.transform.position = block2_obj[where_i - 1].transform.position;
                    p2_i[where_i - 1] = 1;
                    p2_i[where_i + 1] = 0;
                    Min();
                }
                break;
            case 3:
                if (p3_i[where_i - 1] != 1)
                {
                    main_obj.transform.position = block3_obj[where_i - 1].transform.position;
                    p3_i[where_i - 1] = 1;
                    p3_i[where_i + 1] = 0;
                    Min();
                }
                break;
            case 4:
                if (p4_i[where_i - 1] != 1)
                {
                    main_obj.transform.position = block4_obj[where_i - 1].transform.position;
                    p4_i[where_i - 1] = 1;
                    p4_i[where_i + 1] = 0;
                    Min();
                }
                break;
            default:
                break;
        }
    }

    public void LS()
    {
        SGM.GetComponent<SoundEvt>().soundItemFail();
        switch (level_i)
        {
            case 0:
                if (where_i > 2)
                {
                    if (p0_i[where_i - 1] != 1 && p1_i[where_i - 1] != 1)
                    {
                        main_obj.transform.position = block0T_obj[where_i - 3].transform.position;
                        p0_i[where_i - 1] = 1;
                        p0_i[where_i] = 0;
                        p1_i[where_i - 1] = 1;
                        p1_i[where_i] = 0;
                        Min();
                    }
                }
                break;
            case 1:
                if (p1_i[where_i - 1] != 1 && p2_i[where_i - 1] != 1)
                {
                    main_obj.transform.position = block1T_obj[where_i - 3].transform.position;
                    p1_i[where_i - 1] = 1;
                    p1_i[where_i] = 0;
                    p2_i[where_i - 1] = 1;
                    p2_i[where_i] = 0;
                    Min();
                }
                break;
            case 2:
                if (p2_i[where_i - 1] != 1 && p3_i[where_i - 1] != 1)
                {
                    main_obj.transform.position = block2T_obj[where_i - 3].transform.position;
                    p2_i[where_i - 1] = 1;
                    p2_i[where_i] = 0;
                    p3_i[where_i - 1] = 1;
                    p3_i[where_i] = 0;
                    Min();
                }
                break;
            case 3:
                if (p3_i[where_i - 1] != 1 && p4_i[where_i - 1] != 1)
                {
                    main_obj.transform.position = block3T_obj[where_i - 3].transform.position;
                    p3_i[where_i - 1] = 1;
                    p3_i[where_i] = 0;
                    p4_i[where_i - 1] = 1;
                    p4_i[where_i] = 0;
                    Min();
                }
                break;
            case 4:
                break;
            default:
                break;
        }
    }

    public void LSB()
    {
        SGM.GetComponent<SoundEvt>().soundItemFail();
        switch (level_i)
        {
            case 0:
                if (where_i > 3)
                {
                    if (p0_i[where_i - 2] != 1)
                    {
                        main_obj.transform.position = block0B_obj[where_i - 4].transform.position;
                        p0_i[where_i - 2] = 1;
                        p0_i[where_i + 1] = 0;
                        Min();
                    }
                }
                break;
            case 1:
                if (p1_i[where_i - 2] != 1)
                {
                    main_obj.transform.position = block1B_obj[where_i - 4].transform.position;
                    p1_i[where_i - 2] = 1;
                    p1_i[where_i + 1] = 0;
                    Min();
                }
                break;
            case 2:
                if (p2_i[where_i - 2] != 1)
                {
                    main_obj.transform.position = block2B_obj[where_i - 4].transform.position;
                    p2_i[where_i - 2] = 1;
                    p2_i[where_i + 1] = 0;
                    Min();
                }
                break;
            case 3:
                if (p3_i[where_i - 2] != 1)
                {
                    main_obj.transform.position = block3B_obj[where_i - 4].transform.position;
                    p3_i[where_i - 2] = 1;
                    p3_i[where_i + 1] = 0;
                    Min();
                }
                break;
            case 4:
                if (p4_i[where_i - 2] != 1)
                {
                    main_obj.transform.position = block4B_obj[where_i - 4].transform.position;
                    p4_i[where_i - 2] = 1;
                    p4_i[where_i + 1] = 0;
                    Min();
                }
                break;
            default:
                break;
        }
    }




    void Min()
    {
        where_i--;
        this_obj.GetComponent<MiniBoom>().where_i = where_i;
        SGM.GetComponent<SoundEvt>().soundItemWndAD();
        check();
    }

    void check()
    {
        if (p4_i[8] == 1)
        {
            SGM.GetComponent<SoundEvt>().soundBoom();
            main_obj.GetComponent<SpriteRenderer>().sprite = boom_spr;
            Main.GetComponent<SpriteRenderer>().sprite = boom_spr;
            Invoke("Wait", 0.8f);

            GM.GetComponent<CharMove>().canMove = true;

        }
    }

    void Wait()
    {

        puzzleWin_obj.SetActive(false);
        PlayerPrefs.SetInt("escdont", 0);
        //GMM.GetComponent<CharMove>().canMove = true;
        PlayerPrefs.SetInt("cursorActive", 0);
        //GM.GetComponent<CheckPlayer>().ItemSettings();
        //japan_obj.SetActive(false);
        //back_obj.SetActive(false);

        GM.GetComponent<CharMove>().canMove = true;
    }

}
