using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CheckCh : MonoBehaviour
{

    public int i = 0;
    public GameObject GameObject;


    void Start()
    {
        if (PlayerPrefs.GetInt("nextchsave", 0) == 1)
        {

            InventorySaveManager.SaveInventory(i);
        }

        GameObject.GetComponent<GameController>().CompleteChapter(i);

        PlayerPrefs.SetInt("nextchsave", 1);

    }


}
