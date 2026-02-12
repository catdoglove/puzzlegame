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

    public GameObject puzzleWin_obj, puzzleEvt_obj;

    public GameObject compleWin_obj;


    public GameObject wood_obj, woodEvt_obj;

    public Sprite wood_spr;


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
        target.Rotate(0, 0, 36f);   // Z축 기준 +45도 회전
        rottz();
    }

    public void RotateRight()
    {
        target.Rotate(0, 0, -36f);  // Z축 기준 -45도 회전
        rottz();
    }
    public void RotateLeft2()
    {
        target2.Rotate(0, 0, 36f);   // Z축 기준 +45도 회전
        rottz();
    }

    public void RotateRight2()
    {
        target2.Rotate(0, 0, -36f);  // Z축 기준 -45도 회전
        rottz();
    }
    public void RotateLeft3()
    {
        target3.Rotate(0, 0, 36f);   // Z축 기준 +45도 회전
        rottz();
    }

    public void RotateRight3()
    {
        target3.Rotate(0, 0, -36f);  // Z축 기준 -45도 회전
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
                    wood_obj.GetComponent<SpriteRenderer>().sprite = wood_spr;
                    select_obj[0].SetActive(false);
                    select_obj[1].SetActive(false);
                    select_obj[2].SetActive(false);
                    Invoke("Wait", 1.8f);
                }
            }
        }

    }


    void check()
    {
        if (p4_i[8] == 1)
        {
            SGM.GetComponent<SoundEvt>().soundBoom();
            main_obj.GetComponent<SpriteRenderer>().sprite = boom_spr;
            Main.GetComponent<SpriteRenderer>().sprite = boom_spr;
            compleWin_obj.SetActive(true);
            Invoke("Wait", 0.8f);


            GM.GetComponent<CharMove>().canMove = true;

        }
    }

    void Wait()
    {

        PlayerPrefs.SetInt("escdont", 0);
        PlayerPrefs.SetInt("cursorActive", 0);
        woodEvt_obj.SetActive(true);
        GM.GetComponent<CharMove>().canMove = true;

        puzzleWin_obj.SetActive(false);
        puzzleEvt_obj.SetActive(false);
    }

}
