using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventScenes : MonoBehaviour
{
    public GameObject[] move_obj;
    public GameObject main_obj,w_obj, a_obj, s_obj, d_obj;
    public GameObject[] OutOfScreen_obj;
    public GameObject note_obj;
    public Sprite[] event_spr;
    public GameObject goal_obj, pBox_obj;

    public int eventP_i;

    public Vector3 position0, position1,position2;
    public float Speed = 8;

    public int turn_i=0;

    

    //char
    public Vector3 cPosition;
    public GameObject cMain_obj;
    public GameObject GM;

    //첫이벤트
    public GameObject dream_obj;

    // Start is called before the first frame update
    void Start()
    {
        eventP_i = 0;

        dream_obj.SetActive(true);
        StartCoroutine("StartEvent");

        GM.GetComponent<MoveCharacter>().canMove = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {

            if (eventP_i == 3&& turn_i==1)
            {
                Event3();
                turn_i = 0;
            }
        }

        if (Input.GetKey(KeyCode.D))
        {

            if (eventP_i == 2&& turn_i==1)
            {
                Event2();
                turn_i = 0;
            }
        }
        if (Input.GetKey(KeyCode.W))
        {

            if (eventP_i == 1)
            {
                Event1();
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
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
        int in_i = 1;
        position0 = move_obj[0].transform.position;
        while (in_i == 1)
        {
            position0.y = position0.y + 30f * Time.deltaTime;
            move_obj[0].transform.position = position0;
            
            if (position0.y >= OutOfScreen_obj[0].transform.position.y)
            {
                in_i = 0;
                turn_i = 1;
            }
            
            yield return new WaitForSeconds(0.01f);
        }
    }


    IEnumerator EventR()
    {
        int in_i = 1;
        position1 = move_obj[1].transform.position;
        while (in_i == 1)
        {
            position1.x = position1.x + 40f * Time.deltaTime;
            move_obj[1].transform.position = position1;
            
            if (position1.x >= OutOfScreen_obj[3].transform.position.x)
            {
                in_i = 0;
                note_obj.SetActive(true);
                turn_i = 1;
            }

            yield return new WaitForSeconds(0.01f);
        }

    }

    IEnumerator EventL()
    {
        note_obj.SetActive(false);
        int in_i = 1;
        position2 = move_obj[2].transform.position;
        while (in_i == 1)
        {
            position2.x = position2.x - 40f * Time.deltaTime;
            move_obj[2].transform.position = position2;
            
            if (position2.x <= OutOfScreen_obj[1].transform.position.x)
            {

                in_i = 0;
                turn_i = 1;
                main_obj.SetActive(false);
                GM.GetComponent<MoveCharacter>().canMove = true;
                pBox_obj.SetActive(false);
            }

            yield return new WaitForSeconds(0.01f);
        }

    }



    IEnumerator EventCharR()
    {
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
                GM.GetComponent<MoveCharacter>().position = cPosition;
                GM.GetComponent<MoveCharacter>().canMove = true;
            }

            yield return new WaitForSeconds(0.01f);
        }

    }


    IEnumerator StartEvent()
    {
        int in_i = 1;

        while (in_i == 1)
        {

            yield return new WaitForSeconds(5f);
            in_i = 0;
        }

        dream_obj.SetActive(false);
        yield return new WaitForSeconds(0.8f);
        StartEvent1();
    }

}
