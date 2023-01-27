using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject invenItem_obj;
    public Sprite[] Item_spr;
    public int a = 0;

    public GameObject itemWindow_obj, itemWindowEnd_obj, itemWindowStart_obj;
    Vector3 position;
    public int in_i=0;
    public int inout_i = 0;

    public GameObject GM;
    public GameObject think_obj;
    public Sprite[] think_spr;

    // Start is called before the first frame update
    void Start()
    {

        PlayerPrefs.SetInt("inventorynum", 0);
        PlayerPrefs.SetInt("inventoryget0", 0);
        PlayerPrefs.SetInt("item0", 0);
        PlayerPrefs.SetInt("inventoryget1", 0);
        PlayerPrefs.SetInt("item1", 0);

        position = itemWindow_obj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (in_i==0)
            {
                if (inout_i==0)
                {
                    in_i = 1;
                    StopCoroutine("ShowWindow");
                    StopCoroutine("Show");
                    StartCoroutine("ShowWindow");
                    StartCoroutine("Show");
                    GM.GetComponent<MoveCharacter>().canMove = false;
                }
                else
                {
                    in_i = 1;
                    StopCoroutine("ShowWindow");
                    StopCoroutine("CloseWindow");
                    StartCoroutine("CloseWindow");
                    GM.GetComponent<MoveCharacter>().canMove = true;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (in_i == 0)
            {
                if (inout_i == 0)
                {
                    in_i = 1;
                    StopCoroutine("ShowWindow");
                    StopCoroutine("Show");
                    StartCoroutine("ShowWindow");
                    StartCoroutine("Show");
                    GM.GetComponent<MoveCharacter>().canMove = false;
                }
                else
                {
                    in_i = 1;
                    StopCoroutine("ShowWindow");
                    StopCoroutine("CloseWindow");
                    StartCoroutine("CloseWindow");
                    GM.GetComponent<MoveCharacter>().canMove = true;
                }
            }
        }

        if (PlayerPrefs.GetInt("inventorynum", 0) == a)
        {

        }
        else
        {
            if (PlayerPrefs.GetInt("inventoryget0", 0) == 0)
            {
                invenItem_obj.SetActive(false);
                if (invenItem_obj.GetComponent<Image>().sprite != null)
                {
                    invenItem_obj.GetComponent<Image>().sprite = null;
                }
            }
            else
            {
                invenItem_obj.SetActive(true);
                if (invenItem_obj.GetComponent<Image>().sprite == null)
                {
                    invenItem_obj.GetComponent<Image>().sprite = Item_spr[PlayerPrefs.GetInt("inventoryget0", 0)];
                }
                if (PlayerPrefs.GetInt("inventoryget1", 0) == 0)
                {

                }
                else
                {

                }
            }

            a = PlayerPrefs.GetInt("inventorynum", 0);
        }
    }


    /// <summary>
    /// 아래로 내려오기
    /// </summary>
    /// <returns></returns>
    IEnumerator ShowWindow()
    {
        while (in_i == 1)
        {
            position.y = position.y - 5f * Time.deltaTime;
            itemWindow_obj.transform.position = position;
            if (position.y <= itemWindowEnd_obj.transform.position.y)
            {
                in_i = 0;
                inout_i = 1;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    /// <summary>
    /// 위로 올라가기
    /// </summary>
    /// <returns></returns>
    IEnumerator CloseWindow()
    {
        think_obj.SetActive(false);
        while (in_i == 1)
        {
            position.y = position.y + 5f * Time.deltaTime;
            itemWindow_obj.transform.position = position;
            if (position.y >= itemWindowStart_obj.transform.position.y)
            {
                in_i = 0;
                inout_i = 0;
            }
            yield return new WaitForSeconds(0.01f);
        }

    }


    IEnumerator Show()
    {
        int k=0;
        think_obj.SetActive(true);

        while (k <= 2)
        {
            if (k<=2)
            {
                think_obj.GetComponent<SpriteRenderer>().sprite = think_spr[k];
                k++;
            }

            yield return new WaitForSeconds(0.2f);
        }
    }
}
