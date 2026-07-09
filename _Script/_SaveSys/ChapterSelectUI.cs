using UnityEngine;

public class ChapterSelectUI : MonoBehaviour
{
    [SerializeField] private ChapterButton[] chapterButtons;

    void OnEnable()
    {
        RefreshChapterButtons();
    }

    public void RefreshChapterButtons()
    {
        // 안전장치: 인스펙터에 버튼이 안 들어가 있으면 에러를 띄워줍니다.
        if (chapterButtons == null || chapterButtons.Length == 0)
        {
            Debug.LogError("[경고] ChapterSelectUI에 버튼들이 하나도 연결되지 않았습니다! 유니티 인스펙터를 확인해주세요.");
            return;
        }

        ChapterSaveData saveData = SaveLoadManager.LoadGame();
        int maxUnlocked = saveData.maxUnlockedChapter;

        Debug.Log($"[UI 매니저] 현재 해금된 최대 챕터: {maxUnlocked}");

        foreach (ChapterButton btn in chapterButtons)
        {
            if (btn != null)
            {
                btn.SetState(btn.chapterNumber <= maxUnlocked);
            }
        }
    }
}


