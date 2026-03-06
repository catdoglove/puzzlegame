using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 필요
using UnityEngine.UI;

public class TitleEvt : MonoBehaviour
{
    public GameObject GM,startObj, bgStarImg1, bgStarImg2, escWnd, escBGImg;
    public GameObject optionImg, optionBtn, titleImg, menuImg, backMenuImg, charImg;

    public Button[] menuBtn, backMenuBtn ,escBtn;
    [SerializeField] private Sprite[] langSpaceBar,langKorSpr, langEngSpr, langJpSpr, langChSpr, langRuSpr, escBGSpr, langKorEsc, langEngEsc, langJpEsc, langChEsc, langRuEsc;
    [SerializeField] private Sprite[] langKorSpr2, langEngSpr2, langJpSpr2, langChSpr2, langRuSpr2;


    // Start is called before the first frame update
    void Start()
	{
       // PlayerPrefs.DeleteAll(); //테스트로 넣어둔 것인가?
        PlayerPrefs.SetInt("dogamisopen", 0);

        StartCoroutine("keyboardEvt");
        Cursor.visible = true;

        

        changeBtnLang();
        PlayerPrefs.SetInt("isOptionSave", 0);

    }

    void Update()  //임시
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            escWnd.SetActive(true);
            int num = PlayerPrefs.GetInt("settingRealLanguageSave", 0 -1); // 언어 번호 저장
            switch (num)
            {
                case 1:
                    escBGImg.GetComponent<SpriteRenderer>().sprite = escBGSpr[0];
                    break;
                case 2:
                    escBGImg.GetComponent<SpriteRenderer>().sprite = escBGSpr[1];
                    break;
                case 3:
                    escBGImg.GetComponent<SpriteRenderer>().sprite = escBGSpr[2];
                    break;
                case 4:
                    escBGImg.GetComponent<SpriteRenderer>().sprite = escBGSpr[3];
                    break;
                case 5:
                    escBGImg.GetComponent<SpriteRenderer>().sprite = escBGSpr[4];
                    break;
            }
        }
    }

    void Awake()
    {
        if (PlayerPrefs.GetInt("isFullscreenOn", 1) == 0)
        {
            Screen.SetResolution(1280, 720, FullScreenMode.Windowed);
            PlayerPrefs.SetInt("isFullscreenOn", 0);
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
            PlayerPrefs.SetInt("isFullscreenOn", 1);
        }
    }

    public void changeBtnLang()
    {
        int num = PlayerPrefs.GetInt("settingRealLanguageSave", 0) -1 ; // 언어 번호 저장
        switch (num)
        {
            case 0:
                for (int i = 0; i < menuBtn.Length && i < langKorSpr.Length; i++)
                {
                    menuBtn[i].image.sprite = langKorSpr[i];
                    backMenuBtn[i].image.sprite = langKorSpr2[i];
                    escBtn[i].image.sprite = langKorEsc[i];
                    startObj.GetComponent<SpriteRenderer>().sprite = langSpaceBar[num];
                }
                break;
            case 1:
                for (int i = 0; i < menuBtn.Length && i < langEngSpr.Length; i++)
                {
                    menuBtn[i].image.sprite = langEngSpr[i];
                    backMenuBtn[i].image.sprite = langEngSpr2[i];
                    escBtn[i].image.sprite = langEngEsc[i];
                    startObj.GetComponent<SpriteRenderer>().sprite = langSpaceBar[num];
                }
                break;
            case 2:
                for (int i = 0; i < menuBtn.Length && i < langJpSpr.Length; i++)
                {
                    menuBtn[i].image.sprite = langJpSpr[i];
                    backMenuBtn[i].image.sprite = langJpSpr2[i];
                    escBtn[i].image.sprite = langJpEsc[i];
                    startObj.GetComponent<SpriteRenderer>().sprite = langSpaceBar[num];
                }
                break;
            case 3:
                for (int i = 0; i < menuBtn.Length && i < langChSpr.Length; i++)
                {
                    menuBtn[i].image.sprite = langChSpr[i];
                    backMenuBtn[i].image.sprite = langChSpr2[i];
                    escBtn[i].image.sprite = langChEsc[i];
                    startObj.GetComponent<SpriteRenderer>().sprite = langSpaceBar[num];
                }
                break;
            case 4:
                for (int i = 0; i < menuBtn.Length && i < langRuSpr.Length; i++)
                {
                    menuBtn[i].image.sprite = langRuSpr[i];
                    backMenuBtn[i].image.sprite = langRuSpr2[i];
                    escBtn[i].image.sprite = langRuEsc[i];
                    startObj.GetComponent<SpriteRenderer>().sprite = langSpaceBar[num];
                }
                break;
        }
    }

    public void openOption()
    {
        optionImg.SetActive(true);
        titleImg.SetActive(false);
        bgStarImg1.GetComponent<SpriteRenderer>().sortingOrder = 17;
        bgStarImg2.GetComponent<SpriteRenderer>().sortingOrder = 17;
    }

    public void changeLanguageKOR()
    {
        PlayerPrefs.SetString("changeLanguage","KOR");
    }

    public void changeLanguageENG()
    {
        PlayerPrefs.SetString("changeLanguage", "ENG");
    }

    public void resolutionSetting()
    {
        int rWidth = 1920;
        int rHeight = 1080;

       // Screen.SetResolution(rWidth,rHeight,true);
    }

	IEnumerator keyboardEvt()
    {
        while (!menuImg.activeSelf)
		{
			if (Input.GetKey(KeyCode.Space))
            {
                GM.GetComponent<SoundEvt>().soundStart();
                menuImg.SetActive(true);
                startObj.SetActive(false);
                charImg.SetActive(false);
            }
			yield return new WaitForSeconds(0.1f);
		}
	}
    public void goBackMenu()
    {
        menuImg.SetActive(false);
        backMenuImg.SetActive(true);
    }
    public void goMainMenu()
    {
        menuImg.SetActive(true);
        backMenuImg.SetActive(false);
    }


    public void quitGame()
    {
        Application.Quit();
    }

    public void startGame()
    {
        GM.GetComponent<SoundEvt>().soundStart();
        SceneManager.LoadScene("01_Tutorial");
    }
}
