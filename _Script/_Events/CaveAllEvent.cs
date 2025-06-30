using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveAllEvent : MonoBehaviour
{
    public GameObject b_obj;

    public GameObject m1_obj, m2_obj;

    UnityEngine.Color color;

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
}
