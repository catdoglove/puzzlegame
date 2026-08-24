using UnityEngine;
using System.IO;

// 1. JSON 파일로 변환하기 위한 데이터 껍데기
[System.Serializable]
public class SettingsData
{
    // 기존 데이터
    public float masterVolume;
    public float sfxVolume;
    public float bgmVolume;
    public int effects;
    public int autoRun;
    public int language;

    // ★ 추가된 데이터
    public int fullScreen;    // 전체 화면 (예: 1=전체화면, 0=창모드)
    public int masterMute;    // 마스터 음소거 (예: 1=음소거, 0=소리남)
    public int sfxMute;       // 효과음 음소거
    public int bgmMute;       // 배경음 음소거
    public string customText; // SetString으로 저장되는 텍스트 데이터



}

public static class SettingsSyncManager
{
    private const string FILE_NAME = "GameSettings.json";

    // 🚨 [매우 중요] 현재 프로젝트에서 실제로 사용 중인 PlayerPrefs 키값을 적어주세요.
    private const string KEY_MASTER = "MasterVolume";
    private const string KEY_SFX = "SfxVolume";
    private const string KEY_BGM = "BgmVolume";
    private const string KEY_EFFECT = "isEffectsOn";
    private const string KEY_RUN = "isAutoRunOn";
    private const string KEY_LANG = "settingRealLanguageSave";

    // ★ 추가된 키값들 (실제 사용 중인 키로 변경하세요)
    private const string KEY_FULLSCREEN = "isFullscreenOn";
    private const string KEY_MUTE_MASTER = "isMasterOn";
    private const string KEY_MUTE_SFX = "isSfxOn";
    private const string KEY_MUTE_BGM = "isBgmOn";
    private const string KEY_TEXT_DATA = "settingLanguage";




    private static string GetFilePath()
    {
        return Path.Combine(Application.persistentDataPath, FILE_NAME);
    }

    /// <summary>
    /// PlayerPrefs의 값들을 JSON 파일로 추출합니다.
    /// </summary>
    public static void ExportPrefsToFile()
    {
        SettingsData data = new SettingsData();

        // 기존 값들 가져오기
        data.masterVolume = PlayerPrefs.GetFloat(KEY_MASTER, 1f);
        data.sfxVolume = PlayerPrefs.GetFloat(KEY_SFX, 1f);
        data.bgmVolume = PlayerPrefs.GetFloat(KEY_BGM, 1f);
        data.effects = PlayerPrefs.GetInt(KEY_EFFECT, 1);
        data.autoRun = PlayerPrefs.GetInt(KEY_RUN, 0);
        data.language = PlayerPrefs.GetInt(KEY_LANG, 0);

        // ★ 추가된 값들 가져오기 (기본값을 0 또는 빈 문자열 "" 로 세팅)
        data.fullScreen = PlayerPrefs.GetInt(KEY_FULLSCREEN, 1);
        data.masterMute = PlayerPrefs.GetInt(KEY_MUTE_MASTER, 0);
        data.sfxMute = PlayerPrefs.GetInt(KEY_MUTE_SFX, 0);
        data.bgmMute = PlayerPrefs.GetInt(KEY_MUTE_BGM, 0);





        // 주의: 텍스트는 GetInt가 아니라 GetString을 사용합니다.
        data.customText = PlayerPrefs.GetString(KEY_TEXT_DATA, "No1");

        // JSON 파일로 기록
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(GetFilePath(), json);

        Debug.Log($"[SettingsSync] PlayerPrefs -> 파일로 추출 완료: {FILE_NAME}");
    }

    /// <summary>
    /// JSON 파일의 값들을 PlayerPrefs에 덮어씌웁니다.
    /// </summary>
    public static void ImportFileToPrefs()
    {
        string path = GetFilePath();

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SettingsData data = JsonUtility.FromJson<SettingsData>(json);

            // 기존 값들 PlayerPrefs에 꽂기
            PlayerPrefs.SetFloat(KEY_MASTER, data.masterVolume);
            PlayerPrefs.SetFloat(KEY_SFX, data.sfxVolume);
            PlayerPrefs.SetFloat(KEY_BGM, data.bgmVolume);
            PlayerPrefs.SetInt(KEY_EFFECT, data.effects);
            PlayerPrefs.SetInt(KEY_RUN, data.autoRun);
            PlayerPrefs.SetInt(KEY_LANG, data.language);

            // ★ 추가된 값들 PlayerPrefs에 꽂기
            PlayerPrefs.SetInt(KEY_FULLSCREEN, data.fullScreen);
            PlayerPrefs.SetInt(KEY_MUTE_MASTER, data.masterMute);
            PlayerPrefs.SetInt(KEY_MUTE_SFX, data.sfxMute);
            PlayerPrefs.SetInt(KEY_MUTE_BGM, data.bgmMute);



            // 주의: 텍스트는 SetInt가 아니라 SetString을 사용합니다.
            PlayerPrefs.SetString(KEY_TEXT_DATA, data.customText);

            // 저장소에 강제 기록
            PlayerPrefs.Save();

            Debug.Log("[SettingsSync] 파일 -> PlayerPrefs 덮어쓰기 완료.");
        }
        else
        {
            Debug.LogWarning("[SettingsSync] 설정 파일이 없어 PlayerPrefs 기존 값을 유지합니다.");
        }
    }
}