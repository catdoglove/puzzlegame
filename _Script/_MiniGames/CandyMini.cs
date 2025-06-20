using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyMini : MonoBehaviour
{
    public GameObject cottonWin_obj, cotton1_obj, cotton2_obj, cottonKey1_obj, cottonKey2_obj;
    public Sprite[] cotton_spr;
    public int a_i;
    public GameObject SGM, CPGM, CPSGM;
    public int a = 0;
    public int b = 0;
    public int c = 0;
    public int d = 0;

    // Start is called before the first frame update
    void Start()
    {
    }


    private void OnEnable()
    {

        
        cotton1_obj.SetActive(true);
        cotton2_obj.SetActive(false);
        cotton1_obj.GetComponent<SpriteRenderer>().sprite = cotton_spr[5];
        a = 0;
        a_i = 0;
        b = 0;
        c = 0;
        StopCoroutine("PressCh");
        StartCoroutine("PressCh");
    }


    public void APress()
    {
        SGM.GetComponent<SoundEvt>().auSE.GetComponent<AudioSource>().pitch = 1f;
        SGM.GetComponent<SoundEvt>().soundCotton();
        cotton1_obj.SetActive(true);
        cotton2_obj.SetActive(false);
        cotton1_obj.GetComponent<SpriteRenderer>().sprite = cotton_spr[a_i];
        cottonKey2_obj.SetActive(false);
        a_i++;
        c = 0;
    }

    public void DPress()
    {
        SGM.GetComponent<SoundEvt>().auSE.GetComponent<AudioSource>().pitch = 1f;
        SGM.GetComponent<SoundEvt>().soundCotton();
        cotton1_obj.SetActive(false);
        cotton2_obj.SetActive(true);
        cotton2_obj.GetComponent<SpriteRenderer>().sprite = cotton_spr[a_i];
        cottonKey1_obj.SetActive(false);
        a_i++;
        c = 0;
    }


    IEnumerator Press()
    {
        while (a == 0)
        {
            if (a_i >= 5)
            {
                yield return new WaitForSeconds(0.6f);
                cottonWin_obj.SetActive(false);
                if (b == 0)
                {
                    CPSGM.GetComponent<CheckPlayer>().EventNum_i[CPGM.GetComponent<CheckPlayer>().num] = 15;
                    CPSGM.GetComponent<CheckPlayer>().EventSetting();
                    b = 1;
                }
                a = 1;
                a_i = 0;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    if (a_i == 5)
                    {
                        APress();
                        yield return new WaitForSeconds(0.8f);
                    }
                    if (a_i == 3)
                    {
                        APress();
                        yield return new WaitForSeconds(0.8f);
                    }
                    if (a_i == 1)
                    {
                        APress();
                        yield return new WaitForSeconds(0.8f);
                    }

                }

                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if (a_i == 4)
                    {
                        DPress();
                        yield return new WaitForSeconds(0.8f);
                    }
                    if (a_i == 2)
                    {
                        DPress();
                        yield return new WaitForSeconds(0.8f);
                    }
                    if (a_i == 0)
                    {
                        DPress();
                        yield return new WaitForSeconds(0.8f);
                    }
                }

            }


            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator PressCh()
    {
        while (a == 0)
        {
            if (c == 0)
            {

                if (a_i >= 5)
                {
                    yield return new WaitForSeconds(0.8f);
                    cottonWin_obj.SetActive(false);
                    if (b == 0)
                    {
                        CPSGM.GetComponent<CheckPlayer>().EventNum_i[CPSGM.GetComponent<CheckPlayer>().num] = 15;
                        CPSGM.GetComponent<CheckPlayer>().EventSetting();
                        b = 1;
                    }
                    a = 1;
                    a_i = 0;
                }
                else
                {

                    if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        if (a_i == 5)
                        {
                            c = 1;
                            Invoke("APress", 0.6f);
                        }
                        if (a_i == 3)
                        {
                            c = 1;
                            Invoke("APress", 0.6f);
                        }
                        if (a_i == 1)
                        {
                            c = 1;
                            Invoke("APress", 0.6f);
                        }

                    }

                    if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        if (a_i == 4)
                        {
                            c = 1;
                            Invoke("DPress", 0.6f);
                        }
                        if (a_i == 2)
                        {
                            c = 1;
                            Invoke("DPress", 0.6f);
                        }
                        if (a_i == 0)
                        {
                            c = 1;
                            Invoke("DPress", 0.6f);
                        }
                    }
                }

            }

            if (d==0)
            {
                d = 1;
                Invoke("helpme", 6f);
            }

            yield return new WaitForSeconds(0.01f);
        }
    }


    void helpme()
    {
        if (a_i >= 5)
        {
            cottonWin_obj.SetActive(false);
            if (b == 0)
            {
                CPSGM.GetComponent<CheckPlayer>().EventNum_i[CPSGM.GetComponent<CheckPlayer>().num] = 15;
                CPSGM.GetComponent<CheckPlayer>().EventSetting();
                b = 1;
            }
            a = 1;
            a_i = 0;
        }
        d = 0;
    }

}
