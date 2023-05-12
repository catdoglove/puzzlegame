using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 필요

public class TitleEvt : MonoBehaviour
{

    /// <summary>
    /// 할일
    /// 1. 버튼 선택에 따른 언어 변경 기본값은 한글
    /// 2. 씬전환 아무키나 누르면 가능
    /// </summary>
    // Start is called before the first frame update
    void Start()
	{
		StartCoroutine("keyboardEvt");
	}

    public void changeLanguageKOR()
    {
        PlayerPrefs.SetString("changeLanguage","KOR");
    }

    public void changeLanguageENG()
    {
        PlayerPrefs.SetString("changeLanguage", "ENG");
    }

	IEnumerator keyboardEvt()
	{
		while (true)
		{
			if (Input.anyKey)
			{
                Debug.Log("씬전환");
                SceneManager.LoadScene("01_Tutorial");
            }
			yield return new WaitForSeconds(0.1f);
		}
	}
}
