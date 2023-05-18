using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class example : MonoBehaviour
{
    private Rigidbody2D rigid2D;
    public Animator boatAni;
    bool onetime = true;
    public int mapwhere = 88; //보트맵

    float moveX;
    public GameObject boatSpr, hiddenSpr,backBG,frontBG;

    public GameObject moveGM;

    // Start is called before the first frame update
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (mapwhere == 99)
        {
            boatAnimation();
            //Invoke("boatAnimation", 2f);//2초뒤에 배타는 모션 실행
            mapwhere = 0;
        }
        else if (mapwhere == 88)
        {
            smallBoatGO();
        }
    }

    void smallBoatGO()
    {
        moveX = 0f;
        /*
        if (Input.GetKey(KeyCode.A))
        {
            moveX -= 0.07f; boatSpr.GetComponent<SpriteRenderer>().flipX = true;
            if (transform.position.x <= 0f) //위치 도달 이후 부터 ~~
            {
                frontBG.transform.Translate(new Vector3(moveX, 0, 0) * -0.09f);
                backBG.transform.Translate(new Vector3(moveX, 0, 0) * -0.06f);
            }
        }
        */
        if (Input.GetKey(KeyCode.D))
        {
            moveX += 0.07f; boatSpr.GetComponent<SpriteRenderer>().flipX = false;

            if (transform.position.x >= -6f) //위치 도달 이후 부터 ~~
            {
                frontBG.transform.Translate(new Vector3(moveX, 0, 0) * -0.09f);
                backBG.transform.Translate(new Vector3(moveX, 0, 0) * -0.06f);
            }

        }


        transform.Translate(new Vector3(moveX, 0, 0) * 0.1f);


        float ff = 0;
        if (transform.position.x >= 4.5f) //위치 도달 이후 부터 ~~
        {
            ff--;
            hiddenSpr.transform.Translate(new Vector3(0, ff, 0) * 0.08f);
        }

    }

    void boatAnimation()
    {
        while (onetime)
        {
            boatAni.Play("ani_boat_ready");
            onetime = false;
        }
        Invoke("boatGOani", 2f);


    }

    void boatGOani()
    {
        boatAni.Play("ani_boat_up");
        StartCoroutine("Action_go");
    }

    IEnumerator Action_go()
    {
        int a = 1;
        while (a <= 50) //늘리기
        {
            Vector3 destination = new Vector3(13, transform.position.y, 0);
            transform.position = Vector3.MoveTowards(transform.position, destination, 6.5f * Time.deltaTime); //노젓는속도
            yield return new WaitForSeconds(0.01f);
            a++;
        }

        moveGM.GetComponent<MoveMap>().MovingMap();
    }
}
