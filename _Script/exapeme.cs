using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exapeme : MonoBehaviour
{
    private float moveSpeed = 5.0f;                 //이동 속도
    private PolygonCollider2D rigid2D;
    // Start is called before the first frame update

    public Animator charAni;
    float moveX, moveY, charspeed;
    float normalSpeed = 0.2f,runSpeed=0.3f;
    public Action keyaction = null;

    public GameObject charSpr;
    public LayerMask layerMask; //통과가 불가능한 레이어를 설정 
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




        if (Input.GetKey(KeyCode.W)) moveY += charspeed;

        if (Input.GetKey(KeyCode.S)) moveY -= charspeed;

        if (Input.GetKey(KeyCode.A))
        {
            moveX -= charspeed; charSpr.GetComponent<SpriteRenderer>().flipX = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveX += charspeed; charSpr.GetComponent<SpriteRenderer>().flipX = false;
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
        /*
        if (hit.transform != null)    //부딪히면 다음 명령어들은 실행하지 않음
        {
           // moveX = 0;
           // moveY = 0;
        }
        else
        {
            Debug.Log("test");
        }
        */

        transform.Translate(new Vector3(moveX, moveY, 0) * 0.1f);

    }


    //enterstay

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("test");
    }

}
