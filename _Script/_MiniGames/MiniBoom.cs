using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBoom : MonoBehaviour
{
    public Sprite[] piece1_spr, piece2_spr, piece3_spr, piece4_spr;
    public int p1_i, p2_i, p3_i, p4_i;

    public Sprite[] pieceOri_spr;
    public int p_i;

    public GameObject[] piece_obj, piecePos_obj;
    public GameObject[] pieceOri_obj;
    public GameObject select_obj, back_obj;

    public int selet_i;

    public int name_i;

    public GameObject SGM,GM, GMM;

    int fi = 0;

    public GameObject[] block0_obj, block1_obj, block2_obj, block3_obj;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
                select_obj.transform.position = piecePos_obj[selet_i].transform.position;
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
                            select_obj.transform.position = piecePos_obj[selet_i].transform.position;
                            i = 1;
                        }
                    }
                }

            }
        }
    }
}
