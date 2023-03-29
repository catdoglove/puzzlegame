using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour
{
    private PolygonCollider2D rigid2D;
    int ckwalk = 0;
    int ckCrash = 0;

    public Animator charAni;
    float moveX, moveY, charspeed;
    float normalSpeed = 0.1f, runSpeed = 0.2f, crushSpeed = 0.05f;
    public Action keyaction = null;

    public GameObject charSpr;
    public Sprite[] charSPR;
    public Vector3 position;

    public Transform Target;
    public float firingAngle = 0;
    public float gravity = 1.5f;

    public Transform Projectile;
    private Transform myTransform;

    // Start is called before the first frame update

    void Awake()
    {
        myTransform = transform;
        rigid2D = GetComponent<PolygonCollider2D>();
    }

    void Start()
    {
       // jump();
    }

    void Update()
    {
        charWalk();

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
        }
        else
        {
            if (ckCrash == 1) charspeed = crushSpeed;
            else charspeed = normalSpeed;
            charAni.speed = 1.2f;
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

            f = f + 0.0001f; //올라가는 속도 조절, 숫자가 클 수록 높이 점프

            yield return null;
        }

        //전체적으로 속도를 올리는 방법을 못 찾음 추후 해결해보기

    }
}
