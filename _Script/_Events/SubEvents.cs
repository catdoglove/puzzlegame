using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class SubEvents : MonoBehaviour
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
        m1_obj.SetActive(false);
        m2_obj.SetActive(true);

    }
}
