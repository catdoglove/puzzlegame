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
    public Sprite [] charSPR;
    public Vector3 position;
    public Transform Target;
    public float firingAngle = 0;
    public float gravity = 1.5f;

    public Transform Projectile;
    private Transform myTransform;


    void Start()
    {
        //Invoke("jump", 2f);
            jump();
        

    }
    void Awake()
    {
        rigid2D = GetComponent<PolygonCollider2D>();
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
      charWalk();

    }




    void charWalk()
    {
        //Vector2 start = transform.position;

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


    public void jump()
    {
       // if (Input.GetKey(KeyCode.Space))
        {

            StartCoroutine("jumpMotion");
            
        }
    }

    IEnumerator Action_jump()
    {
        Rigidbody2D rdby = transform.GetComponent<Rigidbody2D>();
        rdby.velocity = Vector2.zero;
        rdby.gravityScale = 1f;
        rdby.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
        // transform.position = Vector3.MoveTowards(transform.position, new Vector3(-1f, moveY, 0), 5f * Time.deltaTime);
        //transform.Translate(new Vector3(-1f, transform.position.y, 0)* 5f * Time.deltaTime);

        // transform.Translate(new Vector3(-1f, transform.position.y, 0) * 5f * Time.deltaTime);

        transform.Translate(new Vector3(-1f, transform.position.y, 0) * 1f * Time.deltaTime);

        yield return new WaitForSeconds(0.1f);
        charSpr.GetComponent<SpriteRenderer>().flipX = false;
    }

    IEnumerator Run(float duration)
    {
        var runTime = 0.0f;

        while (runTime < duration)
        {
            charSpr.GetComponent<SpriteRenderer>().sprite = charSPR[0];
            runTime += Time.deltaTime;
            Rigidbody2D rdby = transform.GetComponent<Rigidbody2D>();
            rdby.velocity = Vector2.zero;
            rdby.gravityScale = 2f;
            rdby.AddForce(Vector2.up * 0.5f, ForceMode2D.Impulse);

            transform.Translate(new Vector3(-1f, transform.position.y, 0) * 1f * Time.deltaTime);

            yield return null;
        }

        charSpr.GetComponent<SpriteRenderer>().flipX = false;
    }

    IEnumerator jumpup(float duration)
    {
        var runTime = 0.0f;

        while (runTime < duration)
        {
            float f;
            charSpr.GetComponent<SpriteRenderer>().sprite = charSPR[0];
            runTime += Time.deltaTime;
            Rigidbody2D rdby = transform.GetComponent<Rigidbody2D>();
            rdby.velocity = Vector2.zero;
            rdby.gravityScale = 1.5f;
            rdby.AddForce(Vector2.up * 4f, ForceMode2D.Impulse);

            Debug.Log(transform.position.y);
            f = transform.position.y;
           // transform.Translate(new Vector3(5f, (f), 0) * 1f * Time.deltaTime);

            //rdby.MovePosition(rdby.position + Vector2.right * 1f * Time.deltaTime);
            yield return null;
        }

        charSpr.GetComponent<SpriteRenderer>().flipX = false;
      //  StartCoroutine(jumpdown(0.6f));
    }



    IEnumerator jumpdown(float duration)
    {
        var runTime = 0.0f;

        while (runTime < duration)
        {
            charSpr.GetComponent<SpriteRenderer>().sprite = charSPR[0];
            runTime += Time.deltaTime;
            Rigidbody2D rdby = transform.GetComponent<Rigidbody2D>();
            rdby.velocity = Vector2.zero;
            rdby.gravityScale = 2f;
            //rdby.AddForce(Vector2.up * 4f, ForceMode2D.Impulse);
            //Debug.Log(transform.position.x);
            transform.Translate(new Vector3(5f, (transform.position.y) * 1f, 0) * 1f * Time.deltaTime);

            yield return null;
        }

        charSpr.GetComponent<SpriteRenderer>().flipX = false;
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
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

        // Extract the X  Y componenent of the velocity
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        // Calculate flight time.
        float flightDuration = Vx;

        // Rotate projectile to face the target.
        //Projectile.rotation = Quaternion.LookRotation(Target.position - Projectile.position);

        float elapse_time = 0;

        while (elapse_time < flightDuration)
        {
            Projectile.Translate(0.01f, (Vy - (gravity * elapse_time)) * 2 * Time.deltaTime, 0);  //(a,b) a는 좌우구분 b는 점프 높이

            // Projectile.rotation = Quaternion.identity;

            elapse_time += Time.deltaTime;

            yield return null;
        }
    }






}
