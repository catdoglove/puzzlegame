using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct SlotUISetting
{
    public Text slotText;       // 이 슬롯의 텍스트
    public Image slotImage;     // 이 슬롯의 이미지 컴포넌트
    public Sprite normalSprite; // 이 슬롯만의 전용 '정상' 이미지
    public Sprite emptySprite;  // 이 슬롯만의 전용 '비어있음' 이미지
}

public class SlotSelectUI : MonoBehaviour
{
    [Header("UI Panels")]
    [SerializeField] private GameObject slotSelectPanel;    // 슬롯 선택 창
    [SerializeField] private GameObject chapterSelectPanel; // 챕터 선택 창 

    [SerializeField] private ChapterSelectUI chapterManager;

    [Header("Slot Settings")]
    // 위에서 만든 구조체를 배열로 받습니다.
    [SerializeField] private SlotUISetting[] slotSettings;


    void OnEnable()
    {
        // 슬롯 창이 켜질 때마다 파일들을 체크해서 글자를 업데이트합니다.
        RefreshSlotUIs();
    }

    /// <summary>
    /// 파일 존재 여부에 따라 각 슬롯의 텍스트와 이미지를 모두 갱신합니다.
    /// </summary>
    public void RefreshSlotUIs()
    {
        for (int i = 0; i < slotSettings.Length; i++)
        {
            int slotNum = i + 1;

            // 현재 순번의 슬롯 세팅 정보를 가져옵니다.
            SlotUISetting currentSlot = slotSettings[i];

            if (SaveLoadManager.DoesSlotExist(slotNum))
            {
                // [데이터가 있을 때]
                int backup = SaveLoadManager.currentSlot;
                SaveLoadManager.currentSlot = slotNum;
                ChapterSaveData data = SaveLoadManager.LoadGame();
                SaveLoadManager.currentSlot = backup;

                currentSlot.slotText.text = $"ch{data.maxUnlockedChapter}";
                // 이 슬롯 전용 정상 이미지로 교체
                currentSlot.slotImage.sprite = currentSlot.normalSprite;
            }
            else
            {
                // [데이터가 없을 때]
                currentSlot.slotText.text = "ch0";
                // 이 슬롯 전용 빈 이미지로 교체
                currentSlot.slotImage.sprite = currentSlot.emptySprite;
            }
        }
    }

    /// <summary>
    /// 슬롯 버튼을 눌렀을 때 호출되는 함수
    /// </summary>
    public void SelectSlot(int slotNumber)
    {
        // 1. 매니저의 현재 슬롯 지정
        SaveLoadManager.currentSlot = slotNumber;

        // 2. ★ 파일 생성 핵심 로직
        if (!SaveLoadManager.DoesSlotExist(slotNumber))
        {
            // [새 게임 처리]
            ChapterSaveData newGameData = new ChapterSaveData();
            SaveLoadManager.SaveGame(newGameData);
            Debug.Log($"[슬롯 시스템] {slotNumber}번 세이브 파일이 새로 생성되었습니다. (New Game)");

            SaveLoadManager.isNewGame = true;

            // 1. 새 게임이므로 1챕터 맵을 켜주도록 매니저에게 알림
            SaveLoadManager.selectedChapterToPlay = 0;

            // 2. 챕터 선택 창을 건너뛰고 곧바로 게임 씬
                SceneManager.LoadScene("01_Tutorial");
        }
        else
        {
            SaveLoadManager.isNewGame = false;
            Debug.Log($"[슬롯 시스템] {slotNumber}번 기존 세이브 파일을 이어합니다. (Continue)");

            slotSelectPanel.SetActive(false);
            chapterSelectPanel.SetActive(true);

            chapterManager.RefreshChapterButtons();
        }

    }
}