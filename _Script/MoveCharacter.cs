using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{

    private BoxCollider2D boxCollider;
    public LayerMask layerMask; //통과가 불가능한 레이어를 설정 

    public Vector3 position;
    public float Speed = 4;

    public bool canMove = true;


    public int move_i=1;



    public bool isMove = false;
    public Sprite[] char_spr;
    public int a = 0;
    public GameObject char_obj;

    //private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        position = this.transform.position;

        boxCollider = GetComponent<BoxCollider2D>();
        //animator = GetComponent<Animator>();

        //StartCoroutine("MoveCoroutine");
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            RaycastHit2D hit;   //레이저를 쏴서 방해물이 있으면 방해물을 리턴하고, 아무것도 없으면 null리턴
            Vector2 start = transform.position; //캐릭터의 현재위치
                                                //animator.SetFloat("DirX", vector.x);
                                                //animator.SetFloat("DirY", vector.y);


            int c = 0;

            if (Input.GetKey(KeyCode.A))
            {
                position.x -= Speed * Time.deltaTime;
                this.GetComponent<SpriteRenderer>().flipX = true;
                c = 1;
            }
            else
            {
                if (Input.GetKey(KeyCode.D))
                {
                    position.x += Speed * Time.deltaTime;
                    this.GetComponent<SpriteRenderer>().flipX = false;
                    c = 1;
                }
            }
            if (Input.GetKey(KeyCode.W))
            {
                position.y += Speed * Time.deltaTime;
                c = 1;
            }
            else
            {
                if (Input.GetKey(KeyCode.S))
                {
                    position.y -= Speed * Time.deltaTime;
                    c = 1;
                }
            }
            if (c==0)
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


            boxCollider.enabled = false;    //캐릭터 자신의 박스컬라이더를 인식못하게 해줌
            hit = Physics2D.Linecast(start, position, layerMask);
            boxCollider.enabled = true;

            if (hit.transform != null)    //부딪히면 다음 명령어들은 실행하지 않음
            {
                position = this.transform.position;
                StopCoroutine("MoveCoroutine");
                this.GetComponent<SpriteRenderer>().sprite = char_spr[0];
                isMove = false;
            }
            else
            {
                this.transform.position = position;
            }
        }
        else
        {
            StopCoroutine("MoveCoroutine");
            this.GetComponent<SpriteRenderer>().sprite = char_spr[0];
            isMove = false;
        }
    }

    IEnumerator MoveCoroutine()
    {
        while (move_i == 1)
        {
            isMove = true;
            if (a == 0)
            {
                this.GetComponent<SpriteRenderer>().sprite = char_spr[1];
                a = 1;
            }
            else
            {
                this.GetComponent<SpriteRenderer>().sprite = char_spr[2];
                a = 0;
            }
            yield return new WaitForSeconds(0.1f);
        }

    }


}
