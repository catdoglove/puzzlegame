using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class AlphaButtonBlocker : MonoBehaviour
{
    void Awake()
    {
        Image img = GetComponent<Image>();
        img.alphaHitTestMinimumThreshold = 0.5f;
        // 알파가 0.1 이상인 부분만 클릭됨 (0~1)
    }
}
