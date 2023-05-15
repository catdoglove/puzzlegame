using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAdd : MonoBehaviour
{
    public static int dogamOpen_i;

    public GameObject main_obj;
    void Start()
    {
        PlayerPrefs.DeleteAll();
        LoadSceneAdditive();
    }

    private void Update()
    {
        if (SceneAdd.dogamOpen_i == 0)
        {
            ChangeMainScene();
        }
    }


    void LoadSceneAdditive()
    {
        SceneManager.LoadScene("dogam_sample", LoadSceneMode.Additive);
    }

    public void AtiveScene()
    {
        SceneAdd.dogamOpen_i = 1;
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("dogam_sample"));
        main_obj.SetActive(false);
    }

    public void ChangeMainScene()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("01_Tutorial"));
        main_obj.SetActive(true);
        SceneAdd.dogamOpen_i = 0;
    }
}
