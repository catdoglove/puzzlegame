using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTurnOffOther : MonoBehaviour
{
    public GameObject targetToTurnOff; // 인스펙터에서 끌 오브젝트를 연결하세요

    // 이 스크립트가 붙은 오브젝트가 활성화(SetActive true)될 때 실행됨
    private void OnEnable()
    {
            targetToTurnOff.SetActive(false);
    }
}
