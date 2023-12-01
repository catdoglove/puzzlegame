using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class example : MonoBehaviour
{
    private Rigidbody2D rigid2D;
    public Animator boatAni;
    bool onetime = true;
    public int mapwhere = 77; //보트맵

    float moveX;
    public GameObject boatSpr, hiddenSpr,backBG,frontBG;

    public GameObject moveGM, SGM, GMC;
    int a = 0;

    public GameObject player_obj;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("justOneBoatMove", 0);
        if (mapwhere == 77)
        {
            boatAni.Play("ani_boat_up");
        }
        PlayerPrefs.SetInt("hide_sound1", 0);
        Application.targetFrameRate = 60; 

        rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (mapwhere == 99)
        {
            if (a==0)
            {
                boatAnimation();
                a = 1;
            }
        }
        else if (mapwhere == 88)
        {
            smallBoatGO();
        }
        else if (mapwhere == 77)
        {
            boatAnimation();
        }
    }

    void smallBoatGO()
    {
        moveX = 0f;
        if (Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveX += 0.07f; boatSpr.GetComponent<SpriteRenderer>().flipX = false;

            if (transform.position.x >= -6f) //위치 도달 이후 부터 ~~
            {
                frontBG.transform.Translate(new Vector3(moveX, 0, 0) * -0.24f);
                backBG.transform.Translate(new Vector3(moveX, 0, 0) * -0.20f);
            }

        }


        transform.Translate(new Vector3(moveX, 0, 0) * 0.3f);


        float ff = 0;
        if (transform.position.x >= 4.5f) //위치 도달 이후 부터 ~~
        {
            if (PlayerPrefs.GetInt("hide_sound1", 0) == 0) //한번만 실행되게
            {
                SGM.GetComponent<SoundEvt>().soundHide1(); //배에 audioaouscer선언
                PlayerPrefs.SetInt("hide_sound1", 99);
            }
            ff--;
            hiddenSpr.transform.Translate(new Vector3(0, ff, 0) * 0.2f);
        }

    }

    void boatAnimation()
    {
        if (mapwhere == 99) //호수건너기전
        {
            while (onetime)
            {
                boatAni.Play("ani_boat_ready");
                Invoke("waterSound", 2f);
                onetime = false;
            }
            Invoke("boatGOani", 2f);
        }
        else if (mapwhere == 77) //호수건넌후
        {
            if(PlayerPrefs.GetInt("justOneBoatMove", 0) == 0)
            {
                StartCoroutine("Action_go2");
                Invoke("waterSound", 0.1f);
                PlayerPrefs.SetInt("justOneBoatMove", 1);
            }
        }
        Debug.Log(mapwhere);
    }

    void boatGOani()
    {                
        boatAni.Play("ani_boat_up");
        StartCoroutine("Action_go");        
    }

    void waterSound()
    {
        SGM.GetComponent<SoundEvt>().soundWaterWalk(); //배에 audioaouscer선언
    }

    IEnumerator Action_go()
    {
        int a = 1;
        while (a <= 220) //늘리기
        {
            Vector3 destination = new Vector3(13, transform.position.y, 0);
            transform.position = Vector3.MoveTowards(transform.position, destination, 3.9f * Time.deltaTime); //노젓는속도
            yield return new WaitForSeconds(0.01f);
            a++;
        }

        GMC.GetComponent<ShaderEffect>().ShaderFilp();
        GMC.GetComponent<ShaderEffect>().changeShader1();
        GMC.GetComponent<ShaderEffect>().OffShader();
        moveGM.GetComponent<MoveMap>().MovingMap();
    }


    IEnumerator Action_go2()
    {

        GMC.GetComponent<ShaderEffect>().changeShader1();
        int a = 1;
        while (a <= 230) //늘리기
        {
            Vector3 destination = new Vector3(13, transform.position.y, 0);
            transform.position = Vector3.MoveTowards(transform.position, destination, 3.3f * Time.deltaTime); //노젓는속도
            yield return new WaitForSeconds(0.01f);
            a++;
        }

        
        while (onetime)
        {
            boatAni.Play("ani_boat_ready_next");
            onetime = false;
        }

        yield return new WaitForSeconds(2f);
        boatAni.Play("ani_boat2");
        //주인공 true
        player_obj.SetActive(true);

    }
}
