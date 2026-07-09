using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class ChapterButton : MonoBehaviour
{
    [Header("Sprites")]
    public Sprite unlockedSprite;
    public Sprite lockedSprite;

    [Header("Settings")]
    public int chapterNumber;

    private Button button;
    private Image buttonImage;

    public void SetState(bool isUnlocked)
    {
        // 타이밍 이슈 방지: 호출될 때 컴포넌트가 비어있으면 확실하게 가져옵니다.
        if (button == null) button = GetComponent<Button>();
        if (buttonImage == null) buttonImage = GetComponent<Image>();

        if (isUnlocked)
        {
            button.interactable = true;
            buttonImage.sprite = unlockedSprite;
            // 정상 작동 확인용 로그
            Debug.Log($"[버튼 갱신] 챕터 {chapterNumber} - 해금됨 (원본 이미지)");
        }
        else
        {
            button.interactable = false;
            buttonImage.sprite = lockedSprite;
            // 정상 작동 확인용 로그
            Debug.Log($"[버튼 갱신] 챕터 {chapterNumber} - 잠김 (자물쇠 이미지)");
        }
    }
}