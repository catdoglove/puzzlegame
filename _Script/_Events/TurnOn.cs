using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class TurnOn : MonoBehaviour
{
    public GameObject b_obj, s_obj,c_obj;

    UnityEngine.Color color;

    public GameObject GMC;

    private void Awake()
    {

        GMC.GetComponent<ShaderEffect>().changeShader17();
        Invoke("Wait", 0.1f);
    }


    void Wait()
    {
        StartCoroutine("imgFadeOut");
    }



    IEnumerator imgFadeOut()
    {
        s_obj.SetActive(false);
        c_obj.SetActive(false);
        yield return new WaitForSeconds(3f);


        //b_obj.SetActive(true);
        color = b_obj.GetComponent<SpriteRenderer>().color;


        for (float i = 1f; i > 0f; i -= 0.05f)
        {
            color.a = Mathf.Lerp(0f, 1f, i);
            b_obj.GetComponent<SpriteRenderer>().color = color;
            yield return new WaitForSeconds(0.05f);
        }
        //color.a = Mathf.Lerp(0f, 1f, 1f);
        //b_obj.GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.6f);

        PlayerPrefs.SetInt("escdont", 0);

        b_obj.SetActive(false);


    }




}
