using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickMIni : MonoBehaviour
{
    public GameObject stickWin_obj,sap1_obj, sap2_obj, stick1_obj, stick2_obj, stickKey1_obj, stickKey2_obj, stickKey3_obj;
    public Sprite[] stick_spr;
    public int a_i;
    //public GameObject SGM,CPGM, CPSGM;
    public int a = 0;
    public int b = 0;
    public GameObject SGM, GM, GMM;
    public GameObject s_obj;

    float wait_f=0.3f;


    float time = 0;
    float time2 = 0;
    public float _size = 1;
    public float _upSizeTime;
    public GameObject game_obj, game2_obj, select_obj, moveb_obj, movef_obj;

    // Start is called before the first frame update
    void Start()
    {
    }

    /*
     * W > 2번
     * D > 2번
     * A > 2번
    */

    private void OnEnable()
    {
        stick1_obj.GetComponent<SpriteRenderer>().sprite = stick_spr[0];
        stick2_obj.GetComponent<SpriteRenderer>().sprite = stick_spr[0];

        a = 0;
        a_i = 0;
        StopCoroutine("Press");
        StartCoroutine("Press");
      
    }


    void WPress()
    {
        if (a_i==0)
        {
            SGM.GetComponent<SoundEvt>().soundItemFail();
            sap1_obj.SetActive(false);
            stick1_obj.GetComponent<SpriteRenderer>().sprite = stick_spr[1];
        }
        else if (a_i==1)
        {
            SGM.GetComponent<SoundEvt>().soundItemFail();
            sap1_obj.SetActive(false);
            sap2_obj.SetActive(false);
            stick2_obj.GetComponent<SpriteRenderer>().sprite = stick_spr[1];
            stick1_obj.GetComponent<SpriteRenderer>().sprite = stick_spr[1];
            stickKey1_obj.SetActive(true);
        }

    }



    void APress()
    {
        if (a_i == 9)
        {
            SGM.GetComponent<SoundEvt>().soundItemFail();
            stick2_obj.GetComponent<SpriteRenderer>().sprite = stick_spr[2];
            stickKey2_obj.SetActive(false);
        }
        else if (a_i==12)
        {
            SGM.GetComponent<SoundEvt>().soundItemFail();
            stick2_obj.GetComponent<SpriteRenderer>().sprite = stick_spr[3];
        }
    }

    void DPress()
    {
        if (a_i == 3 )
        {
            SGM.GetComponent<SoundEvt>().soundItemFail();
            stick1_obj.GetComponent<SpriteRenderer>().sprite = stick_spr[2];
            stickKey1_obj.SetActive(false);
        }
        else if (a_i == 6)
        {
            SGM.GetComponent<SoundEvt>().soundItemFail();
            stick1_obj.GetComponent<SpriteRenderer>().sprite = stick_spr[3];
            stickKey2_obj.SetActive(true);
        }
    }


    IEnumerator Press()
    {
        while (a==0)
        {
            if (a_i >= 13)
            {
                yield return new WaitForSeconds(0.2f);
                stickWin_obj.SetActive(false);
                GM.GetComponent<CheckPlayerEvent>().GetS();
                //pan.SetActive(false);
                GMM.GetComponent<CharMove>().canMove = true;
                PlayerPrefs.SetInt("escdont", 0);
                SGM.GetComponent<SoundEvt>().soundItemSuccess();
                PlayerPrefs.SetInt("nowtalk", 0);
                s_obj.SetActive(false);


                if (b==0)
                {
                 //   CPGM.GetComponent<CheckPlayer>().EventNum_i[CPGM.GetComponent<CheckPlayer>().num] = 15;
                 //   CPGM.GetComponent<CheckPlayer>().EventSetting();
                    b = 1;
                }
                else
                {
                 //   CPSGM.GetComponent<CheckPlayer>().EventNum_i[CPGM.GetComponent<CheckPlayer>().num] = 15;
                 //   CPSGM.GetComponent<CheckPlayer>().EventSetting();
                }
                a = 1;
            }
            else
            {

                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    if (a_i <= 1)
                    {
                        yield return new WaitForSeconds(0.2f);
                        ///   SGM.GetComponent<SoundEvt>().auSE.GetComponent<AudioSource>().pitch = 1f;
                        // SGM.GetComponent<SoundEvt>().soundstick();
                        WPress();
                        a_i++;
                        yield return new WaitForSeconds(wait_f);
                    }

                }


                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    if (a_i >= 7)
                    {
                    ///   SGM.GetComponent<SoundEvt>().auSE.GetComponent<AudioSource>().pitch = 1f;
                       // SGM.GetComponent<SoundEvt>().soundstick();
                        APress();
                        a_i++;
                        time2 = 0;
                        StopCoroutine("FadeIn2");
                        StartCoroutine("FadeIn2");
                        yield return new WaitForSeconds(wait_f);
                    }

                }

                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if (a_i > 1 && a_i < 7)
                    {
                     //   SGM.GetComponent<SoundEvt>().auSE.GetComponent<AudioSource>().pitch = 1f;
                       // SGM.GetComponent<SoundEvt>().soundstick();
                        DPress();
                        a_i++;
                        time = 0;
                        StopCoroutine("FadeIn");
                        StartCoroutine("FadeIn");
                        yield return new WaitForSeconds(wait_f);
                    }
                }



            }

            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator FadeIn()
    {

        while (time < 1f)
        {
            //Debug.Log(time);
            //float a = select_obj.transform.position.x;

            if (time < 0.1f) //특정 위치에서 원점으로 이동
            {
                game_obj.transform.position = movef_obj.transform.position;
            }
            else if (time < 0.2f) // 튕기고
            {
                game_obj.transform.position = moveb_obj.transform.position;
            }
            else
            {
                game_obj.transform.position = select_obj.transform.position;
            }
            //wood_obj[nowSelect_i].transform.position.x / 2f
            time += Time.deltaTime;
            yield return new WaitForSeconds(0.001f);
        }

    }

    IEnumerator FadeIn2()
    {

        while (time2 < 1f)
        {
            //Debug.Log(time);
            //float a = select_obj.transform.position.x;

            if (time2 < 0.1f) //특정 위치에서 원점으로 이동
            {
                game2_obj.transform.position = movef_obj.transform.position;
            }
            else if (time2 < 0.2f) // 튕기고
            {
                game2_obj.transform.position = moveb_obj.transform.position;
            }
            else
            {
                game2_obj.transform.position = select_obj.transform.position;
            }
            //wood_obj[nowSelect_i].transform.position.x / 2f
            time2 += Time.deltaTime;
            yield return new WaitForSeconds(0.001f);
        }

    }

}
