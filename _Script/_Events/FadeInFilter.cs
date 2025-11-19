using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class FadeInFilter : MonoBehaviour
{
    public GameObject char_obj;
    public GameObject char_obj2;
    public GameObject char_obj3;

    public float char_f;
    public float charNow_f;
    public float charCon_f;
    public float charCon_f2;


    public AudioSource BGM1, BGM2;

    public GameObject GMC;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnEnable()
    {
    }


    void Update()
    {
        check();
    }


    public void check()
    {
        char_f = char_obj3.transform.position.x - char_obj2.transform.position.x;
        charNow_f = char_obj3.transform.position.x - char_obj.transform.position.x;

        charCon_f = (charNow_f / char_f);

        charCon_f2 = 1f - charCon_f;


        OnV();

        BGM1.GetComponent<AudioSource>().volume = charCon_f2;
        Debug.Log("" + charCon_f);


        if (charCon_f2 > 0.4f)
        {
            charCon_f2 = 0.4f;
        }

        GMC.GetComponent<ShaderEffect>().photo.BlendFX = charCon_f2;

        //char_obj2.transform.position.x;
    }

    public void OnV()
    {

        if (charCon_f2 < 0)
        {
            charCon_f2 = 0;
        }
        if (charCon_f2 > 0.8f)
        {
            charCon_f2 = 0.8f;
        }

    }

}
