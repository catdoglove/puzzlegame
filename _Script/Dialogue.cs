using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public Text txt;
    string txt_str;
    int i = 0;
    bool isTalk = false; //대화 중첩 방지
    public int cnt = 0;

    private string text;
    public Text targetText;
    private float txtSpeed = 0.1f; //대사속도

    List<Dictionary<string, object>> data_talk;


    // Start is called before the first frame update
    void Start()
    {

        data_talk = CSVReader.Read("CSV/talk_text");

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //대화가 출력중일때 중첩되지 않도록 방지하는 역할
        {
            if (isTalk == true)
            {
                //스베이스바 또 누르면 대사가 한번에 나오도록
                txt.text = txt_str;
                cnt = text.Length;
            }
            else
            {
                showTextDialogue();
            }
        }


        if (isTalk == true)
        {
            if (Input.GetKeyDown(KeyCode.F)) //대화 속도 넘기기 or 빠르게 하기 or 자동넘기기(제일 보류하고싶은..)
            {
                txtSpeed = 0.05f;
            }

        }
        else
        {
            txtSpeed = 0.1f; //대사속도
        }


    }

    void TextClear() //대화가 이어져서 출력되지 않도록 클리어 해주는 역할
    {
        txt_str = "" + data_talk[i]["No1"];
        txt.text = txt_str;
        text = targetText.text.ToString();
        targetText.text = " ";
        if (i > 6)
        {
            i = 0;
        }
        else
        {
            i++;
        }
    }


    public void showTextDialogue() //대화창 출력
    {
        TextClear();
        StartCoroutine(showText(txtSpeed));
    }


    IEnumerator showText(float f) // 딱딱 대화 형식
    {
        cnt = 0;
        
        isTalk = true; //대화시작

        while (cnt != text.Length)
        {

            if (cnt < text.Length)
            {
                targetText.text += text[cnt].ToString();
                cnt++;
            }

            yield return new WaitForSeconds(txtSpeed);
        }

        isTalk = false; //대화끝
    }

}
