using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventScenes : MonoBehaviour
{
    public GameObject[] move_obj;
    public GameObject main_obj,w_obj, a_obj, s_obj, d_obj;
    public GameObject[] OutOfScreen_obj;
    public GameObject note_obj, note2_obj;
    public Sprite[] event_spr;
    public GameObject goal_obj, pBox_obj;

    public int eventP_i;

    public Vector3 position0, position1,position2, position3;
    public float Speed = 8;

    public int turn_i=0;

    Color color, color2;


    //char
    public Vector3 cPosition;
    public GameObject cMain_obj;
    public GameObject GM;

    //첫이벤트
    public GameObject dream_obj;

    public GameObject SGM;


    /// <summary>
    /// 캐릭터 방울 착용
    /// </summary>
    public GameObject noneBell_obj;

    public GameObject letter_obj;
    public Sprite letter_spr;

    public GameObject black_obj;

    public bool rand_b;

    public GameObject[] rand_obj, rand2_obj;
    public int rand_i, randCul_i;
    public static int[] randColorF_i = new int[4];

    // Start is called before the first frame update
    void Start()
    {
        eventP_i = 0;

        
        StartCoroutine("StartEvent");

        GM.GetComponent<CharMove>().canMove = false;
        
        
        if (PlayerPrefs.GetString("changeLanguage", "") == "ENG")
        {
            note_obj.GetComponent<Image>().sprite = letter_spr;
        }

        SetWorld();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {

            if (eventP_i == 4 && turn_i == 1)
            {
                Event4();
                turn_i = 0;
                a_obj.SetActive(false);
            }

        }

        if (Input.GetKey(KeyCode.D))
        {

            if (eventP_i == 2&& turn_i==1)
            {
                Event2();
                turn_i = 0;
                d_obj.SetActive(false);
            }
        }
        if (Input.GetKey(KeyCode.W))
        {

            if (eventP_i == 1)
            {
                Event1();
                w_obj.SetActive(false);
            }
        }

        if (Input.GetKey(KeyCode.S))
        {

            if (eventP_i == 3 && turn_i == 1)
            {
                Event3();
                turn_i = 0;
                s_obj.SetActive(false);
            }
        }
    }


    public void StartEvent1()
    {
        eventP_i++;
        move_obj[0].SetActive(true);
        move_obj[1].SetActive(true);
        move_obj[2].SetActive(true);
        move_obj[3].SetActive(true);
        main_obj.SetActive(true);
    }

    void Event1()
    {
        StartCoroutine("EventUp");
        eventP_i++;
    }
    void Event2()
    {
        StartCoroutine("EventR");
        eventP_i++;
    }
    void Event3()
    {
        StartCoroutine("EventDown");
        eventP_i++;
    }
    
    void Event4()
    {
        StartCoroutine("EventL");
        eventP_i++;
    }

    void EndEvent1()
    {
        move_obj[0].SetActive(false);
        move_obj[1].SetActive(false);
        move_obj[2].SetActive(false);
    }



    /// <summary>
    /// 위로 올라가기
    /// </summary>
    /// <returns></returns>
    IEnumerator EventUp()
    {

        SGM.GetComponent<SoundEvt>().soundBoxWASD();
        int in_i = 1;
        position0 = move_obj[0].transform.position;
        while (in_i == 1)
        {
            position0.y = position0.y + 20f * Time.deltaTime;
            move_obj[0].transform.position = position0;
            
            if (position0.y >= OutOfScreen_obj[0].transform.position.y)
            {
                in_i = 0;
                turn_i = 1;
                d_obj.SetActive(true);
            }
            
            yield return new WaitForSeconds(0.01f);
        }
    }


    IEnumerator EventR()
    {
        SGM.GetComponent<SoundEvt>().soundBoxWASD();
        int in_i = 1;
        position1 = move_obj[1].transform.position;
        while (in_i == 1)
        {
            position1.x = position1.x + 20f * Time.deltaTime;
            move_obj[1].transform.position = position1;
            
            if (position1.x >= OutOfScreen_obj[3].transform.position.x)
            {
                in_i = 0;
                note_obj.SetActive(true);
                turn_i = 1;
                s_obj.SetActive(true);
            }

            yield return new WaitForSeconds(0.01f);
        }

    }

    IEnumerator EventL()
    {
        SGM.GetComponent<SoundEvt>().soundBoxWASD();
        note_obj.SetActive(false);
        int in_i = 1;
        position2 = move_obj[2].transform.position;
        while (in_i == 1)
        {
            position2.x = position2.x - 20f * Time.deltaTime;
            move_obj[2].transform.position = position2;
            
            if (position2.x <= OutOfScreen_obj[1].transform.position.x)
            {

                in_i = 0;
                turn_i = 1;
                main_obj.SetActive(false);
                GM.GetComponent<CharMove>().canMove = true;
                pBox_obj.SetActive(false);

                SGM.GetComponent<SoundEvt>().soundBoxBell();

                PlayerPrefs.SetInt("prmove",1);
            }

            yield return new WaitForSeconds(0.01f);
        }

    }

    IEnumerator EventDown()
    {
        SGM.GetComponent<SoundEvt>().soundBoxWASD();
        int in_i = 1;
        position3 = note_obj.transform.position;
        while (in_i == 1)
        {
            position3.y = position3.y - 20f * Time.deltaTime;
            note_obj.transform.position = position3;
            if (position3.y <= OutOfScreen_obj[2].transform.position.y)
            {
                in_i = 0;
                turn_i = 1;
                note_obj.SetActive(false);
                a_obj.SetActive(true);
            }
            yield return new WaitForSeconds(0.01f);
        }
    }



    IEnumerator EventCharR()
    {
        SGM.GetComponent<SoundEvt>().soundBoxWASD();
        int in_i = 1;
        cPosition = cMain_obj.transform.position;
        while (in_i == 1)
        {
            cPosition.x = cPosition.x + 5f * Time.deltaTime;
            cMain_obj.transform.position = cPosition;

            if (cPosition.x >= goal_obj.transform.position.x)
            {
                in_i = 0;
                turn_i = 1;
               // GM.GetComponent<MoveCharacter>().position = cPosition;
                GM.GetComponent<CharMove>().canMove = true;
            }

            yield return new WaitForSeconds(0.01f);
        }

    }


    IEnumerator StartEvent()
    {
        int in_i = 1;

        yield return new WaitForSeconds(2.5f);

        black_obj.SetActive(false);
        dream_obj.SetActive(true);
        while (in_i == 1)
        {

            yield return new WaitForSeconds(5f);
            in_i = 0;
        }

        black_obj.SetActive(true);
        black_obj.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        StartCoroutine("FadeIn");

    }

    IEnumerator FadeIn()
    {
        int in_i = 1;

        yield return new WaitForSeconds(1f);




        black_obj.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);


        while (in_i == 1)
        {

            float i_f = 0f;

            for (i_f = 0f; i_f < 1f; i_f += 0.05f)
            {
                color.a = Mathf.Lerp(0f, 1f, i_f);
                black_obj.GetComponent<SpriteRenderer>().color = color;
                yield return new WaitForSeconds(0.05f);
            }
            yield return new WaitForSeconds(2f); //변경하기
            in_i = 0;
        }


        SGM.GetComponent<SoundEvt>().soundCloseDoor();
        black_obj.SetActive(false);
        dream_obj.SetActive(false);


        yield return new WaitForSeconds(1.5f);
        StartEvent1();
        SGM.GetComponent<SoundEvt>().soundBoxOpen();


        noneBell_obj.SetActive(false);

        /*
        color = fade_obj.GetComponent<SpriteRenderer>().color;
        //color2 = fade_obj.GetComponent<SpriteRenderer>().color;
        moveX = fade_obj.transform.position.x;
        moveY = fade_obj.transform.position.y;
        fade_obj.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        fade2_obj.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        for (i_i = 0; i_i < 15; i_i++)
        {
            color = new Color(1f, 1f, 1f, 1f);
            //color2 = new Color(1f, 1f, 1f, 1f);
            fade_obj.transform.position = new Vector2(moveX, moveY);
            moveY = moveY + 0.1f;
            yield return new WaitForSeconds(0.01f);
        }
        for (i_f = 1f; i_f > 0f; i_f -= 0.05f)
        {
            color.a = Mathf.Lerp(0f, 1f, i_f);
            //color2.a = Mathf.Lerp(0f, 1f, i_f);
            fade_obj.GetComponent<SpriteRenderer>().color = color;
            fade2_obj.GetComponent<SpriteRenderer>().color = color;
            yield return null;
        }
        fade_obj.transform.position = new Vector2(15f, 15f);
        */
    }

    void SetWorld()
    {
        rand_i = Random.Range(0, 2);

        if (rand_i==0)
        {
            for (int i = 0; i < rand_obj.Length; i++)
            {
                rand_obj[i].SetActive(false);
                rand2_obj[i].SetActive(true);
            }
        }
        else
        {

        }

        rand_i = Random.Range(0,4);
        for (int i = 0; i < 4; i++)
        {
            randColorF_i[rand_i] = i;
            rand_i++;
            if (rand_i >= 4)
            {
                rand_i = 0;
            }

        }
        if (randColorF_i[0] == 0)
        {
            randCul_i = randColorF_i[0];
            randColorF_i[0] = randColorF_i[3];
            randColorF_i[3] = randCul_i;
        }


    }
}
