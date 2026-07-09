using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CheckCh : MonoBehaviour
{

    public int i = 0;
    public GameObject GameObject;


    void Start()
    {
        GameObject.GetComponent<GameController>().CompleteChapter(i);
    }


}
