using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveLoadManager
{
    // 현재 플레이어가 선택한 세이브 슬롯 번호 (기본값: 1)
    public static int currentSlot = 1;
    // 저장될 파일 이름 (확장자는 .json 또는 .dat 등 자유롭게 설정 가능)
    //private const string SAVE_FILENAME = "ChapterSaveData.json";

    // 플레이어가 방금 클릭한 챕터 번호를 임시로 기억하는 변수
    public static int selectedChapterToPlay = 1;

    public static bool isNewGame = false;

    // 실제 파일이 저장될 절대 경로를 반환
    private static string GetSavePath()
    {
        // Application.persistentDataPath는 윈도우, 모바일 등 OS에 상관없이 
        // 데이터가 삭제되지 않고 안전하게 보존되는 경로를 자동으로 잡아줍니다.
        // currentSlot이 1이면 ChapterSaveData_Slot1.json이 됩니다.
        //string fileName = $"ChapterSaveData_Slot{currentSlot}.json";
        //return Path.Combine(Application.persistentDataPath, fileName);
        return Path.Combine(Application.persistentDataPath, $"ChapterSaveData_Slot{currentSlot}.json");
    }

    /// <summary>
    /// 특정 슬롯의 파일이 실제로 존재치 않는지(비어있는지) 확인하는 함수
    /// </summary>
    public static bool DoesSlotExist(int slotNumber)
    {
        string path = Path.Combine(Application.persistentDataPath, $"ChapterSaveData_Slot{slotNumber}.json");
        return File.Exists(path);
    }

    /// <summary>
    /// 데이터를 JSON 파일로 저장합니다.
    /// </summary>
    public static void SaveGame(ChapterSaveData data)
    {
        data.lastPlayedDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        // 데이터를 JSON 문자열로 변환 (true를 넣으면 들여쓰기가 적용되어 사람이 읽기 편해짐)
        string json = JsonUtility.ToJson(data, true);

        string path = GetSavePath();

        // 텍스트 파일로 쓰기
        File.WriteAllText(path, json);
        Debug.Log($"[SaveManager] 게임이 저장되었습니다. 경로: {path}");
    }

    /// <summary>
    /// JSON 파일에서 데이터를 불러옵니다.
    /// </summary>
    public static ChapterSaveData LoadGame()
    {
        string path = GetSavePath();

        // 저장된 파일이 있는지 확인
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            // JSON 문자열을 다시 ChapterSaveData 객체로 변환
            ChapterSaveData loadedData = JsonUtility.FromJson<ChapterSaveData>(json);
            Debug.Log("[SaveManager] 게임 데이터를 성공적으로 불러왔습니다.");

            InventorySaveManager.LoadInventory(selectedChapterToPlay);
            return loadedData;
        }
        else
        {
            Debug.LogWarning("[SaveManager] 저장된 파일이 없습니다. 새로운 데이터를 생성합니다.");
            // 세이브 파일이 없으면 초기화된 새 객체를 반환
            return new ChapterSaveData();
        }
    }

    /// <summary>
    /// 저장된 데이터를 삭제할 때 사용합니다.
    /// </summary>
    public static void DeleteSaveFile()
    {
        string path = GetSavePath();
        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log("[SaveManager] 세이브 파일이 삭제되었습니다.");
        }
    }
}