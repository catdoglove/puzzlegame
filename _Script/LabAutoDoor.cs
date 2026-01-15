using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabAutoDoor : MonoBehaviour
{
    public GameObject labDoorCloseImg, labDoorOpenImg, trainGOImg, trainGOImg2, autodoorCol;
    public bool istrainGo, isautoDoor, isInDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        labDoorCloseImg.SetActive(false);
        labDoorOpenImg.SetActive(true);


        if (isInDoor) //연구소 문
        {
            Invoke("trueColliderDoor", 0.5f); //문 딜레이
        }

        if (isautoDoor) //열차 자동문 출입방지용
        {
            Invoke("falseColliderDoor", 1f); //문 딜레이
        }

        if (istrainGo) //열차 출발용
        {
            trainGOImg.SetActive(true);
            trainGOImg2.SetActive(false);
            //나중에 주인공 false 해줘야함
        }

    }

    void trueColliderDoor()
    {
        autodoorCol.SetActive(true);
    }

    void falseColliderDoor()
    {
        autodoorCol.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
    }
}
