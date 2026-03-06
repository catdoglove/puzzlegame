using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class titleMenuText : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler,
    IPointerDownHandler,
    IPointerUpHandler
{


    [SerializeField] private bool isNormal;
    public Button menuBtn;
    [SerializeField] private Sprite[] normal, change;

    private Image img;
    bool isMouseOver = false;
    void Awake()
    {
        PlayerPrefs.SetInt("isOptionSave", 1);
        img = GetComponent<Image>();
        img.alphaHitTestMinimumThreshold = 0.1f; //눌리는 부분 투명도 조절
    }
    // 마우스 올림
    public void OnPointerEnter(PointerEventData eventData)
    {
        int num = PlayerPrefs.GetInt("settingRealLanguageSave", 0); // 언어 번호 저장
        if (PlayerPrefs.GetInt("isOptionSave", 0) == 1)
        {            
            img.sprite = change[num];
            if (isNormal)
            {
                img.sprite = normal[num];
            }
            isMouseOver = true;
        }
        else if (PlayerPrefs.GetInt("isOptionSave", 0) == 2)
        {
            num = PlayerPrefs.GetInt("settingLanguageNum", 0); // 언어 번호 저장
            img.sprite = change[num];
            if (isNormal)
            {
                img.sprite = normal[num];
            }
            isMouseOver = true;
        }
    }

    // 마우스 나감
    public void OnPointerExit(PointerEventData eventData)
    {
        int num = PlayerPrefs.GetInt("settingRealLanguageSave", 0); // 언어 번호 저장
        if (PlayerPrefs.GetInt("isOptionSave", 0) == 1)
        {
            img.sprite = normal[num];
            isMouseOver = true;
        }
        else if (PlayerPrefs.GetInt("isOptionSave", 0) == 2)
        {
            num = PlayerPrefs.GetInt("settingLanguageNum", 0); // 언어 번호 저장
            img.sprite = normal[num];
            isMouseOver = true;
        }
    }

    // 버튼 누름
    public void OnPointerDown(PointerEventData eventData)
    {
        int num = PlayerPrefs.GetInt("settingRealLanguageSave", 0); // 언어 번호 저장
        if (PlayerPrefs.GetInt("isOptionSave", 0) == 1)
        {
            img.sprite = change[num];
            isMouseOver = true;
        }
        else if (PlayerPrefs.GetInt("isOptionSave", 0) == 2)
        {
            num = PlayerPrefs.GetInt("settingLanguageNum", 0); // 언어 번호 저장
            img.sprite = change[num];
            isMouseOver = true;
        }
    }
    

    // 버튼 뗌
    public void OnPointerUp(PointerEventData eventData)
    {
        int num = PlayerPrefs.GetInt("settingRealLanguageSave", 0); // 언어 번호 저장
        if (PlayerPrefs.GetInt("isOptionSave", 0) == 1)
        {
            img.sprite = normal[num];
            isMouseOver = true;
        }
        else if (PlayerPrefs.GetInt("isOptionSave", 0) == 2)
        {
            num = PlayerPrefs.GetInt("settingLanguageNum", 0); // 언어 번호 저장
            img.sprite = normal[num];
            isMouseOver = true;
        }
    }

}
