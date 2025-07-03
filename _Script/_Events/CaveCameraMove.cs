using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveCameraMove : MonoBehaviour
{
    public GameObject c_obj, s_obj, b_obj, e_obj, dogam_obj;
    public Transform t_obj;
    public Sprite s_spr;

    public float moveY, moveX, moveY1, moveX1;

    Color color;


    public GameObject CGM, MGM, BGM1, SGM;


    public GameObject cutS_obj;
    public Sprite[] cutS_spr;
    public GameObject note_obj;
    public GameObject ch_obj;

    int a = 0;


    public GameObject sp_obj;

    public GameObject m1_obj, m2_obj;

    public GameObject triger_obj;
    


    // Start is called before the first frame update
    void Start()
    {

        PlayerPrefs.SetInt("nowwalkdont", 1);
        PlayerPrefs.SetInt("escdont", 1);
        BGM1.SetActive(false);
        CGM.GetComponent<CharMove>().charAni.Play("ani_char_stop");
        CGM.GetComponent<CharMove>().Speed = 0f;
        CGM.GetComponent<CharMove>().charAni.speed = 1f;
        CGM.GetComponent<CharMove>().canMove = false;
        //color.a = Mathf.Lerp(0f, 1f, 0f);
        //b_obj.GetComponent<SpriteRenderer>().color = color;
        moveY1 = c_obj.transform.position.y;
        moveX1 = c_obj.transform.position.x;
        //s_obj.SetActive(true);
        StartCoroutine("EventBack");
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    IEnumerator EventBack() //카메라 움직이기
    {

        yield return new WaitForSeconds(0.3f);

        //SGM.GetComponent<SoundEvt>().auSE.GetComponent<AudioSource>().pitch = 1f;
        //SGM.GetComponent<SoundEvt>().soundTalkLow2();

        yield return new WaitForSeconds(0.5f);

        yield return new WaitForSeconds(0.01f);
        moveY = c_obj.transform.position.y;
        moveX = c_obj.transform.position.x;


        while (c_obj.transform.position.x >= t_obj.position.x)
        {
            moveX = moveX - 0.04f;
            c_obj.transform.position = new Vector3(moveX, moveY, -10f);
            yield return new WaitForSeconds(0.01f);
        }
        sp_obj.GetComponent<Animator>().Play("ani_npc_spider_change");
        yield return new WaitForSeconds(2f);

        /*
        yield return new WaitForSeconds(1.4f); //양이 보는 시간
        //CGM.GetComponent<SpriteRenderer>().flipX = true;
        yield return new WaitForSeconds(1.0f);


        yield return new WaitForSeconds(1f); //아이컨텍 시간
        //s_obj.transform.rotation = Quaternion.Euler(0, 180, 0);
        s_obj.GetComponent<SpriteRenderer>().sprite = s_spr;
        yield return new WaitForSeconds(0.8f); //양이 뒤돌아서 대기하는 시간
        */
        yield return new WaitForSeconds(3.0f);

        StartCoroutine("EventFront");
        StopCoroutine("EventBack");
    }

    IEnumerator EventFront() //카메라 원래대로 돌아오기
    {
        moveY = c_obj.transform.position.y;
        moveX = c_obj.transform.position.x;
        while (c_obj.transform.position.x <= moveX1)
        {
            moveX = moveX + 0.04f;
            c_obj.transform.position = new Vector3(moveX, moveY, -10f);
            yield return new WaitForSeconds(0.01f);
        }
        triger_obj.SetActive(true);

        //ch_obj.SetActive(false);
        yield return new WaitForSeconds(0.01f);
        //note_obj.SetActive(true);

        //PlayerPrefs.SetInt("canSeeInfo_detailt" + 2, 99);

        PlayerPrefs.SetInt("nowwalkdont", 0);
        PlayerPrefs.SetInt("escdont", 0);
        CGM.GetComponent<CharMove>().canMove = true;
        CGM.GetComponent<CharMove>().Speed = 2.5f;

        //m1_obj.SetActive(false);
        //m2_obj.SetActive(true);

        //Invoke("can", 0.2f);
        //StartCoroutine("move");
    }

}
