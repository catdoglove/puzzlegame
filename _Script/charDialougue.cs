using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charDialougue : MonoBehaviour
{
    public GameObject choose1, choose2;
    public int dlgNum;

    void Update()
    {

    }

    void OnMouseDown()
    {
        click1();
    }

    private void OnMouseExit()
    {
        Debug.Log("마우스벗어남");
    }

    public void click1()
    {
        switch (dlgNum)
        {
            case 5: //왼쪽 선택지
                PlayerPrefs.SetInt("charDlgIsWork", 0);
                PlayerPrefs.SetInt("charDlgLeft", 1);
              //  choose1.SetActive(false);
                Debug.Log("왼쪽");
                break;

            case 6: //오른쪽 선택지
                PlayerPrefs.SetInt("charDlgIsWork", 0);
                PlayerPrefs.SetInt("charDlgRight", 1);
            //    choose2.SetActive(false);
                Debug.Log("오른쪽");
                break;

            default:
                break;

        }

        PlayerPrefs.SetInt("cursorActive", 0);//클릭하면 마우스 사라지기
    }


}
