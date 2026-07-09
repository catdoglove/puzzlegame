using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    /// <summary>
    /// 챕터 버튼을 누를 때 호출할 함수
    /// </summary>
    public void GoToGameScene(int chapterNumber)
    {
        //선택한 챕터 번호
        SaveLoadManager.selectedChapterToPlay = chapterNumber;

        Debug.Log($"[씬 전환] {chapterNumber} 챕터로 이동합니다...");

        if (chapterNumber<4)
        {
            SceneManager.LoadScene("01_Tutorial");
        }
        else
        {
            SceneManager.LoadScene("02_game");
        }
    }
}