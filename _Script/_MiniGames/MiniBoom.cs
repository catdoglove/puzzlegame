using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBoom : MonoBehaviour
{

    public int[] p0_i,p1_i, p2_i, p3_i, p4_i;

    public int selet_i, type_i, level_i;

    public GameObject SGM,GM, GMM;

    public GameObject[] block0_obj, block1_obj, block2_obj, block3_obj, block4_obj;

    public GameObject[] select_obj,selectOn_obj;

    public GameObject back_obj,main_obj;

    public int where_i;

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

    public void SelectButton()
    {

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

    public void Up()
    {
        switch (level_i)
        {
            case 0:
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

        switch (type_i)
        {
            case 0:
                break;
            default:
                break;
        }
    }
    public void Down()
    {

    }
    public void R()
    {
        switch (level_i)
        {
            case 0:
                if (p0_i[where_i+2] != 1)
                {
                    main_obj.transform.position = block0_obj[where_i+1].transform.position;
                    p0_i[where_i + 2] = 1;
                    p0_i[where_i] = 0;
                    where_i++;
                }
                break;
            case 1:
                if (p1_i[where_i + 1] != 1)
                {
                    main_obj.transform.position = block1_obj[where_i + 1].transform.position;
                }
                break;
            case 2:
                if (p2_i[where_i + 1] != 1)
                {
                    main_obj.transform.position = block2_obj[where_i + 1].transform.position;
                }
                break;
            case 3:
                if (p3_i[where_i + 1] != 1)
                {
                    main_obj.transform.position = block3_obj[where_i + 1].transform.position;
                }
                break;
            case 4:
                if (p4_i[where_i + 1] != 1)
                {
                    main_obj.transform.position = block4_obj[where_i + 1].transform.position;
                }
                break;
            default:
                break;
        }
    }
    public void L()
    {
        switch (level_i)
        {
            case 0:
                if (where_i>0)
                {
                    if (p0_i[where_i - 1] != 1)
                    {
                        main_obj.transform.position = block0_obj[where_i - 1].transform.position;
                        p0_i[where_i - 1] = 1;
                        p0_i[where_i+1] = 0;
                        where_i--;
                    }
                }
                break;
            case 1:
                if (p1_i[where_i + 1] != 1)
                {
                    main_obj.transform.position = block1_obj[where_i + 1].transform.position;
                }
                break;
            case 2:
                if (p2_i[where_i + 1] != 1)
                {
                    main_obj.transform.position = block2_obj[where_i + 1].transform.position;
                }
                break;
            case 3:
                if (p3_i[where_i + 1] != 1)
                {
                    main_obj.transform.position = block3_obj[where_i + 1].transform.position;
                }
                break;
            case 4:
                if (p4_i[where_i + 1] != 1)
                {
                    main_obj.transform.position = block4_obj[where_i + 1].transform.position;
                }
                break;
            default:
                break;
        }
    }

    void Wait()
    {

        //puzzleWin_obj.SetActive(false);
        PlayerPrefs.SetInt("escdont", 0);
        GMM.GetComponent<CharMove>().canMove = true;
        //PlayerPrefs.SetInt("cursorActive", 0);
        GM.GetComponent<CheckPlayer>().ItemSettings();
        //SGM.GetComponent<SoundEvt>().soundItemSuccess();
        //japan_obj.SetActive(false);
        back_obj.SetActive(false);
        PlayerPrefs.SetInt("nowtalk", 0);
        //GM.SetActive(false);
    }
    
}
