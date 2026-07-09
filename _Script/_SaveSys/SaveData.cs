using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChapterSaveData
{
    public int maxUnlockedChapter=0; // 플레이어가 진입할 수 있는 최대 챕터 (기본값: 1)
    public int currentChapter;
    public string lastPlayedDate;
    public List<string> unlockedItems;

    // 기본 생성자 (새 게임을 시작할 때 초기값)
    public ChapterSaveData()
    {
        maxUnlockedChapter = 0; // 처음에는 1챕터만 해금
        currentChapter = 0;
        lastPlayedDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        unlockedItems = new List<string>();
    }
}
