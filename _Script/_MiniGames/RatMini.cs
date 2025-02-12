using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatMini : MonoBehaviour
{
    public GameObject ratWin_obj,ratweb_obj,knife_obj, ball_obj;
    public Sprite[] web_spr;


    public GameObject GMM, SGM;


    public int a_i, a;


    public GameObject f_obj, f1_obj, f2_obj, b_obj, b1_obj, b2_obj;


    public float wait_f = 0.1f;

    public float time = 0;

    public GameObject nife_obj, nife1_obj, nife2_obj;

    public float y_f;


    public Vector3 position;

    public int k = 0;

    // Start is called before the first frame update
    void Start()
    {

    }
    


    private void OnEnable()
    {
        k = 0;
        a = 0;
        StopCoroutine("Press");
        StartCoroutine("Press");
        a_i = 0;
    }

        void WPress()
    {

    }

    void SPress()
    { 

    }


    public void FinWeb()
    {
        SGM.GetComponent<SoundEvt>().soundItemSuccess();

        ball_obj.SetActive(false);
        knife_obj.SetActive(true);

        GMM.GetComponent<CharMove>().canMove = true;

        PlayerPrefs.SetInt("canSeeInfo_detail" + 13, 99);
        Invoke("Wait", 0.8f);
    }



    void Wait()
    {
        ratWin_obj.SetActive(false);
        GMM.GetComponent<CharMove>().canMove = true;
        
        PlayerPrefs.SetInt("escdont", 0);
    }




    IEnumerator Press()
    {
        while (a == 0)
        {
            if (a_i >= 13)
            {
                
            }
            else
            {

                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    if (a_i < 1)
                    {
                        ///   SGM.GetComponent<SoundEvt>().auSE.GetComponent<AudioSource>().pitch = 1f;
                        SGM.GetComponent<SoundEvt>().soundCotton();
                        WPress();
                        a_i++;
                        StopCoroutine("FadeIn");
                        StartCoroutine("FadeIn");
                        yield return new WaitForSeconds(wait_f);
                    }

                    if (a_i >= 2 && a_i < 3)
                    {
                        ///   SGM.GetComponent<SoundEvt>().auSE.GetComponent<AudioSource>().pitch = 1f;
                        SGM.GetComponent<SoundEvt>().soundCotton();
                        WPress();
                        a_i++;
                        StopCoroutine("FadeIn");
                        StartCoroutine("FadeIn");
                        yield return new WaitForSeconds(wait_f);

                        k++;
                        if (k>=3)
                        {
                            FinWeb();
                        }
                        else
                        {

                            ratweb_obj.GetComponent<SpriteRenderer>().sprite = web_spr[0];
                            web_spr[0] = web_spr[1];
                            web_spr[1] = web_spr[2];

                            yield return new WaitForSeconds(0.2f);
                            nife_obj.transform.position = nife1_obj.transform.position;
                            nife1_obj.transform.position = nife2_obj.transform.position;

                            f_obj.transform.position = f1_obj.transform.position;
                            f1_obj.transform.position = f2_obj.transform.position;

                            b_obj.transform.position = b1_obj.transform.position;
                            b1_obj.transform.position = b2_obj.transform.position;

                            yield return new WaitForSeconds(wait_f);
                            a_i = 0;
                        }
                    }

                }
                

                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    if (a_i >= 1 && a_i < 2)
                    {
                        SGM.GetComponent<SoundEvt>().soundCotton();
                        //   SGM.GetComponent<SoundEvt>().auSE.GetComponent<AudioSource>().pitch = 1f;
                        // SGM.GetComponent<SoundEvt>().soundstick();
                        SPress();
                        a_i++;
                        StopCoroutine("FadeOut");
                        StartCoroutine("FadeOut");

                        yield return new WaitForSeconds(wait_f);
                    }
                }



            }

            yield return new WaitForSeconds(0.01f);
        }
    }



    IEnumerator FadeIn()
    {
        y_f = nife_obj.transform.position.y;

        position = nife_obj.transform.position;

        while (f_obj.transform.position.y > nife_obj.transform.position.y)
        {
            y_f= y_f + 0.1f;
            position.y= y_f;
            nife_obj.transform.position = position;
            
            yield return new WaitForSeconds(0.001f);
        }

    }

    IEnumerator FadeOut()
    {
        y_f = nife_obj.transform.position.y;

        position = nife_obj.transform.position;

        while (b_obj.transform.position.y < nife_obj.transform.position.y)
        {

            y_f = y_f - 0.1f;
            position.y = y_f;

            nife_obj.transform.position = position;

            yield return new WaitForSeconds(0.001f);
        }

    }
}
