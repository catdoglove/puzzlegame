using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class SpiderAniEvent : MonoBehaviour
{
    public GameObject b_obj;

    public GameObject m1_obj, m2_obj;

    UnityEngine.Color color;



    // Start is called before the first frame update
    void Start()
    {
        
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        black();

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        black();
    }

    public void black()
    {
        b_obj.SetActive(true);
        color.a = Mathf.Lerp(0f, 1f, 1f);
        b_obj.GetComponent<SpriteRenderer>().color = color;
        m1_obj.SetActive(false);
        m2_obj.SetActive(true);

    }
}
