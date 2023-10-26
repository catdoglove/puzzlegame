using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMIni : MonoBehaviour
{
    public GameObject cottonWin_obj,cotton1_obj, cotton2_obj;
    public Sprite[] cotton_spr;
    public int a_i;
    public GameObject SGM;
    int a = 0;

    // Start is called before the first frame update
    void Start()
    {
        a_i = 0;
        StartCoroutine("Press");
    }
    



    void APress()
    {
        cotton1_obj.SetActive(true);
        cotton2_obj.SetActive(false);
        cotton1_obj.GetComponent<SpriteRenderer>().sprite = cotton_spr[a_i];
    }

    void DPress()
    {
        cotton1_obj.SetActive(false);
        cotton2_obj.SetActive(true);
        cotton2_obj.GetComponent<SpriteRenderer>().sprite = cotton_spr[a_i];
    }


    IEnumerator Press()
    {
        while (a==0)
        {
            if (a_i == 4)
            {
                yield return new WaitForSeconds(0.8f);
                a = 1;
                cottonWin_obj.SetActive(false);
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    if (a_i % 2 == 1)
                    {
                        SGM.GetComponent<SoundEvt>().auSE.GetComponent<AudioSource>().pitch = 1f;
                        SGM.GetComponent<SoundEvt>().soundBoxWASD();
                        yield return new WaitForSeconds(0.8f);
                        APress();
                        a_i++;
                    }

                }

                if (Input.GetKeyDown(KeyCode.D))
                {
                    if (a_i % 2 == 0)
                    {
                        SGM.GetComponent<SoundEvt>().auSE.GetComponent<AudioSource>().pitch = 1f;
                        SGM.GetComponent<SoundEvt>().soundBoxWASD();
                        yield return new WaitForSeconds(0.8f);
                        DPress();
                        a_i++;
                    }
                }

            }

            yield return new WaitForSeconds(0.01f);
        }
    }



}
