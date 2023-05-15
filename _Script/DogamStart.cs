using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DogamStart : MonoBehaviour
{
    public GameObject GM;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine("UpdateSec");

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            GM.SetActive(false);
            SceneAdd.dogamOpen_i = 0;
        }
    }



    IEnumerator UpdateSec()
    {
        int ti=1;
        while (ti == 1)
        {
            
            if (SceneAdd.dogamOpen_i == 1)
            {
                GM.SetActive(true);
            }
            else
            {
                if (GM.activeSelf)
                {
                    GM.SetActive(false);
                }
            }


            yield return new WaitForSeconds(0.02f);
        }
    }
}
