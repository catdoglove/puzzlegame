using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharBody : MonoBehaviour
{
    private float moveSpeed = 5.0f;                 //이동 속도
    private BoxCollider2D rigid2D;
    // Start is called before the first frame update

    public Animator charAni;
    float moveX, moveY, charspeed;
    float normalSpeed = 0.2f, runSpeed = 0.3f;
    public Action keyaction = null;

    public GameObject charSpr;
    public LayerMask layerMask; //통과가 불가능한 레이어를 설정 
    public Vector3 position;



    public int move_i = 1;
    public bool isMove = false;
    public Sprite[] char_spr;
    public int a = 0;
    public GameObject char_obj;


    void Start()
    {
    }
    void Awake()
    {
        rigid2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        charWalk();
    }


    // Update is called once per frame
    /*void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid2D.AddForce(Vector2.right * h, ForceMode2D.Impulse);

    }*/





    void charWalk()
    {
        RaycastHit2D hit;
        Vector2 start = transform.position;

        moveX = 0f;
        moveY = 0f;

        if (Input.GetKey(KeyCode.RightShift))
            charspeed = runSpeed;
        else
            charspeed = normalSpeed;


        int c = 0;


        if (Input.GetKey(KeyCode.W))
        {
            moveY += charspeed;
            c = 1;
        }
        else
        {
            if (Input.GetKey(KeyCode.S))
            {
                moveY -= charspeed;
                c = 1;
            }
        }



        if (Input.GetKey(KeyCode.A))
        {
            moveX -= charspeed; charSpr.GetComponent<SpriteRenderer>().flipX = true;
            c = 1;

        }
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                moveX += charspeed; charSpr.GetComponent<SpriteRenderer>().flipX = false;
                c = 1;
            }
        }
        
        if (c == 0)
        {
            StopCoroutine("MoveCoroutine");
            this.GetComponent<SpriteRenderer>().sprite = char_spr[0];
            isMove = false;
        }
        else
        {
            if (isMove == false)
            {
                StartCoroutine("MoveCoroutine");
            }
        }



        if (Input.anyKey == false)
        {
            charAni.Play("ani_char_stop");
        }
        else
        {
            charAni.Play("ani_char_walk");
        }


        rigid2D.enabled = false;    //캐릭터 자신의 박스컬라이더를 인식못하게 해줌
        hit = Physics2D.Linecast(start, position, layerMask);
        rigid2D.enabled = true;

        if (hit.transform != null)    //부딪히면 다음 명령어들은 실행하지 않음
        {
            moveX = 0;
            moveY = 0;
        }
        else
        {

        }
        

            transform.Translate(new Vector3(moveX, moveY, 0) * 0.1f);

    }


    //enterstay

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("test");
    }




    IEnumerator MoveCoroutine()
    {
        while (move_i == 1)
        {
            isMove = true;
            if (a == 0)
            {
                this.GetComponent<SpriteRenderer>().sprite = char_spr[0];
                a = 1;
            }
            else if(a==1)
            {
                this.GetComponent<SpriteRenderer>().sprite = char_spr[1];
                a = 2;
            }
            else if(a == 2)
            {
                this.GetComponent<SpriteRenderer>().sprite = char_spr[2];
                a = 3;
            }
            else
            {
                this.GetComponent<SpriteRenderer>().sprite = char_spr[1];
                a = 0;
            }
            yield return new WaitForSeconds(0.1f);
        }

    }
}
