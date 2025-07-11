using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveADMove : MonoBehaviour
{
    public GameObject chair_obj, chairL_obj, chairR_obj, chairM_obj;
    public Sprite[] chair_spr;

    public GameObject CGM, SGM;

    public int a = 0;
    public int a_i=0;


    float time = 0;

    public GameObject c_obj;

    private void Awake()
    {

        StopCoroutine("Press");
        StartCoroutine("Press");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    IEnumerator Press()
    {
        while (a == 0)
        {

            if (a_i >= 5)
            {
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    chair_obj.GetComponent<SpriteRenderer>().sprite = chair_spr[3];
                    yield return new WaitForSeconds(1.3f);
                    chair_obj.GetComponent<SpriteRenderer>().sprite = chair_spr[1];
                    CGM.SetActive(true);
                    a = 1;
                }

            }
            else
            {


                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    APress();
                    yield return new WaitForSeconds(0.7f);
                }

                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    DPress();
                    yield return new WaitForSeconds(0.7f);
                }



            }
            yield return new WaitForSeconds(0.01f);
        }
    }




    void APress()
    {
        time = 0;
        StopCoroutine("FadeIn");
        StartCoroutine("FadeIn");
        a_i++;
        SGM.GetComponent<SoundEvt>().soundItemFail();
    }

    void DPress()
    {
        time = 0;
        StopCoroutine("FadeIn");
        StartCoroutine("FadeIn");
        a_i++;
        SGM.GetComponent<SoundEvt>().soundItemFail();
    }




    IEnumerator FadeIn()
    {

        while (time < 1f)
        {
            //Debug.Log(time);
            //float a = select_obj.transform.position.x;

            if (time < 0.1f) //특정 위치에서 원점으로 이동
            {
                chair_obj.transform.position = chairL_obj.transform.position;
            }
            else if (time < 0.2f) // 튕기고
            {
                chair_obj.transform.position = chairR_obj.transform.position;
            }
            else
            {
                chair_obj.transform.position = chairM_obj.transform.position;
            }
            //wood_obj[nowSelect_i].transform.position.x / 2f
            time += Time.deltaTime;
            yield return new WaitForSeconds(0.001f);

            CGM.transform.position= c_obj.transform.position;  
        }
    }

}
