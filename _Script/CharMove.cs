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
    float moveX, moveY, charspeed;
    float normalSpeed = 0.3f, runSpeed = 0.5f, crushSpeed = 0.05f;
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


    string[] waitNum = new string[3];

    int ran = 0;



    // Start is called before the first frame update

    void Awake()
    {
        myTransform = transform;
        rigid2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        charWaitingMotion();
        charAni.Play("ani_char_stop");
        ckwalk = 0;
        ausrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (canMove == false)
        {
            charspeed = 0;
            moveX = 0f;
            moveY = 0f;
            transform.Translate(new Vector3(moveX, moveY, 0) * 0.1f);
            rigid2D.velocity = new Vector2(moveX, moveY);
        }
        if (canMove)
        {
            charWalk();
        }



        if (PlayerPrefs.GetInt("nowtalk", 0) == 1)
        {
            ran = 0;
            charAni.Play(waitNum[ran]);
        }
    }


    void charWalk()
    {
        Vector2 start = transform.position;

        moveX = 0f;
        moveY = 0f;

        //Debug.Log(charAni.speed);

        if (Input.GetKey(KeyCode.RightShift))
        {
            if (ckCrash == 1) charspeed = crushSpeed;
            else charspeed = runSpeed;
            charAni.speed = 1.6f;
            ausrc.GetComponent<AudioSource>().pitch = 1.3f;
        }
        else
        {
            if (ckCrash == 1) charspeed = crushSpeed;
            else charspeed = normalSpeed;
            charAni.speed = 1.2f;
            ausrc.GetComponent<AudioSource>().pitch = 1f;
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
            charAni.Play(waitNum[ran]);
            StartCoroutine("charwaitAnimation");
            ckwalk = 0;
        }
        else if (ckwalk == 1)
        {
            charAni.Play("ani_char_walk");
        }

        transform.Translate(new Vector3(moveX, moveY, 0) * 0.1f);

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


        //전환하기

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
                GM_B.GetComponent<ForBGM>().BGM2.GetComponent<AudioSource>().volume = 1f;
                ausrc.clip = walkSouneEvt("wood");
            }
            else
            {
                GM_B.GetComponent<ForBGM>().BGM2.GetComponent<AudioSource>().volume = 0f;
                GM_B.GetComponent<ForBGM>().BGMfirst.GetComponent<AudioSource>().volume = 1f;
                ausrc.clip = walkSouneEvt("sand");

            }

        }

    }

    /// <summary>
    /// 대기모션리스트
    /// </summary>
    void charWaitingMotion()
    {
        waitNum[0] = "ani_char_stop";
        waitNum[1] = "ani_char_wait";
        waitNum[2] = "ani_char_wait2";

    }

    /// <summary>
    /// 순서대로 대기모션 불러오기
    /// </summary>
    IEnumerator charwaitAnimation()
    {
        while (true)
        {
            switch (ran)
            {
                case 0:
                    yield return new WaitForSeconds(30f);
                    ran = 1;
                    break;
                case 1:
                    yield return new WaitForSeconds(30f);
                    ran = 2;
                    break;
                case 2:
                    yield return new WaitForSeconds(30f);
                    ran = 0;
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
    
    public void changeVolume3() //이 함수를 '물밖'영역에서만 실행할 것
    {
        if (transform.position.x <= 0f) //위치 도달 전의 값
        {
            ausrc.clip = walkSouneEvt("wood");
        }else
        {
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
            GM_B.GetComponent<ForBGM>().BGMfirst.GetComponent<AudioSource>().volume = 0.2f;
        }
    }


    public void changeVolume()
    //특정 위치 값에서 발동되는 배경음악 페이드인아웃효과, x축 y축 값을 각각 맞춰 수정하면 언제든 ㅇㅋ
    {
        if (transform.position.x <= -1f) //위치 도달 전의 값
        {
            GM_B.GetComponent<ForBGM>().BGMfirst.GetComponent<AudioSource>().volume = 1f;
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
            GM_B.GetComponent<ForBGM>().BGMfirst.GetComponent<AudioSource>().volume = 0.6f;
            GM_B.GetComponent<ForBGM>().BGM2.GetComponent<AudioSource>().volume = 0.2f;

            ausrc.clip = walkSouneEvt("wood");
        }
        if (transform.position.x >= 0.5f)
        {
            GM_B.GetComponent<ForBGM>().BGMfirst.GetComponent<AudioSource>().volume = 0.5f;
            GM_B.GetComponent<ForBGM>().BGM2.GetComponent<AudioSource>().volume = 0.5f;

            ausrc.clip = walkSouneEvt("wood");
        }

        if (transform.position.x >= 3f)
        {
            GM_B.GetComponent<ForBGM>().BGMfirst.GetComponent<AudioSource>().volume = 0.2f;
            GM_B.GetComponent<ForBGM>().BGM2.GetComponent<AudioSource>().volume = 0.6f;

            ausrc.clip = walkSouneEvt("wood");
        }

        if (transform.position.x >= 4.5f)
        {
            GM_B.GetComponent<ForBGM>().BGMfirst.GetComponent<AudioSource>().volume = 0f;
            GM_B.GetComponent<ForBGM>().BGM2.GetComponent<AudioSource>().volume = 0.8f;

            ausrc.clip = walkSouneEvt("wood");
        }

        if (transform.position.x >= 6f)
        {
            GM_B.GetComponent<ForBGM>().BGM2.GetComponent<AudioSource>().volume = 1f;

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


    public void jump()
    {
        {
            StartCoroutine("jumpMotion");
            GM.GetComponent<SoundEvt>().soundSample();
        }
    }


    IEnumerator jumpMotion()
    {
        // Short delay added before Projectile is thrown
        yield return new WaitForSeconds(1.5f);

        // Move projectile to the position of throwing object + add some offset if needed.
        Projectile.position = myTransform.position;

        // Calculate distance to target
        float target_Distance = Vector2.Distance(Projectile.position, Target.position);

        // Calculate the velocity needed to throw the object to the target at specified angle.
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / (gravity));

        // Extract the X  Y componenent of the velocity
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        // Calculate flight time.
        float flightDuration = Vx;

        // Rotate projectile to face the target.
        //Projectile.rotation = Quaternion.LookRotation(Target.position - Projectile.position);

        float elapse_time = 0;

        float f = 0;

        while (elapse_time < flightDuration)
        {

            Debug.Log(Time.deltaTime);

            Projectile.Translate(0.01f, (Vy - (gravity * elapse_time)) * (Time.deltaTime + f), 0);  //(a,b) a는 좌-우+구분 b는 점프 높이

            // Projectile.rotation = Quaternion.identity;

            elapse_time += Time.deltaTime;

            f = f + 0.00001f; //올라가는 속도 조절, 숫자가 클 수록 높이 점프

            yield return null;
        }

        //전체적으로 속도를 올리는 방법을 못 찾음 추후 해결해보기

    }


}
