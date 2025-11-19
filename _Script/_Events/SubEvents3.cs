using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubEvents3 : MonoBehaviour
{
    public GameObject b_obj;

    public GameObject m1_obj, m2_obj;

    public bool b_active = false;

    UnityEngine.Color color;



    // Start is called before the first frame update
    void Start()
    {

    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (b_active)
        {
            black1();
        }
        else
        {
            black2();
        }

    }


    public void black1()
    {
        b_obj.GetComponent<SpriteRenderer>().flipX = true;
    }
    public void black2()
    {
        b_obj.GetComponent<SpriteRenderer>().flipX = false;
    }
}
