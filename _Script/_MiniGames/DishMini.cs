using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DishMini : MonoBehaviour
{

    public GameObject win_obj;

    public GameObject[] al_obj;
    public Sprite[] al_spr;
    public int num_i;
    public int select_i = 0;

    public int[] save_i;

    public GameObject SGM, GM, GMM;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("cursorActive", 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //24031
    public void SetSel()
    {
        if (PlayerPrefs.GetInt("findish", 0)==0)
        {
            select_i++;
            if (select_i >= 5)
            {
                select_i = 0;
            }
            al_obj[num_i].GetComponent<Image>().sprite = al_spr[select_i];
            SGM.GetComponent<SoundEvt>().soundItemWndAD();

            GM.GetComponent<DishMini>().SaveSel(num_i, select_i);
        }
    }

    public void SaveSel(int num_ii, int select_ii)
    {
        int a = 0;



        save_i[num_ii] = select_ii;

        if (save_i[0] == 2)
        {
            a++;
        }
        if (save_i[1] == 4)
        {
            a++;
        }
        if (save_i[2] == 0)
        {
            a++;
        }
        if (save_i[3] == 3)
        {
            a++;
        }
        if (save_i[4] == 1)
        {
            a++;
        }
        if (a == 5)
        {

            SGM.GetComponent<SoundEvt>().soundItemSuccess();
            PlayerPrefs.SetInt("findish",1);
            Invoke("Wait", 0.8f);
        }

    }


    void Wait()
    {
        win_obj.SetActive(false);
        GMM.GetComponent<CharMove>().canMove = true;
    }
}
