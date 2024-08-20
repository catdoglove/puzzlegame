using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CharMove : MonoBehaviour
{
    private Rigidbody2D rigid2D;
    public int ckwalk = 0;
    int ckCrash = 0;

    public Animator charAni;
    //float moveX, moveY, charspeed;
    //float normalSpeed = 0.3f, runSpeed = 0.5f, crushSpeed = 0.3f;

    public float Speed;
    float h;
    float v;
    float waitFloat;



    public Action keyaction = null;

    public GameObject charSpr;
    public Sprite[] charSPR;
    public Vector3 position;

    public Transform Target;
    public float firingAngle = 0;
    public float gravity = 1.5f;

    public Transform Projectile;
    private Transform myTransform;


    public bool canMove = true;
    public AudioSource ausrc;
    public AudioClip auCP;


    //걷기 관련
    public AudioClip sp_walk, sp_walk_wood;
    public AudioSource se_walk, se_walk_wood;

    bool isMoving;

    public GameObject GM, GM_B;

    int walkint = 0;
    int rannd, rannndint;


    string[] waitNum = new string[6];

    int ran = 0;

    public GameObject mark1_obj, mark2_obj;

    public GameObject bulb_obj;


    int stopint = 0;


    public GameObject remove_obj, other_obj;

    public float vols_f=0.8f;

    void Awake()
    {
        myTransform = transform;
        rigid2D = GetComponent<Rigidbody2D>();
        PlayerPrefs.SetInt("movmovmeme", 0);
    }

    void Start()
    {
        charWaitingMotion();

        if (PlayerPrefs.GetInt("lostbell", 0) == 1)
        {
            charAni.Play("ani_charnobell_stop"); 
        }
        else
        {
            charAni.Play("ani_char_stop");
        }     
        //숲 이후로

        ckwalk = 0;
        ausrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (canMove == false)
        {
           // charspeed = 0;
           // moveX = 0f;
          //  moveY = 0f;
          //  transform.Translate(new Vector3(moveX, moveY, 0) * 0.1f);
          //  rigid2D.velocity = new Vector2(moveX, moveY);
        }
        if (canMove)
        {
            charWalk();
        }

        if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Space)) //해결되었으나 스베이스바누르면 멈춘다stopint 는 단점이있음
        {
            rigid2D.constraints = RigidbodyConstraints2D.FreezeAll;
            stopint = 1;
        }
        else
        {
            if(stopint == 1)
            {
                Invoke("StopCharPlease", 0.1f);
            }
        }

        //speed = 0; 주인공의 인스펙터를 살펴봐라 발싸될때 어느 값이 변하는지를 볼 수 있다.

        if (PlayerPrefs.GetInt("nowtalk", 0) == 1)
        {

            if (PlayerPrefs.GetInt("lostbell", 0) == 1)
            {
                ran = 3;
            }
            else
            {
                ran = 0;
            }
            charAni.Play(waitNum[ran]);
        }
    }

    void StopCharPlease()
    {
        rigid2D.constraints = RigidbodyConstraints2D.None;
        rigid2D.constraints = RigidbodyConstraints2D.FreezeRotation;

        stopint = 0;
        Speed = 0;
    }

    void charWalk()
    {
        Vector2 start = transform.position;


        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        //  moveX = 0f;
        //   moveY = 0f;

        //Debug.Log(charAni.speed);

        if (Input.GetKey(KeyCode.RightShift)|| Input.GetKey(KeyCode.LeftShift))
        {
            //  if (ckCrash == 1) charspeed = crushSpeed;
            //  else charspeed = runSpeed;
            Speed = 5f;
            ausrc.GetComponent<AudioSource>().pitch = 1.3f;
            charAni.speed = 1.4f;
        }
        else
        {
          //  if (ckCrash == 1) charspeed = crushSpeed;
          //  else charspeed = normalSpeed;
            Speed = 3f;
            ausrc.GetComponent<AudioSource>().pitch = 1f;
            charAni.speed = 1f;
        }

        if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.UpArrow))
        {
            //   moveY += charspeed;
            SetWalk();
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            //   moveY -= charspeed;
            SetWalk();
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
          //  moveX -= charspeed; 
            charSpr.GetComponent<SpriteRenderer>().flipX = true;
            SetWalk();
        }

        if (Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.RightArrow))
        {
         //   moveX += charspeed; 
            charSpr.GetComponent<SpriteRenderer>().flipX = false;
            SetWalk();
        }


        if (Input.anyKey == false)
        {
            if (PlayerPrefs.GetInt("movmovmeme", 0) == 1)
            {
                PlayerPrefs.SetInt("movmovmeme", 0);
                



                if (PlayerPrefs.GetInt("lostbell", 0) == 1)
                {
                    ran = 3;
                    StopCoroutine("charwaitAnimation");
                    StopCoroutine("charwaitAnimation2");
                    StartCoroutine("charwaitAnimation2");
                }
                else
                {
                    ran = 0;
                    StopCoroutine("charwaitAnimation2");
                    StopCoroutine("charwaitAnimation");
                    StartCoroutine("charwaitAnimation");
                }


            }
            charAni.Play(waitNum[ran]);
            ckwalk = 0;
        }

        //  transform.Translate(new Vector3(moveX, moveY, 0) * 0.1f);

        /*
        rigid2D.velocity = new Vector2(moveX, moveY);
        if (rigid2D.velocity.x != 0 || rigid2D.velocity.y != 0)
        {
            isMoving = true;
        }
        else isMoving = false;

        if (isMoving)
        {
            if (!ausrc.isPlaying)
            {
                ausrc.Play();

            }
        }
        else
        {
            ausrc.Stop();
        }

        */

        if (isMoving)
        {
            if (!ausrc.isPlaying)
            {
                ausrc.Play();

            }
        }
        else
        {
            ausrc.Stop();
        }
        isMoving = false;


        //전환하기

        if (PlayerPrefs.GetInt("lakebooloff", 0) == 0)
        {
            if (PlayerPrefs.GetInt("gobrige", 0) == 1)
            {
                changeVolume();
            }
            else
            {

                //GM_B.GetComponent<ForBGM>().BGMfirst.GetComponent<AudioSource>().volume = 1f;
                //ausrc.clip = walkSouneEvt("sand");


                if (PlayerPrefs.GetInt("lakebool", 0) == 1)
                {

                    GM_B.GetComponent<ForBGM>().BGMfirst.GetComponent<AudioSource>().volume = 0f;
                    GM_B.GetComponent<ForBGM>().BGM2.GetComponent<AudioSource>().volume = 1f* vols_f;
                    ausrc.clip = walkSouneEvt("wood");
                }
                else
                {
                    GM_B.GetComponent<ForBGM>().BGM2.GetComponent<AudioSource>().volume = 0f;
                    GM_B.GetComponent<ForBGM>().BGMfirst.GetComponent<AudioSource>().volume = 1f* vols_f;
                    ausrc.clip = walkSouneEvt("sand");

                }

            }
        }

    }

    void SetWalk()
    {
        isMoving = true;

        if (PlayerPrefs.GetInt("lostbell", 0) == 1)
        {
            charAni.Play("ani_charnobell_walk");
        }
        else
        {
            charAni.Play("ani_char_walk");
        }

        PlayerPrefs.SetInt("movmovmeme", 1);
    }


    private void FixedUpdate()
    {

        //if (PlayerPrefs.GetInt("stopwhenitem", 0) == 0)
        //{
            rigid2D.velocity = new Vector2(h, v) * Speed;
        //}


    }

    public void Sub()
    {
        charAni.Play("ani_char_walk");
    }
    public void GoWalk()
    {
        rigid2D.velocity = new Vector2(1, v) * 10;
    }


/// <summary>
/// 대기모션리스트
/// </summary>
void charWaitingMotion()
    {
        waitNum[0] = "ani_char_stop";
        waitNum[1] = "ani_char_wait";
        waitNum[2] = "ani_char_wait2";

        waitNum[3] = "ani_charnobell_stop";
        waitNum[4] = "ani_charnobell_wait";
        waitNum[5] = "ani_charnobell_wait2";

    }

    /// <summary>
    /// 순서대로 대기모션 불러오기
    /// 나중에 봐서 속도 조절할 것 waitFloat
    /// </summary>
    IEnumerator charwaitAnimation()
    {
        while (true)
        {
            waitFloat++;
                switch (ran)
                {
                    case 0:
                        yield return new WaitForSeconds(1f);
                    if (waitFloat >= 30)
                    {
                        ran = 1;
                        waitFloat = 0;
                    }
                        break;
                    case 1:
                    yield return new WaitForSeconds(1f);
                    if (waitFloat >= 30)
                    {
                        ran = 2;
                        waitFloat = 0;
                    }
                    break;
                    case 2:
                    yield return new WaitForSeconds(1f);
                    if (waitFloat >= 30)
                    {
                        ran = 0;
                        waitFloat = 0;
                    }
                    break;
                
            }
        }
    }


    IEnumerator charwaitAnimation2()
    {
        while (true)
        {
                switch (ran)
                {
                    case 3:
                        yield return new WaitForSeconds(30f);
                        ran = 4;
                        break;
                    case 4:
                        yield return new WaitForSeconds(30f);
                        ran = 5;
                        break;
                    case 5:
                        yield return new WaitForSeconds(30f);
                        ran = 3;
                        break;
                
            }
        }
    }


    public AudioClip walkSouneEvt(string walkSE) //걸음 소리 변경 함수
    {
        switch (walkSE)
        {
            case "sand":
                auCP = sp_walk;
                ausrc.clip = auCP;
                break;

            case "wood":
                auCP = sp_walk_wood;
                ausrc.clip = auCP;
                break;
        }

        return auCP;

    }

    public void changeVolume3(float a) //이 함수를 '물밖'영역에서만 실행할 것
    {
        if (transform.position.x <= a) //위치 도달 전의 값
        {
            ausrc.clip = walkSouneEvt("wood");
        }
        else
        {
            PlayerPrefs.SetInt("lakebooloff", 1);
            ausrc.clip = walkSouneEvt("sand");
        }
    }


    public void changeVolume2()
    {
        if (transform.position.x <= 5.9f) //위치 도달 전의 값
        {
            GM_B.GetComponent<ForBGM>().BGMfirst.GetComponent<AudioSource>().volume = 0f;
        }

        if (transform.position.x >= 6f)
        {
            GM_B.GetComponent<ForBGM>().BGMfirst.GetComponent<AudioSource>().volume = 0.2f * vols_f;
        }
    }


    public void changeVolume()
    //특정 위치 값에서 발동되는 배경음악 페이드인아웃효과, x축 y축 값을 각각 맞춰 수정하면 언제든 ㅇㅋ
    {
        if (transform.position.x <= -1f) //위치 도달 전의 값
        {
            GM_B.GetComponent<ForBGM>().BGMfirst.GetComponent<AudioSource>().volume = 1f * vols_f;
            GM_B.GetComponent<ForBGM>().BGM2.GetComponent<AudioSource>().volume = 0f;

            ausrc.clip = walkSouneEvt("sand");          
        }
        
        /*
        if (transform.position.x >= -0.5f) //위치 도달 이후 부터 ~~
        {
            GM_B.GetComponent<ForBGM>().BGMfirst.GetComponent<AudioSource>().volume = 0.8f;

            ausrc.clip = walkSouneEvt("sand");

        }
        */
        if (transform.position.x >= 0f)
        {
            GM_B.GetComponent<ForBGM>().BGMfirst.GetComponent<AudioSource>().volume = 0.6f * vols_f;
            GM_B.GetComponent<ForBGM>().BGM2.GetComponent<AudioSource>().volume = 0.2f * vols_f;

            ausrc.clip = walkSouneEvt("wood");
        }
        if (transform.position.x >= 0.5f)
        {
            GM_B.GetComponent<ForBGM>().BGMfirst.GetComponent<AudioSource>().volume = 0.5f * vols_f;
            GM_B.GetComponent<ForBGM>().BGM2.GetComponent<AudioSource>().volume = 0.5f * vols_f;

            ausrc.clip = walkSouneEvt("wood");
        }

        if (transform.position.x >= 3f)
        {
            GM_B.GetComponent<ForBGM>().BGMfirst.GetComponent<AudioSource>().volume = 0.2f * vols_f;
            GM_B.GetComponent<ForBGM>().BGM2.GetComponent<AudioSource>().volume = 0.6f * vols_f;

            ausrc.clip = walkSouneEvt("wood");
        }

        if (transform.position.x >= 4.5f)
        {
            GM_B.GetComponent<ForBGM>().BGMfirst.GetComponent<AudioSource>().volume = 0f;
            GM_B.GetComponent<ForBGM>().BGM2.GetComponent<AudioSource>().volume = 0.8f * vols_f;

            ausrc.clip = walkSouneEvt("wood");
        }

        if (transform.position.x >= 6f)
        {
            GM_B.GetComponent<ForBGM>().BGM2.GetComponent<AudioSource>().volume = 1f * vols_f;

            ausrc.clip = walkSouneEvt("wood");
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        ckCrash = 1;
        //Debug.Log("충돌시작");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Debug.Log("충돌중");
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //Debug.Log("충돌종료");
        ckCrash = 0;
    }




}
