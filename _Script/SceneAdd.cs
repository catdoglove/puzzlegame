﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAdd2 : MonoBehaviour
{
    public static int dogamOpen_i;

    public GameObject main_obj;
    void Start()
    {
        LoadSceneAdditive();
        StartCoroutine("dogamOpenTab");
    }

    private void Update()
    {
    }

    IEnumerator dogamOpenTab()
    {
        while (true)
        {
            if (SceneAdd.dogamOpen_i == 0)
            {
                ChangeMainScene();
                yield return new WaitForSeconds(0.1f);
            }
            else if (SceneAdd.dogamOpen_i == 1)
            {
                AtiveScene();
                yield return new WaitForSeconds(0.1f);
            }
        }
    }


    void LoadSceneAdditive()
    {
        SceneManager.LoadScene("dogam_sample", LoadSceneMode.Additive);
    }

    public void AtiveScene()
    {
        SceneAdd.dogamOpen_i = 1;
        Invoke("aboutTabEvt", 1f);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("dogam_sample"));
        main_obj.SetActive(false);
        Cursor.visible = true;
    }

    public void ChangeMainScene()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("02_game"));
        main_obj.SetActive(true);
        SceneAdd.dogamOpen_i = 0;
    }

    void aboutTabEvt()
    {
        PlayerPrefs.SetInt("dogamisopen",1);
    }
}
