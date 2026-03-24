using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 필요
using UnityEngine.UI;

public class TitleEvt : MonoBehaviour
{
    public GameObject GM,startObj, bgStarImg1, bgStarImg2, saveBtns, chapterBtns, titleTxt, cloudImg;
    public GameObject optionImg, optionBtn, titleImg, menuImg, backMenuImg, charImg;
    public GameObject resetWndImg, countBtn, ynBtn, yesBtn, noBtn;
    public Text resetCountTxt;

    public Button[] menuBtn, backMenuBtn;
    [SerializeField] private Sprite[] langSpaceBar, langKorSpr, langEngSpr, langJpSpr, langChSpr, langRuSpr;
    [SerializeField] private Sprite[] langKorSpr2, langEngSpr2, langJpSpr2, langChSpr2, langRuSpr2;


    public Image resetBG;
    [SerializeField] private Sprite[] resetBGSpr, resetBtnSprY, resetBtnSprN, resetCancelSpr;




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
                    startObj.GetComponent<SpriteRenderer>().sprite = langSpaceBar[num];
                    resetBG.GetComponent<Image>().sprite = resetBGSpr[num];
                    yesBtn.GetComponent<Image>().sprite = resetBtnSprY[num];
                    noBtn.GetComponent<Image>().sprite = resetBtnSprN[num];
                    countBtn.GetComponent<Image>().sprite = resetCancelSpr[num];
                }
                break;
            case 1:
                for (int i = 0; i < menuBtn.Length && i < langEngSpr.Length; i++)
                {
                    menuBtn[i].image.sprite = langEngSpr[i];
                    backMenuBtn[i].image.sprite = langEngSpr2[i];
                    startObj.GetComponent<SpriteRenderer>().sprite = langSpaceBar[num];
                    resetBG.GetComponent<Image>().sprite = resetBGSpr[num];
                    yesBtn.GetComponent<Image>().sprite = resetBtnSprY[num];
                    noBtn.GetComponent<Image>().sprite = resetBtnSprN[num];
                    countBtn.GetComponent<Image>().sprite = resetCancelSpr[num];
                }
                break;
            case 2:
                for (int i = 0; i < menuBtn.Length && i < langJpSpr.Length; i++)
                {
                    menuBtn[i].image.sprite = langJpSpr[i];
                    backMenuBtn[i].image.sprite = langJpSpr2[i];
                    startObj.GetComponent<SpriteRenderer>().sprite = langSpaceBar[num];
                    resetBG.GetComponent<Image>().sprite = resetBGSpr[num];
                    yesBtn.GetComponent<Image>().sprite = resetBtnSprY[num];
                    noBtn.GetComponent<Image>().sprite = resetBtnSprN[num];
                    countBtn.GetComponent<Image>().sprite = resetCancelSpr[num];
                }
                break;
            case 3:
                for (int i = 0; i < menuBtn.Length && i < langChSpr.Length; i++)
                {
                    menuBtn[i].image.sprite = langChSpr[i];
                    backMenuBtn[i].image.sprite = langChSpr2[i];
                    startObj.GetComponent<SpriteRenderer>().sprite = langSpaceBar[num];
                    resetBG.GetComponent<Image>().sprite = resetBGSpr[num];
                    yesBtn.GetComponent<Image>().sprite = resetBtnSprY[num];
                    noBtn.GetComponent<Image>().sprite = resetBtnSprN[num];
                    countBtn.GetComponent<Image>().sprite = resetCancelSpr[num];
                }
                break;
            case 4:
                for (int i = 0; i < menuBtn.Length && i < langRuSpr.Length; i++)
                {
                    menuBtn[i].image.sprite = langRuSpr[i];
                    backMenuBtn[i].image.sprite = langRuSpr2[i];
                    startObj.GetComponent<SpriteRenderer>().sprite = langSpaceBar[num];
                    resetBG.GetComponent<Image>().sprite = resetBGSpr[num];
                    yesBtn.GetComponent<Image>().sprite = resetBtnSprY[num];
                    noBtn.GetComponent<Image>().sprite = resetBtnSprN[num];
                    countBtn.GetComponent<Image>().sprite = resetCancelSpr[num];
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

    public void selectSaveSlot()
    {
        saveBtns.SetActive(true);
        menuImg.SetActive(false);
        titleTxt.SetActive(false);
        cloudImg.SetActive(false);
    }
    public void backMainMenu()
    {
        saveBtns.SetActive(false);
        menuImg.SetActive(true);
        titleTxt.SetActive(true);
        cloudImg.SetActive(true);
    }
    public void selectChapter()
    {
        chapterBtns.SetActive(true);
        saveBtns.SetActive(false);
    }
    public void backMainMenu2()
    {
        chapterBtns.SetActive(false);
        saveBtns.SetActive(true);
    }

    public void showCredits()
    {
        Debug.Log("크레딧 보여주기");
    }
    public void showResetWnd()
    {
        resetWndImg.SetActive(true);
        countBtn.SetActive(false);
        ynBtn.SetActive(true);
    }

    public void hideResetWnd()
    {
        resetWndImg.SetActive(false);
        StopCoroutine("CountdownCoroutine");
    }

    public void countReset()
    {
        StartCoroutine("CountdownCoroutine");
        countBtn.SetActive(true);
        ynBtn.SetActive(false);
    }


    IEnumerator CountdownCoroutine()
    {
        for (int i = 5; i > 0; i--)
        {
            resetCountTxt.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        Debug.Log("데이터삭제완료");
        hideResetWnd();
    }
}
