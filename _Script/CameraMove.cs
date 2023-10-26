using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject c_obj, s_obj, b_obj, e_obj;
    public Transform t_obj;
    public Sprite s_spr;

    public float moveY, moveX, moveY1, moveX1;

    Color color;


    public GameObject CGM,MGM,BGM1, SGM;

    // Start is called before the first frame update
    void Start()
    {

        BGM1.SetActive(false);
        CGM.GetComponent<CharMove>().charAni.Play("ani_charnobell_stop");
        CGM.GetComponent<CharMove>().Speed = 0f;
        color.a = Mathf.Lerp(0f, 1f, 0f);
        b_obj.GetComponent<SpriteRenderer>().color = color;
        moveY1 = c_obj.transform.position.y;
        moveX1 = c_obj.transform.position.x;
        s_obj.SetActive(true);
        StartCoroutine("EventBack");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    IEnumerator EventBack() //카메라 움직이기
    {

        yield return new WaitForSeconds(0.5f);
        SGM.GetComponent<SoundEvt>().auSE.GetComponent<AudioSource>().pitch = 1f;
        SGM.GetComponent<SoundEvt>().soundWalk();

        yield return new WaitForSeconds(0.01f);
        moveY = c_obj.transform.position.y;
        moveX = c_obj.transform.position.x;
        while (c_obj.transform.position.x >= t_obj.position.x)
        {
            moveX = moveX - 0.04f;
            c_obj.transform.position = new Vector3(moveX, moveY,-10f);
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(0.8f); //양이 보는 시간
        CGM.GetComponent<SpriteRenderer>().flipX = true;
        yield return new WaitForSeconds(2.5f); //아이컨텍 시간
        s_obj.transform.rotation = Quaternion.Euler(0, 180, 0);
        yield return new WaitForSeconds(1f); //양이 뒤돌아서 대기하는 시간
        StartCoroutine("EventFront");
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
        StartCoroutine("move");
    }

    IEnumerator move() //주인공 걷는 시간
    {
        yield return new WaitForSeconds(0.9f);
        CGM.GetComponent<SpriteRenderer>().flipX = false;
        CGM.GetComponent<CharMove>().charAni.Play("ani_charnobell_walk");
        moveY = CGM.transform.position.y;
        moveX = CGM.transform.position.x;

        StartCoroutine("imgFadeOut");

        for (int i = 0; i < 100; i++) //숫자가 클 수록 더 오래 걷는다.
        {
            moveX = moveX + 0.03f;
            CGM.transform.position = new Vector3(moveX, moveY, 0f);
            yield return new WaitForSeconds(0.01f);
            if (i%30==29)
            {
                SGM.GetComponent<SoundEvt>().auSE.GetComponent<AudioSource>().pitch = 1f;
                SGM.GetComponent<SoundEvt>().soundWalk();
            }
        }

    }

    IEnumerator imgFadeOut()
    {
        yield return new WaitForSeconds(0.6f);
        moveY = CGM.transform.position.y;
        moveX = CGM.transform.position.x;
        b_obj.SetActive(true);
        color = b_obj.GetComponent<SpriteRenderer>().color;
        for (float i = 0f; i <= 1f; i += 0.05f)
        {
            moveX = moveX + 0.01f;
           // CGM.transform.position = new Vector3(moveX, moveY, 0f);
            color.a = Mathf.Lerp(0f, 1f, i);
            b_obj.GetComponent<SpriteRenderer>().color = color;
            yield return new WaitForSeconds(0.05f);
        }
        color.a = Mathf.Lerp(0f, 1f, 1f);
        b_obj.GetComponent<SpriteRenderer>().color = color;

        StopCoroutine("move");
        CGM.GetComponent<CharMove>().canMove = true;
        yield return new WaitForSeconds(0.8f);
        MGM.GetComponent<MoveMap>().MovingMap();
        MGM.GetComponent<MoveMap>().player_obj.transform.position = MGM.GetComponent<MoveMap>().mapRespawn_obj[0].transform.position;
        b_obj.SetActive(false);

        CGM.GetComponent<CharMove>().Speed = 2.5f;
    }
}
