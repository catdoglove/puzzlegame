using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public ChapterSaveData currentSaveData;

    [Header("In-Game Status")]
    public int activeChapter;

    void Start()
    {
        // 게임 시작 시 데이터 불러오기
        LoadCurrentGame();
    }

    // 데이터 불러오기
    public void LoadCurrentGame()
    {
        currentSaveData = SaveLoadManager.LoadGame();
        Debug.Log($"현재 챕터: {currentSaveData.currentChapter}");

        if (SaveLoadManager.isNewGame)
        {
            activeChapter = 0; // 빈 슬롯을 누른 새 게임이면 무조건 1챕터부터 시작
        }
        else
        {
            activeChapter = SaveLoadManager.selectedChapterToPlay; // 챕터 선택으로 들어왔으면 고른 챕터 시작
        }

        Debug.Log($"[GameController] 인게임 세팅 완료! 현재 플레이 중인 챕터는 {activeChapter}입니다.");
    }

    // 챕터를 클리어하고 다음 챕터로 넘어갈 때
    public void CompleteChapter(int targetChapterToUnlock)
    {
        // 안전장치: 존재하지 않는 챕터 번호 범위는 걸러냅니다.
        if (targetChapterToUnlock < 0 || targetChapterToUnlock > 8)
        {
            Debug.LogError($"[해금 실패] {targetChapterToUnlock}번 챕터는 존재하지 않습니다. (0~8만 가능)");
            return;
        }

        // 1. 최신 세이브 데이터를 다시 로드합니다.
        currentSaveData = SaveLoadManager.LoadGame();

        // 2. 이미 더 높은 챕터가 열려있는 상태에서 과거의 낮은 챕터를 다시 열려고 하는 것이 아니라면 갱신합니다.
        if (targetChapterToUnlock > currentSaveData.maxUnlockedChapter)
        {
            // [핵심 변경점] 자동 증가가 아니라, 내가 넣은 숫자값으로 직접 꽂아버립니다.
            currentSaveData.maxUnlockedChapter = targetChapterToUnlock;

            // 3. 파일에 영구 저장
            SaveLoadManager.SaveGame(currentSaveData);

            Debug.Log($"[세이브 갱신] 성공! 이제 챕터 {targetChapterToUnlock} 까지 진입할 수 있습니다.");
        }
        else
        {
            Debug.Log($"[세이브 유지] 이미 챕터 {currentSaveData.maxUnlockedChapter}까지 열려있으므로, {targetChapterToUnlock}번 해금 요청은 무시합니다.");
        }
    }

    /// <summary>
    /// 현재 챕터를 클리어했을 때 호출하는 함수
    /// </summary>
    /// <param name="clearedChapter">방금 클리어한 챕터 번호</param>
    public void OnChapterClear(int clearedChapter)
    {
        Debug.Log($"[비교] 방금 깬 챕터({clearedChapter}) vs 파일의 최대 해금 챕터({currentSaveData.maxUnlockedChapter})");

        // 방금 깬 챕터가 내 세이브의 최고 기록과 같고, 마지막 8챕터가 아니라면 다음 문을 열어줍니다.
        if (clearedChapter == currentSaveData.maxUnlockedChapter && currentSaveData.maxUnlockedChapter < 10)
        {
            currentSaveData.maxUnlockedChapter++;

            // 현재 슬롯 파일에 실시간 덮어쓰기 저장
            SaveLoadManager.SaveGame(currentSaveData);

            Debug.Log($"[세이브 갱신] 챕터 {clearedChapter} 클리어 성공! 다음 챕터 {currentSaveData.maxUnlockedChapter} 해금 완료.");
        }
        else
        {
            Debug.Log("[세이브 유지] 이미 깼던 챕터를 다시 깼거나 마지막 챕터이므로 최고 진행도를 유지합니다.");
        }

        // 1. 기존 데이터 불러오기
        //ChapterSaveData data = SaveLoadManager.LoadGame();

        /*
        // 2. 만약 방금 깬 챕터가 현재 열려있는 가장 높은 챕터이고, 마지막 10챕터가 아니라면
        if (clearedChapter == data.maxUnlockedChapter && data.maxUnlockedChapter < 10)
        {
            // 다음 챕터 해금!
            data.maxUnlockedChapter++;

            // 3. 변경된 정보를 파일로 저장
            SaveLoadManager.SaveGame(data);
            Debug.Log($"[GameManager] 챕터 {clearedChapter} 클리어! 다음 챕터 {data.maxUnlockedChapter}가 해금되었습니다.");
        }
        else
        {
            Debug.Log("[GameManager] 이미 해금된 챕터이거나 마지막 챕터이므로 최대 해금 번호를 유지합니다.");
        }
        */
    }

    // 데이터 불러오기
    public void DeleteSaveGame()
    {
        SaveLoadManager.DeleteSaveFile();
    }
}
