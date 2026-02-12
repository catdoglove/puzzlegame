using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    // 인스펙터 창에서 바꿀 이미지를 넣을 변수
    public Sprite newSprite;

    // 오브젝트의 스프라이트 렌더러 컴포넌트를 담을 변수
    private SpriteRenderer spriteRenderer;

    private bool isChanged = false;

    void Start()
    {
        // 게임 시작 시, 이 오브젝트에 붙어있는 SpriteRenderer 컴포넌트를 가져옴
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // 스페이스바를 눌렀을 때 (GetKeyDown은 누르는 순간 한 번만 실행됨)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeImage();

        }
    }

    void ChangeImage()
    {

        if (isChanged == false)
        {

            // 이미지가 할당되어 있고, 렌더러가 있다면 이미지 교체
            if (newSprite != null && spriteRenderer != null)
            {
                spriteRenderer.sprite = newSprite;
                isChanged = true; // "이제 이미지가 바뀌었다"고 상태 변경
            }
        }
        else
        {
            // 2단계: 이미 바뀐 상태라면 -> 오브젝트를 끈다
            gameObject.SetActive(false);
        }
    }
}
