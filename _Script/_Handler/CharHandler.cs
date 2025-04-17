using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharHandler : MonoBehaviour
{

    public GameObject char_obj, f_obj, BGM;

    public int event_i;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        if (event_i==0)
        {
            char_obj.SetActive(false);
            f_obj.SetActive(false);
        }
        if (event_i==1)
        {
            char_obj.SetActive(false);
            f_obj.SetActive(false);
            Invoke("wait", 0.1f);
        }
        else
        {
        }

        if (event_i==2)
        {

            BGM.GetComponent<AudioSource>().volume = 0.4f;
        }

        if (event_i == 3)
        {

            BGM.GetComponent<AudioSource>().volume = 1f;
        }
    }
    
    void wait()
    {
        char_obj.SetActive(false);
        f_obj.SetActive(false);
    }

}
