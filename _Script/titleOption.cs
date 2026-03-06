using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class titleOption : MonoBehaviour
{
    List<Dictionary<string, object>> optionLanguage; //csv파일
    public Text[] optionTxt;
    string text_str;

    public GameObject optionImg, titleImg, bgStarImg1, bgStarImg2;
    public Image btnMaster_img, btnBgm_img;
    public Image btnSfx_img, btnFullscreen_img, btnEffects_img, btnAutoRun_img, btnLanguage_img;
    
    public Slider masterSlider, bgmSlider, sfxSlider;
    public AudioSource masterAudioSource, bgmAudioSource, sfxAudioSource;
    private float masterVolume, bgmVolume, sfxVolume, valueBar1, valueBar2, valueBar3;


    int ckMaster, ckBgm, ckSfx, ckFullscreen, ckEffects, ckAutoRun, ckLanguage;
    public CameraFilterPack_Colors_Adjust_PreFilters Fliter1; // 인스펙터에 연결
    public CameraFilterPack_TV_ARCADE_Fast Fliter2; // 인스펙터에 연결

    [SerializeField] private Sprite EnableSprite, DisableSprite;

    public Button menuBtn;
    public Sprite[] sprite; // 인스펙터에서 설정할 스프라이트


    private void Awake()
    {
        optionLanguage = CSVReader.Read("CSV/optionTxt");

        text_str = PlayerPrefs.GetString("settingLanguage", "No1"); //기본 언어

        for (int i = 0; i < 9; i++)
        {
            optionTxt[i].text = optionLanguage[i][text_str].ToString();
        }
    }

    void Start()
    {
        masterVolume = PlayerPrefs.GetFloat("MasterVolume", 1.0f);
        bgmVolume = PlayerPrefs.GetFloat("BgmVolume", 1.0f);
        sfxVolume = PlayerPrefs.GetFloat("SfxVolume", 1.0f);

        masterSlider.value = masterVolume;
        bgmSlider.value = bgmVolume;
        sfxSlider.value = sfxVolume;

        masterAudioSource.volume = masterVolume;
        bgmAudioSource.volume = bgmVolume;
        sfxAudioSource.volume = sfxVolume;


        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        bgmSlider.onValueChanged.AddListener(SetBgmVolume);
        sfxSlider.onValueChanged.AddListener(SetSfxVolume);

        valueBar1 = PlayerPrefs.GetFloat("MasterVolume", masterSlider.value);
        valueBar2 = PlayerPrefs.GetFloat("BgmVolume", bgmSlider.value);
        valueBar3 = PlayerPrefs.GetFloat("SfxVolume", sfxSlider.value);

        // 기본값이 없는 경우에만 초기화 (기존 저장값을 덮어쓰지 않음)
        if (!PlayerPrefs.HasKey("isMasterOn")) PlayerPrefs.SetInt("isMasterOn", 0);
        if (!PlayerPrefs.HasKey("isBgmOn")) PlayerPrefs.SetInt("isBgmOn", 0);
        if (!PlayerPrefs.HasKey("isSfxOn")) PlayerPrefs.SetInt("isSfxOn", 0);
        if (!PlayerPrefs.HasKey("isFullscreenOn")) PlayerPrefs.SetInt("isFullscreenOn", 1);
        if (!PlayerPrefs.HasKey("isEffectsOn")) PlayerPrefs.SetInt("isEffectsOn", 1);
        if (!PlayerPrefs.HasKey("isAutoRunOn")) PlayerPrefs.SetInt("isAutoRunOn", 0);
        if (!PlayerPrefs.HasKey("isLanguageOn")) PlayerPrefs.SetInt("isLanguageOn", 0);

        // Master
        if (PlayerPrefs.GetInt("isMasterOn", 0) == 0)
        {
            if (btnMaster_img != null) btnMaster_img.sprite = DisableSprite;
            ckMaster = 0;
        }
        else
        {
            if (btnMaster_img != null) btnMaster_img.sprite = EnableSprite;
            masterAudioSource.volume = 0f;
            ckMaster = 1;
        }

        // BGM
        if (PlayerPrefs.GetInt("isBgmOn", 0) == 0)
        {
            if (btnBgm_img != null) btnBgm_img.sprite = DisableSprite;
            ckBgm = 0;
        }
        else
        {
            if (btnBgm_img != null) btnBgm_img.sprite = EnableSprite;
            bgmAudioSource.volume = 0f;
            ckBgm = 1;
        }

        // SFX
        if (PlayerPrefs.GetInt("isSfxOn", 0) == 0)
        {
            if (btnSfx_img != null) btnSfx_img.sprite = DisableSprite;
            ckSfx = 0;
        }
        else
        {
            if (btnSfx_img != null) btnSfx_img.sprite = EnableSprite;
            sfxAudioSource.volume = 0f;
            ckSfx = 1;
        }

        // Fullscreen
        if (PlayerPrefs.GetInt("isFullscreenOn", 0) == 0)
        {
            if (btnFullscreen_img != null) btnFullscreen_img.sprite = DisableSprite;
            ckFullscreen = 0;
        }
        else
        {
            if (btnFullscreen_img != null) btnFullscreen_img.sprite = EnableSprite;
            ckFullscreen = 1;
        }


        // Effects
        if (PlayerPrefs.GetInt("isEffectsOn", 0) == 0)
        {
            if (btnEffects_img != null) btnEffects_img.sprite = DisableSprite;
            ckEffects = 0;
            Fliter1.enabled = false;
            Fliter2.enabled = false;
        }
        else
        {
            if (btnEffects_img != null) btnEffects_img.sprite = EnableSprite;
            ckEffects = 1;
            Fliter1.enabled = true;
            Fliter2.enabled = true;
        }


        
        // AutoRun
        if (PlayerPrefs.GetInt("isAutoRunOn", 0) == 0)
        {
            if (btnAutoRun_img != null) btnAutoRun_img.sprite = DisableSprite;
            ckAutoRun = 0;
        }
        else
        {
            if (btnAutoRun_img != null) btnAutoRun_img.sprite = EnableSprite;
            ckAutoRun = 1;
        }

        // Language
        defaultLanguage();

    }

    public void defaultLanguage()
    {
        Image btnImage = menuBtn.GetComponent<Image>() ?? menuBtn.targetGraphic as Image;
        if (btnImage != null)
        {
            btnImage.sprite = sprite[PlayerPrefs.GetInt("settingRealLanguageSave",0)];
        }
    }

    public void SetMasterVolume(float value)
    {
        masterAudioSource.volume = value;
        valueBar1 = masterAudioSource.volume;

        // 슬라이더를 움직이면 자동으로 mute 해제
        if (value > 0.0001f)
        {
            Debug.Log("Master volume unmuted");
            if (btnMaster_img != null) btnMaster_img.sprite = DisableSprite;
            ckMaster = 0;
        }
    }

    public void SetBgmVolume(float value)
    {
        bgmAudioSource.volume = value;
        valueBar2 = bgmAudioSource.volume;
        if (value > 0.0001f)
        {
            Debug.Log("BGM volume unmuted");
            if (btnBgm_img != null) btnBgm_img.sprite = DisableSprite;
            ckBgm = 0;
        }
    }

    public void SetSfxVolume(float value)
    {
        sfxAudioSource.volume = value;
        valueBar3 = sfxAudioSource.volume;
        if (value > 0.0001f)
        {
            Debug.Log("SFX volume unmuted");
            if (btnSfx_img != null) btnSfx_img.sprite = DisableSprite;
            ckSfx = 0;
        }
    }
    public void saveOption()
    {
        PlayerPrefs.SetInt("isOptionSave", 1);
        optionImg.SetActive(false);
        titleImg.SetActive(true);
        bgStarImg1.GetComponent<SpriteRenderer>().sortingOrder = 11;
        bgStarImg2.GetComponent<SpriteRenderer>().sortingOrder = 11;

        PlayerPrefs.SetFloat("MasterVolume", masterSlider.value);
        PlayerPrefs.SetFloat("BgmVolume", bgmSlider.value);
        PlayerPrefs.SetFloat("SfxVolume", sfxSlider.value);

        // Master
        if (ckMaster == 0)
        {
            PlayerPrefs.SetInt("isMasterOn", 0);
        }
        else
        {
            PlayerPrefs.SetInt("isMasterOn", 1);
        }


        // bgm
        if (ckBgm == 0)
        {
            PlayerPrefs.SetInt("isBgmOn", 0);
        }
        else
        {
            PlayerPrefs.SetInt("isBgmOn", 1);
        }

        // sfx
        if (ckSfx == 0)
        {
            PlayerPrefs.SetInt("isSfxOn", 0);
        }
        else
        {
            PlayerPrefs.SetInt("isSfxOn", 1);
        }

        
        // fullscreen
        if (ckFullscreen == 0)
        {
            PlayerPrefs.SetInt("isFullscreenOn", 0);
              Screen.SetResolution(1280, 720, FullScreenMode.Windowed);
        }
        else
        {
            PlayerPrefs.SetInt("isFullscreenOn", 1);
              Screen.fullScreenMode = FullScreenMode.FullScreenWindow;

        }


        // effects
        if (ckEffects == 0)
        {
            PlayerPrefs.SetInt("isEffectsOn", 0);
        }
        else
        {
            PlayerPrefs.SetInt("isEffectsOn", 1);
        }

        if (ckAutoRun == 0)
        {
            PlayerPrefs.SetInt("isAutoRunOn", 0);
        }
        else
        {
            PlayerPrefs.SetInt("isAutoRunOn", 1);
        }

        //Language
        PlayerPrefs.SetString("settingLanguage", text_str);
        PlayerPrefs.SetInt("settingRealLanguageSave", PlayerPrefs.GetInt("settingLanguageNum", 0)); // 언어 번호 저장
        defaultLanguage();


        PlayerPrefs.Save();
        //Debug.Log("Options saved to PlayerPrefs");
    }

    public void setMasterVolume()
    {
        if (ckMaster == 0)
        {
            if (btnMaster_img != null) btnMaster_img.sprite = EnableSprite;
            ckMaster = 1;
           // masterSlider.value = 0f;
            masterAudioSource.volume = 0f;
        }
        else
        {
            if (btnMaster_img != null) btnMaster_img.sprite = DisableSprite;
            ckMaster = 0;
           // masterSlider.value = 1f;
            masterAudioSource.volume = valueBar1;
        }
    }

    public void setBGM()
    {
        if (ckBgm == 0)
        {            
            if (btnBgm_img != null) btnBgm_img.sprite = EnableSprite;
            ckBgm = 1;
            //bgmSlider.value = 0f;
            bgmAudioSource.volume = 0f;
        }
        else
        {            
            if (btnBgm_img != null) btnBgm_img.sprite = DisableSprite;
            ckBgm = 0;
           // bgmSlider.value = 1f;
            bgmAudioSource.volume = valueBar2;
        }
    }

    public void setSFX()
    {
        if (ckSfx == 0)
        {            
            if (btnSfx_img != null) btnSfx_img.sprite = EnableSprite;
            ckSfx = 1;
            //sfxSlider.value = 0f;
            sfxAudioSource.volume = 0f;
        }
        else
        {            
            if (btnSfx_img != null) btnSfx_img.sprite = DisableSprite;
            ckSfx = 0;
          //  sfxSlider.value = 1f;
            sfxAudioSource.volume = valueBar3;
        }
    }

    public void setFullscreen()
    {
        Debug.Log(ckFullscreen);
        if (ckFullscreen == 0)
        {
            if (btnFullscreen_img != null) btnFullscreen_img.sprite = EnableSprite;
            ckFullscreen = 1;
          //  Screen.fullScreenMode = FullScreenMode.FullScreenWindow;

        }
        else
        {
            ckFullscreen = 0;
            if (btnFullscreen_img != null) btnFullscreen_img.sprite = DisableSprite;
          //  Screen.SetResolution(1280, 720, FullScreenMode.Windowed);
        }
    }
    public void setEffects()
    {
        if (ckEffects == 0)
        {
            if (btnEffects_img != null) btnEffects_img.sprite = EnableSprite;
            ckEffects = 1;
            Fliter1.enabled = true;
            Fliter2.enabled = true;
        }
        else
        {
            if (btnEffects_img != null) btnEffects_img.sprite = DisableSprite;
            ckEffects = 0;
            Fliter1.enabled = false;
            Fliter2.enabled = false;
        }

    }

    public void setAutoRun()
    {
        if (ckAutoRun == 0)
        {
            if (btnAutoRun_img != null) btnAutoRun_img.sprite = EnableSprite;
            ckAutoRun = 1;
        }
        else
        {
            if (btnAutoRun_img != null) btnAutoRun_img.sprite = DisableSprite;
            ckAutoRun = 0;
        }
    }
    public void setLanguage()
    {
        int num = int.Parse(text_str.Substring(2)); // "No1" → 1
        num = num % 5 + 1;                          // 1~5 순환
        text_str = "No" + num;

        for (int i = 0; i < 9; i++)
        {
            optionTxt[i].text = optionLanguage[i][text_str].ToString();
        }
        PlayerPrefs.SetInt("settingLanguageNum", num); // 언어 번호 저장

        PlayerPrefs.SetInt("isOptionSave", 2);

        Image btnImage = menuBtn.GetComponent<Image>() ?? menuBtn.targetGraphic as Image;
        if (btnImage != null)
        {
            btnImage.sprite = sprite[num];
        }

    }
    public void setLanguage2()
    {
        int num = int.Parse(text_str.Substring(2)); // "No1" → 1

        num--;
        if (num < 1)
            num = 5;  // 1~5 순환

        text_str = $"No{num}";

        for (int i = 0; i < 9; i++)
        {
            optionTxt[i].text = optionLanguage[i][text_str].ToString();
        }

        PlayerPrefs.SetInt("isOptionSave", 2);
        PlayerPrefs.SetInt("settingLanguageNum", num); // 언어 번호 저장

        Image btnImage = menuBtn.GetComponent<Image>() ?? menuBtn.targetGraphic as Image;
        if (btnImage != null)
        {
            btnImage.sprite = sprite[num];
        }
    }

    public void deleteData()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("PlayerPrefs data deleted.");
    }

}
