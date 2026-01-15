using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class AlphaButtonBlocker : MonoBehaviour
{
    [Header("설정")]
    [Range(0.01f, 1f)]
    [SerializeField] private float alphaThreshold = 0.1f;

    void Awake()
    {
        // 1. Image 컴포넌트를 가져옵니다.
        Image image = GetComponent<Image>();

        if (image != null)
        {
            // 2. 클릭이 감지될 최소 알파값을 설정합니다.
            // 0.1f로 설정하면 알파값이 0.1(10%) 이상인 부분만 클릭됩니다.
            image.alphaHitTestMinimumThreshold = alphaThreshold;
        }
    }
}
