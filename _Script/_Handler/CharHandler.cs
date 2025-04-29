using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharHandler : MonoBehaviour
{

    public GameObject char_obj, f_obj, BGM;

    public int event_i;


    public GameObject talkscene_obj;

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

            BGM.GetComponent<AudioSource>().volume = 0.3f;
        }

        if (event_i == 3)
        {

            BGM.GetComponent<AudioSource>().volume = 1f;
        }
        
        if (event_i == 4)
        {

            Cutscene1();
        }
    }
    
    void wait()
    {
        char_obj.SetActive(false);
        f_obj.SetActive(false);
    }


    /// <summary>
    /// 컷씬을 띄워줌
    /// </summary>
    void Cutscene1()
    {
        talkscene_obj.SetActive(true);
        talkscene_obj.SetActive(false);
    }


    /// <summary>
    /// 컷씬을 띄워줌
    /// </summary>
    void Cutscene2()
    {
        talkscene_obj.SetActive(true);
        talkscene_obj.SetActive(false);
    }

}
