using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deepForestHiddenLab : MonoBehaviour
{

    public Animator wreckageAni;
    public bool isCloser = false;
    public GameObject wreckageObj, wreckageObj2;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        wreckageObj.SetActive(true);
        wreckageObj2.SetActive(false);

        if(isCloser == true)
        {
            wreckageAni.Play("ani_bg08_laboratory_wreckage2");
        }

    }
}