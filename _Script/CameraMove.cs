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


    public GameObject CGM,MGM;

    // Start is called before the first frame update
    void Start()
    {

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

    
    IEnumerator EventBack()
    {
        moveY = c_obj.transform.position.y;
        moveX = c_obj.transform.position.x;
        while (c_obj.transform.position.x >= t_obj.position.x)
        {
            moveX = moveX - 0.05f;
            c_obj.transform.position = new Vector3(moveX, moveY,-10f);
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(0.5f);
        CGM.GetComponent<SpriteRenderer>().flipX = true;
        yield return new WaitForSeconds(2.5f);
        s_obj.transform.rotation = Quaternion.Euler(0, 180, 0);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine("EventFront");
    }

    IEnumerator EventFront()
    {
        moveY = c_obj.transform.position.y;
        moveX = c_obj.transform.position.x;
        while (c_obj.transform.position.x <= moveX1)
        {
            moveX = moveX + 0.05f;
            c_obj.transform.position = new Vector3(moveX, moveY, -10f);
            yield return new WaitForSeconds(0.01f);
        }
        StartCoroutine("move");
    }

    IEnumerator move()
    {
        CGM.GetComponent<SpriteRenderer>().flipX = false;
        CGM.GetComponent<CharMove>().charAni.Play("ani_charnobell_walk");
        moveY = CGM.transform.position.y;
        moveX = CGM.transform.position.x;
        for (int i = 0; i < 50; i++)
        {
            moveX = moveX + 0.05f;
            CGM.transform.position = new Vector3(moveX, moveY, 0f);
            yield return new WaitForSeconds(0.01f);
        }

        StartCoroutine("imgFadeOut");
    }

    IEnumerator imgFadeOut()
    {

        moveY = CGM.transform.position.y;
        moveX = CGM.transform.position.x;
        b_obj.SetActive(true);
        color = b_obj.GetComponent<SpriteRenderer>().color;
        for (float i = 0f; i < 1f; i += 0.05f)
        {
            moveX = moveX + 0.01f;
            CGM.transform.position = new Vector3(moveX, moveY, 0f);
            color.a = Mathf.Lerp(0f, 1f, i);
            b_obj.GetComponent<SpriteRenderer>().color = color;
            yield return new WaitForSeconds(0.02f);
        }
        CGM.GetComponent<CharMove>().canMove = true;
        MGM.GetComponent<MoveMap>().MovingMap();
        MGM.GetComponent<MoveMap>().player_obj.transform.position = MGM.GetComponent<MoveMap>().mapRespawn_obj[0].transform.position;
        b_obj.SetActive(false);

        CGM.GetComponent<CharMove>().Speed = 2.5f;
    }
}
