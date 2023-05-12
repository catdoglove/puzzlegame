using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimailInformation : MonoBehaviour
{
    List<Dictionary<string, object>> data_animal; //csv파일
    int allArr = 7; 
    string text_str;
    public Text No_txt,basic_txt, detail_txt, detail_txt2;
    int pageNum = 0 , animalNum=3; //0토끼 2양 3곰, 
    public Sprite[] animalSpr, materialSpr;
    public GameObject animalImg, material1, material2, material3, materialArea1, materialArea2, materialArea3, infoArea1, infoArea2;
    SpriteRenderer spRer;


    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetString("changeLanguage", "KOR") == "KOR")
        {
            data_animal = CSVReader.Read("CSV/animals_information");
        }
        else if (PlayerPrefs.GetString("changeLanguage", "KOR") == "ENG")
        {
            data_animal = CSVReader.Read("CSV/animals_information_eng");
        }
        spRer = animalImg.GetComponent<SpriteRenderer>();
        checkAnimal();
        insideInformation();

    }

    void checkAnimal()
    {
        animalNum = PlayerPrefs.GetInt("showAnimal", animalNum); //0부터 해당 캐릭터 보여주기
        PlayerPrefs.SetInt("AmImet" + animalNum, 99); //캐릭터 만났는가 체크
        PlayerPrefs.SetInt("canSeeMaterial" + animalNum, 99); //퀘스트를 깼는가
        PlayerPrefs.SetInt("canSeeInfo_basic" + animalNum, 99); //퀘스트를 깼는가
        PlayerPrefs.SetInt("canSeeInfo_detail" + animalNum, 0); //추가 퀘스트를 깼는가

    }

    public void showINFO_L()
    {

        checkAnimal();

        if (pageNum <= 0)
        {

        }
        else
        {
            pageNum--;
            insideInformation();

        }

    }

    public void showINFO_R()
    {

        checkAnimal();

        if (pageNum < allArr)
        {
            pageNum++;
            insideInformation();
        }
    }
    
    void insideInformation()
    {
        materialArea1.SetActive(false);
        materialArea2.SetActive(false);
        materialArea3.SetActive(false);
        infoArea1.SetActive(false);
        infoArea2.SetActive(false);
        spRer.color = new Color(0, 0, 0, 1);

        animalImg.GetComponent<SpriteRenderer>().sprite = animalSpr[pageNum];

        if(pageNum < 10) //일의자리
        {
            No_txt.text = "No.0" + (pageNum + 1);
        }
        else
        {
            No_txt.text = "No." + (pageNum + 1);
        }


        if(pageNum == animalNum) //해당 캐릭터 보여주기
        {
            unlockAnimal();
        }

        text_str = "" + data_animal[0]["No" + (pageNum + 1)];
        basic_txt.text = text_str;


        text_str = "" + data_animal[1]["No" + (pageNum + 1)];
        detail_txt.text = text_str;
        detail_txt2.text = text_str;
    }

    void unlockAnimal()
    {
        if (PlayerPrefs.GetInt("AmImet" + pageNum, 0) == 99) //만난적이 있다면 열리기
        {
            spRer.color = new Color(0.9f, 0.9f, 0.9f, 1);

            if (PlayerPrefs.GetInt("canSeeMaterial" + pageNum, 0) == 99) //조건에 따라 보여지는 재료
            {
                showMaterial();
            }

            if (PlayerPrefs.GetInt("canSeeInfo_basic" + pageNum, 0) == 99) //조건에 따라 보여지는 1번째 내용
            {
                infoArea1.SetActive(true);
            }

            if (PlayerPrefs.GetInt("canSeeInfo_detail" + pageNum, 0) == 99)//특수조건에서 보여지는 2번째 내용
            {
                infoArea2.SetActive(true);
            }

        }
        else
        {
        }
    }



    void showMaterial() //아이템 보여주기
    {
        text_str = "" + data_animal[2]["No" + (pageNum + 1)];

        if ((text_str == "x")) { }
        else
        {
            materialArea1.SetActive(true);

            if (text_str == "jam1")
            {
                material1.GetComponent<SpriteRenderer>().sprite = materialSpr[0];
            }

            if (text_str == "jam2")
            {
                material1.GetComponent<SpriteRenderer>().sprite = materialSpr[1];
            }

            if (text_str == "jellybear1")
            {
                material1.GetComponent<SpriteRenderer>().sprite = materialSpr[2];
            }

            if (text_str == "jellybear2")
            {
                material1.GetComponent<SpriteRenderer>().sprite = materialSpr[3];
            }

            if (text_str == "cotton")
            {
                material1.GetComponent<SpriteRenderer>().sprite = materialSpr[4];
            }
        }


        text_str = "" + data_animal[3]["No" + (pageNum + 1)];

        if ((text_str == "x")) { }
        else
        {
            if (PlayerPrefs.GetInt("canSeeInfo_detail" + pageNum, 0) == 99)//특수조건에서 보여지는 2번째 내용 
            {

                if (text_str == "jellyhidden")
                {
                    materialArea2.SetActive(true);
                    material2.GetComponent<SpriteRenderer>().sprite = materialSpr[3];
                }
            }

        }

    }
}
