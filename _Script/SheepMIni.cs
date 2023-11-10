using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMIni : MonoBehaviour
{
    public GameObject cottonWin_obj,cotton1_obj, cotton2_obj, cottonKey1_obj, cottonKey2_obj;
    public Sprite[] cotton_spr;
    public int a_i;
    public GameObject SGM,CPGM, CPSGM;
    public int a = 0;
    public int b = 0;

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
        StopCoroutine("Press");
        StartCoroutine("Press");
    }


    void APress()
    {
        cotton1_obj.SetActive(true);
        cotton2_obj.SetActive(false);
        cotton1_obj.GetComponent<SpriteRenderer>().sprite = cotton_spr[a_i];
        cottonKey2_obj.SetActive(false);
    }

    void DPress()
    {
        cotton1_obj.SetActive(false);
        cotton2_obj.SetActive(true);
        cotton2_obj.GetComponent<SpriteRenderer>().sprite = cotton_spr[a_i];
        cottonKey1_obj.SetActive(false);
    }


    IEnumerator Press()
    {
        while (a==0)
        {
            if (a_i >= 5)
            {
                yield return new WaitForSeconds(0.2f);
                a = 1;
                cottonWin_obj.SetActive(false);
                if (b==0)
                {
                    CPGM.GetComponent<CheckPlayer>().EventNum_i[CPGM.GetComponent<CheckPlayer>().num] = 15;
                    CPGM.GetComponent<CheckPlayer>().EventSetting();
                    b = 1;
                }
                else
                {
                    CPSGM.GetComponent<CheckPlayer>().EventNum_i[CPGM.GetComponent<CheckPlayer>().num] = 15;
                    CPSGM.GetComponent<CheckPlayer>().EventSetting();
                }
                a_i = 0;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    if (a_i % 2 == 1)
                    {
                        SGM.GetComponent<SoundEvt>().auSE.GetComponent<AudioSource>().pitch = 1f;
                        SGM.GetComponent<SoundEvt>().soundCotton();
                        APress();
                        a_i++;
                        yield return new WaitForSeconds(0.8f);
                    }

                }

                if (Input.GetKeyDown(KeyCode.D))
                {
                    if (a_i % 2 == 0)
                    {
                        SGM.GetComponent<SoundEvt>().auSE.GetComponent<AudioSource>().pitch = 1f;
                        SGM.GetComponent<SoundEvt>().soundCotton();
                        DPress();
                        a_i++;
                        yield return new WaitForSeconds(0.8f);
                    }
                }

            }

            yield return new WaitForSeconds(0.01f);
        }
    }



}
