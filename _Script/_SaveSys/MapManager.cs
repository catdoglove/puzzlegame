using UnityEngine;

public class MapManager : MonoBehaviour
{
    // 씬에 있는 8개의 맵 묶음(부모 오브젝트)들을 연결할 배열
    [SerializeField] private GameObject[] chapterMaps;

    public GameObject[] map;
    public GameObject[] gm;

    void Start()
    {
        if (SaveLoadManager.isNewGame)
        {
            return; 
        }


        // 타이틀 씬에서 넘어올 때 저장해둔 번호를 꺼내옵니다.
        int currentChapter = SaveLoadManager.selectedChapterToPlay;

        int targetIndex = currentChapter;


        if (targetIndex < 0 || targetIndex >= chapterMaps.Length)
        {
            Debug.LogError($"[MapManager] {currentChapter} 챕터 맵이 배열에 없습니다! 인스펙터를 확인하세요.");
            return;
        }
        chapterMaps[4].SetActive(false);

        for (int i = 0; i < chapterMaps.Length; i++)
        {
            if (i == targetIndex)
            {
                Debug.Log(i);
                chapterMaps[i].SetActive(true);
            }

        }

        if (currentChapter == 6)
        {
            map[3].SetActive(false);
            map[4].SetActive(true);
            map[5].SetActive(true);
            Invoke("tsr", 0.1f);
        }
        gm[0].SetActive(false);

        Debug.Log($"[MapManager] 성공! 챕터 {currentChapter} 맵이 세팅되었습니다.");
    }

    void tsr()
    {

        map[5].SetActive(true);
    }
}