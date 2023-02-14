using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exapeme : MonoBehaviour
{
    private PolygonCollider2D rigid2D;
    int ckwalk = 0;
    int ckCrash = 0;

    public Animator charAni;
    float moveX, moveY, charspeed;
    float normalSpeed = 0.1f,runSpeed=0.2f, crushSpeed=0.05f;
    public Action keyaction = null;

    public GameObject charSpr;
    public Vector3 position;


    void Start()
    {
    }
    void Awake()
    {
        rigid2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
      charWalk();
    }




    void charWalk()
    {
        Vector2 start = transform.position;

        moveX = 0f;
        moveY = 0f;

        if (Input.GetKey(KeyCode.RightShift))
        {
            if (ckCrash == 1) charspeed = crushSpeed;
            else charspeed = runSpeed;
        }
        else
        {
            if (ckCrash == 1) charspeed = crushSpeed;
            else charspeed = normalSpeed;
        }

        if (Input.GetKey(KeyCode.W))
        {
            moveY += charspeed; ckwalk = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveY -= charspeed; ckwalk = 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveX -= charspeed; charSpr.GetComponent<SpriteRenderer>().flipX = true; ckwalk = 1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveX += charspeed; charSpr.GetComponent<SpriteRenderer>().flipX = false; ckwalk = 1;
        }


        if (Input.anyKey == false)
        {
            charAni.Play("ani_char_stop");
            ckwalk = 0;
        } 
        else if (ckwalk == 1)
        {
            charAni.Play("ani_char_walk");
        }

        transform.Translate(new Vector3(moveX, moveY, 0) * 0.1f);        

    }

        
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ckCrash = 1;
        Debug.Log("충돌시작");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
       // Debug.Log("충돌중");
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("충돌종료");
        ckCrash = 0;
    }


}
