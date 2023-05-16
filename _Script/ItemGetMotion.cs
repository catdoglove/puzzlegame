﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGetMotion : MonoBehaviour
{


    Color color;
    public GameObject fade_obj;
    public float moveY, moveX;
    Vector2 mouseDragPos;
    public Vector2 wldObjectPos;

    int i_i;
    float i_f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void FadeItem()
    {
        i_i = 30;
        i_f = 0;
        fade_obj.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        StopAllCoroutines();

        i_i = 0;
        i_f = 1;
        StartCoroutine("imgFadeOut");
    }



    IEnumerator imgFadeOut()
    {
        color = fade_obj.GetComponent<SpriteRenderer>().color;
        moveX = fade_obj.transform.position.x;
        moveY = fade_obj.transform.position.y;
        fade_obj.GetComponent<SpriteRenderer>().color  = new Color(1f, 1f, 1f, 1f);
        for (i_i = 0; i_i < 30; i_i++)
        {
            color = new Color(1f, 1f, 1f, 1f);
            fade_obj.transform.position = new Vector2(moveX, moveY);
            moveY = moveY + 0.05f;
            yield return new WaitForSeconds(0.01f);
        }
        for (i_f = 1f; i_f > 0f; i_f -= 0.05f)
        {
            color.a = Mathf.Lerp(0f, 1f, i_f);
            fade_obj.GetComponent<SpriteRenderer>().color = color;
            yield return null;
        }
        fade_obj.transform.position = new Vector2(15f, 15f);
    }
}