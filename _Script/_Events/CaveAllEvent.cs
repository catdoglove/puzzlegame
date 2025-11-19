using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveAllEvent : MonoBehaviour
{
    public GameObject b_obj;

    public GameObject m1_obj, m2_obj;

    UnityEngine.Color color;

    public GameObject cut_obj;

    public GameObject GMC;


    public GameObject char_obj, mapRespawn_obj;

    IEnumerator imgFadeOut()
    {
        yield return new WaitForSeconds(0.6f);


        b_obj.SetActive(true);
        color = b_obj.GetComponent<SpriteRenderer>().color;


        for (float i = 0f; i <= 1f; i += 0.1f)
        {
            // CGM.transform.position = new Vector3(moveX, moveY, 0f);
            color.a = Mathf.Lerp(0f, 1f, i);
            b_obj.GetComponent<SpriteRenderer>().color = color;
            yield return new WaitForSeconds(0.05f);
        }
        color.a = Mathf.Lerp(0f, 1f, 1f);
        b_obj.GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.6f);

        PlayerPrefs.SetInt("escdont", 0);

        yield return new WaitForSeconds(1.6f);

        m1_obj.SetActive(false);
        m2_obj.SetActive(true);
    }

    public void MoveTo()
    {

        b_obj.SetActive(true);
        //color.a = Mathf.Lerp(0f, 1f, 1f);
        //b_obj.GetComponent<SpriteRenderer>().color = color;
        m1_obj.SetActive(false);
        m2_obj.SetActive(true);
    }

    public void ShowCut()
    {

        //b_obj.SetActive(true);
        //color.a = Mathf.Lerp(0f, 1f, 1f);
        //b_obj.GetComponent<SpriteRenderer>().color = color;
        //m1_obj.SetActive(false);
        //m2_obj.SetActive(true);
        cut_obj.SetActive(true);


        GMC.GetComponent<ShaderEffect>().OffShader();
    }
    public void MoveTo2()
    {

        cut_obj.SetActive(false);
        //color.a = Mathf.Lerp(0f, 1f, 1f);
        //b_obj.GetComponent<SpriteRenderer>().color = color;
        m1_obj.SetActive(false);
        m2_obj.SetActive(true);
    }


    public void Fade()
    {
        StartCoroutine("imgFadeOut2");
    }

    
    public void CharMove()
    {

        char_obj.transform.position = mapRespawn_obj.transform.position;
        char_obj.SetActive(true);
    }



    IEnumerator imgFadeOut2()
    {
        yield return new WaitForSeconds(0.6f);


        b_obj.SetActive(true);
        color = b_obj.GetComponent<SpriteRenderer>().color;


        for (float i = 0f; i <= 1f; i += 0.1f)
        {
            // CGM.transform.position = new Vector3(moveX, moveY, 0f);
            color.a = Mathf.Lerp(0f, 1f, i);
            b_obj.GetComponent<SpriteRenderer>().color = color;
            yield return new WaitForSeconds(0.1f);
        }
        color.a = Mathf.Lerp(0f, 1f, 1f);
        b_obj.GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.6f);

        PlayerPrefs.SetInt("escdont", 0);

        yield return new WaitForSeconds(0.1f);

        m1_obj.SetActive(false);
        m2_obj.SetActive(true);
        b_obj.SetActive(false);
    }
}
