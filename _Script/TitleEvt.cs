using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 필요

public class TitleEvt : MonoBehaviour
{
    public GameObject GM,startObj;
   

    // Start is called before the first frame update
    void Start()
	{
        PlayerPrefs.DeleteAll();

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

    public void resolutionSetting()
    {
        int rWidth = 1920;
        int rHeight = 1080;

        Screen.SetResolution(rWidth,rHeight,true);
    }

	IEnumerator keyboardEvt()
    {
        while (true)
		{
			if (Input.GetKey(KeyCode.Space))
            {
                GM.GetComponent<SoundEvt>().soundStart();
                Debug.Log("씬전환");
                startObj.SetActive(false);
                yield return new WaitForSeconds(0.2f);
                startObj.SetActive(true);
                yield return new WaitForSeconds(0.2f);
                startObj.SetActive(false);
                yield return new WaitForSeconds(0.2f);
                startObj.SetActive(true);
                yield return new WaitForSeconds(0.2f);
                startObj.SetActive(false);
                yield return new WaitForSeconds(0.2f);
                startObj.SetActive(true);
                yield return new WaitForSeconds(0.2f);
                SceneManager.LoadScene("01_Tutorial");
            }
			yield return new WaitForSeconds(0.1f);
		}
	}
}
