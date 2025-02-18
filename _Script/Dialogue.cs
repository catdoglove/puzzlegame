using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public Text txt;
    string txt_str,txt_char;
    int iline = 0; //줄 수
    bool isTalk = false; //대화 중첩 방지
    public int cnt = 0;

    private string text;
    public Text targetText;
    private float txtSpeed = 0.1f; //대사속도

    List<Dictionary<string, object>> data_talk;

    public SpriteRenderer subChar;
    public GameObject subChar1,subChar2, subChar3, subChar4;

    public Sprite [] subCharSpr;
    public GameObject subDlg,charDlg, subCursor;
    int placeNum = 1; //숫자에 따라 장소 인지 임시?

    // Start is called before the first frame update
    void Start()
    {
       // PlayerPrefs.SetInt("caveFeatherWalk", 0);
        data_talk = CSVReader.Read("CSV/talk_text");
        PlayerPrefs.SetInt("charDlgIsWork", 99);
        Invoke("JustOne",1f); //임시위치 :  이벶트 진입했을 때 스페이스바 없이 대사가 자동으로 뜨게해야함
    }


    void JustOne()
    {
        subDlg.SetActive(true);
        if (isTalk == true)
        {
            txt.text = txt_str;
            cnt = text.Length;
        }
        else
        {
            showTextDialogue();
        }

    }    
    void subDlgDelay()
    {
        subDlg.SetActive(false);
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("charDlgIsWork", 0) == 0)
        {

            //대화가 출력중일때 중첩되지 않도록 방지하는 역할
            if (Input.GetKeyDown(KeyCode.Space) || PlayerPrefs.GetInt("charDlgLeft", 0) == 1 || PlayerPrefs.GetInt("charDlgRight", 0) == 1) 
            {
                //*********************************************************************//
                //여기에 나중에 사운드 넣어야한다 샘플씬에는 효과음이 없어서 테스트불가//
                //*********************************************************************//

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

            /*
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
            */
        }

    }



    void TextClear() //대화가 이어져서 출력되지 않도록 클리어 해주는 역할
    {

        switch (placeNum)
        {
            case 1: // 조력자추락 맵
                txt_str = "" + data_talk[iline]["No2"];
                txt.text = txt_str;
                text = targetText.text.ToString();
                targetText.text = " ";


                //조력자 및 선택지
                txt_char = "" + data_talk[iline]["No1"];
                if (txt_char == "0")
                {
                    subChar.sprite = subCharSpr[0];
                    PlayerPrefs.SetInt("charDlgIsWork", 0);

                }
                else if (txt_char == "1")
                {
                    subChar.sprite = subCharSpr[1];
                    PlayerPrefs.SetInt("charDlgIsWork", 0);

                    subChar3.SetActive(false);
                    subChar1.SetActive(true);

                    if (txt_str.Contains("괘..")) //말풍선쉼
                    {
                        subChar3.SetActive(true);
                        subChar1.SetActive(false);
                    }

                }
                else if (txt_char == "99") //선택지고르기
                {
                    PlayerPrefs.SetInt("charDlgIsWork", 99);
                }
                else if (txt_char == "88") //대화마무리페이드아웃되는곳
                {
                    PlayerPrefs.SetInt("charDlgIsWork", 99);
                    subChar1.SetActive(false);
                    subChar2.SetActive(true);
                    subChar3.SetActive(false);
                }


                //주인공선택지
                if (PlayerPrefs.GetInt("charDlgLeft", 0) == 1)
                {
                    txt_str = "" + data_talk[iline]["No2"];
                    PlayerPrefs.SetInt("charDlgLeft", 0);
                    PlayerPrefs.SetInt("charDlgRight", 0);
                    charDlg.SetActive(false);
                }
                else if (PlayerPrefs.GetInt("charDlgRight", 0) == 1)
                {
                    txt_str = "" + data_talk[iline]["No3"];
                    PlayerPrefs.SetInt("charDlgLeft", 0);
                    PlayerPrefs.SetInt("charDlgRight", 0);
                    charDlg.SetActive(false);
                }

                break;

            case 2: //조력자벽화 맵

                bool wallTF = true;
                if (wallTF)
                {
                    txt_str = "" + data_talk[0]["No4"];
                    PlayerPrefs.SetInt("charDlgIsWork", 0);
                    wallTF = false;
                }
                PlayerPrefs.SetInt("charDlgIsWork", 99);
                Invoke("subDlgDelay", 3.5f);

                break;

            case 3: //조력자탈출 맵
                if(PlayerPrefs.GetInt("caveFeatherWalk", 0) == 1)
                {
                    subChar4.SetActive(true);
                    txt_str = "" + data_talk[iline]["No5"];
                    PlayerPrefs.SetInt("charDlgIsWork", 0);
                    /********캐릭터 못 움직이게******/
                }
                break;

            default:
                break;
        }




        txt.text = txt_str;
        text = targetText.text.ToString();
        targetText.text = "";

        
        
        if (txt_str.Contains("X")) //말풍선쉼
        {
            PlayerPrefs.SetInt("charDlgIsWork", 99);
            subDlg.SetActive(false);
            Invoke("JustOne", 1.7f);

        }
        else if (txt_str.Contains("Z")) //대화끝
        {
            subDlg.SetActive(false);
        }
        else
        {
           // subDlg.SetActive(true);
        }

        

        if (iline < 26)  //전체(8줄) - 1 = 7
        {
            iline++;
        }
        else
        {
            iline = 0;
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

        subCursor.SetActive(false);
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
        subCursor.SetActive(true);

        if (subCursor.activeSelf == true && txt_char == "99")
        {
            charDlg.SetActive(true);
            PlayerPrefs.SetInt("cursorActive", 1);//클릭전에 마우스 보이기
        }


    }

    

}
