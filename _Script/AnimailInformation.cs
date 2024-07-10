using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimailInformation : MonoBehaviour
{
    List<Dictionary<string, object>> data_animal; //csv파일
    List<Dictionary<string, object>> data_animal_name; //csv파일
    int allArr = 8; 
    string text_str;

    string textname_str;
    public Text No_txt,basic_txt, basic_txt2, basic_txt3, detail_txt, detail_txt2, title_txt, name_txt, title2_txt;
    int pageNum = 0 , animalNum=3; //0토끼 2양 3곰, 
    public Sprite[] animalSpr, materialSpr;
    public GameObject animalImg, material1, material2, material3, materialArea1, materialArea2, materialArea3, infoArea1, infoArea2, infoArea3, infoArea4;
    public SpriteRenderer spRer;
    int sizeint, sizeint2, robotNum;

    public GameObject SGM;

    public GameObject know_obj1, know_obj2;

    public int lg_i;



    private void OnEnable()
    {

        pageNum = 0;
        insideInformation();
        //FirstSet();
    }

    private void Awake()
    {
        PlayerPrefs.SetInt("cursorActive",0);
        if (PlayerPrefs.GetString("changeLanguage", "KOR") == "KOR")
        {
            lg_i = 0;
            data_animal = CSVReader.Read("CSV/animals_information");
            title_txt.text = "알려지지 않은 맛";
            title2_txt.text = "알려진 맛";
        }
        else if (PlayerPrefs.GetString("changeLanguage", "KOR") == "ENG")
        {
            data_animal = CSVReader.Read("CSV/animals_information_eng");
            title_txt.text = "Unknown flavor";
            title2_txt.text = "Known flavor";
            lg_i = 2;
        }

        data_animal_name = CSVReader.Read("CSV/animals_name");
    }

    // Start is called before the first frame update
    void Start()
    {
        //spRer = animalImg.GetComponent<SpriteRenderer>();
        checkAnimal();
        Invoke("insideInformation", 2f);
        //insideInformation();

    }

    void checkAnimal()
    {
        /*
        animalNum = PlayerPrefs.GetInt("showAnimal", animalNum); //0부터 해당 캐릭터 보여주기
        PlayerPrefs.SetInt("AmImet" + animalNum, 99); //캐릭터 만났는가 체크
        PlayerPrefs.SetInt("canSeeMaterial" + animalNum, 99); //퀘스트를 깼는가
        PlayerPrefs.SetInt("canSeeInfo_basic" + animalNum, 99); //퀘스트를 깼는가
        PlayerPrefs.SetInt("canSeeInfo_detail" + animalNum, 0); //추가 퀘스트를 깼는가
        */

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SGM.GetComponent<SoundEvt>().soundBook();
            showINFO_L();
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            SGM.GetComponent<SoundEvt>().soundBook();
            showINFO_R();
        }

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
        infoArea3.SetActive(false);
        infoArea4.SetActive(false);
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


        unlockAnimal();

        if (pageNum == animalNum) //해당 캐릭터 보여주기
        {
        }

        changeTextSize();

        text_str = "" + data_animal[0]["No" + (pageNum + 1)];
        basic_txt.text = "<size="+sizeint+">" + text_str + "</size>";


        text_str = "" + data_animal[1]["No" + (pageNum + 1)];
        basic_txt2.text = "<size=" + sizeint + ">" + text_str + "</size>";
        ;


        if (true) //로봇자아
        {
            robotNum = 0; // 0은 꺼짐, 2는 켜짐
        }

        text_str = "" + data_animal[2 + robotNum]["No" + (pageNum + 1)];
        basic_txt3.text = "<size=" + sizeint + ">" + text_str + "</size>";


        text_str = "" + data_animal[3 + robotNum]["No" + (pageNum + 1)];
        detail_txt.text = "<size=" + sizeint2 + ">" + text_str + "</size>";
        detail_txt2.text = "<size=" + sizeint2 + ">" + text_str + "</size>";


        if (PlayerPrefs.GetInt("canSeeInfo_detailo" + pageNum, 0) == 98)//특수조건에서 보여지는 3번째 내용
        {

            Debug.Log("pageNum");
            text_str = "" + data_animal[4]["No" + (pageNum + 1)];
            basic_txt3.text = "<size=" + sizeint + ">" + text_str + "</size>";
            
        }
        if (PlayerPrefs.GetInt("canSeeInfo_detailt" + pageNum, 0) == 98)//특수조건에서 보여지는 4번째 내용
        {


            text_str = "" + data_animal[5]["No" + (pageNum + 1)];
            detail_txt.text = "<size=" + sizeint2 + ">" + text_str + "</size>";
            detail_txt2.text = "<size=" + sizeint2 + ">" + text_str + "</size>";
            
        }

    }

    void changeTextSize()
    {
        
        if (PlayerPrefs.GetString("changeLanguage", "KOR") == "KOR")
        {
            sizeint = 50;
            sizeint2 = 45;
        }
        else if (PlayerPrefs.GetString("changeLanguage", "KOR") == "ENG")
        {
            sizeint = 43;
            sizeint2 = 40;
        }
    }


    void unlockAnimal()
    {
        int ck = 0;

        //materialArea1.SetActive(false);
        know_obj1.SetActive(true);
        know_obj2.SetActive(false);
        name_txt.text = " ???";
        Debug.Log(PlayerPrefs.GetInt("AmImet" + pageNum, 0) + "ds" + PlayerPrefs.GetInt("canSeeMaterial" + pageNum, 0));
        if (PlayerPrefs.GetInt("AmImet" + pageNum, 0) == 99) //만난적이 있다면 열리기
        {
            spRer.color = new Color(0.9f, 0.9f, 0.9f, 1);

            textname_str = "" + data_animal_name[lg_i]["No" + (pageNum + 1)];

            name_txt.text = "" + textname_str;

            if (PlayerPrefs.GetInt("canSeeMaterial" + pageNum, 0) == 99) //조건에 따라 보여지는 재료
            {
                showMaterial();
            }

            if (PlayerPrefs.GetInt("canSeeInfo_basic" + pageNum, 0) == 99) //조건에 따라 보여지는 1번째 내용
            {
                infoArea1.SetActive(true);
                ck++;
            }

            if (PlayerPrefs.GetInt("canSeeInfo_detail" + pageNum, 0) == 99)//특수조건에서 보여지는 2번째 내용
            {
                infoArea2.SetActive(true);
                ck++;
                materialArea1.SetActive(true);

            }

            if (PlayerPrefs.GetInt("canSeeInfo_detailo" + pageNum, 0) == 98)//특수조건에서 보여지는 3번째 내용
            {
                infoArea3.SetActive(true);
                ck++;
            }
            else if (PlayerPrefs.GetInt("canSeeInfo_detailo" + pageNum, 0) == 99)//특수조건에서 보여지는 3번째 내용
            {
                infoArea3.SetActive(true);
                ck++;
            }

            if (PlayerPrefs.GetInt("canSeeInfo_detailt" + pageNum, 0) == 98)//특수조건에서 보여지는 4번째 내용
            {
                
                infoArea4.SetActive(true);
                ck++;
            }else if (PlayerPrefs.GetInt("canSeeInfo_detailt" + pageNum, 0) == 99)//특수조건에서 보여지는 4번째 내용
            {
                infoArea4.SetActive(true);
                ck++;
            }

            if (ck>=4)
            {
                know_obj1.SetActive(false);
                know_obj2.SetActive(true);
            }

            //materialArea1.SetActive(true);
        }
        else
        {
        }

        if (pageNum>=5&& pageNum < 8)
        {
            materialArea1.SetActive(false);
        }
    }



    void showMaterial() //아이템 보여주기
    {
        text_str = "" + data_animal[6]["No" + (pageNum + 1)];

        if ((text_str == "x")) { }
        else
        {

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

            if (text_str == "pistachios")
            {
                //material1.GetComponent<SpriteRenderer>().sprite = materialSpr[5];
            }
        }


        text_str = "" + data_animal[7]["No" + (pageNum + 1)];

        if ((text_str == "x")) { }
        else
        {
            if (PlayerPrefs.GetInt("canSeeInfo_detailt" + pageNum, 0) == 99)//특수조건에서 보여지는 2번째 내용 
            {

                if (text_str == "jellyhidden")
                {
                    //materialArea2.SetActive(true);
                    material2.GetComponent<SpriteRenderer>().sprite = materialSpr[3];
                }
            }
        }
    }

    void FirstSet()
    {
        pageNum = 1;
        //showINFO_L();
    }

}
