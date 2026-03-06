using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InfiniteBackground1 : MonoBehaviour
{
    public Transform[] backgrounds;   // 배경 2개
    public float scrollSpeed = 2f;    // 스크롤 속도

    private float backgroundHeight;

    void Start()
    {
        // 스프라이트 가로 길이 자동 계산
        backgroundHeight = backgrounds[0].GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        // 배경 이동
        foreach (Transform bg in backgrounds)
        {
            bg.position += Vector3.down * scrollSpeed * Time.deltaTime;
        }

        // 화면 밖으로 나간 배경을 오른쪽 끝으로 이동
        foreach (Transform bg in backgrounds)
        {
            if (bg.position.y < Camera.main.transform.position.y - backgroundHeight)
            {
                bg.position += Vector3.up * backgroundHeight * backgrounds.Length;
            }
        }
    }
}
