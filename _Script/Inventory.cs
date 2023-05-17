using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject[] invenItem_obj;
    public Sprite[] Item_spr;

    /// <summary>
    /// 인벤토리번호
    /// </summary>
    public int a = 0;

    public GameObject itemWindow_obj, itemWindowEnd_obj, itemWindowStart_obj;
    Vector3 position;
    public int in_i=0;
    public int inout_i = 0;

    public GameObject GM, MainGM;
    public GameObject think_obj;
    public Sprite[] think_spr;

    public GameObject selected_obj;
    public GameObject[] selectBox_obj;
    public Sprite _spr;
    public int selected_i = 0;
    public int selectedNow_i = -1;

    public int[] items_i;

    public GameObject selectWin_obj;


    public GameObject SGM;

    public static bool itemGetting_b;


    public GameObject ESCevent;


    // Start is called before the first frame update
    void Start()
    {
        position = itemWindow_obj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Escape))
        {
            showESCwindow();
        }
        /*
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
                    GM.GetComponent<CharMove>().canMove = false;
                }
                else
                {
                    in_i = 1;
                    StopCoroutine("ShowWindow");
                    StopCoroutine("CloseWindow");
                    StartCoroutine("CloseWindow");
                    GM.GetComponent<CharMove>().canMove = true;
                }
            }
        }
        */


        if (Input.GetKeyDown(KeyCode.Tab))
        {
            MainGM.GetComponent<SceneAdd>().AtiveScene();
        }


        if (Input.GetKeyDown(KeyCode.E))
        {

            if (itemGetting_b == false)
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
                        GM.GetComponent<CharMove>().canMove = false;
                        GM.GetComponent<CharMove>().charAni.Play("ani_char_stop");
                        GM.GetComponent<CharMove>().ckwalk = 0;
                    }
                    else
                    {
                        in_i = 1;
                        StopCoroutine("ShowWindow");
                        StopCoroutine("CloseWindow");
                        StartCoroutine("CloseWindow");
                        GM.GetComponent<CharMove>().canMove = true;
                    }
                }


                if (PlayerPrefs.GetInt("setselectone", 0) == 0)
                {
                    selectWin_obj.SetActive(true);
                    PlayerPrefs.SetInt("setselectone", 1);
                }

            }
        }
        
        if (PlayerPrefs.GetInt("changeitem", 0) == 0)
        {

        }
        else
        {
            if (PlayerPrefs.GetInt("inventoryget0", 0) == 0)
            {
                invenItem_obj[0].SetActive(false);
                if (invenItem_obj[0].GetComponent<Image>().sprite != null)
                {
                    invenItem_obj[0].GetComponent<Image>().sprite = null;
                }
            }
            else
            {

                SetItem(0);
                if (PlayerPrefs.GetInt("inventoryget1", 0) == 0)
                {
                    invenItem_obj[1].SetActive(false);
                    if (invenItem_obj[1].GetComponent<Image>().sprite != null)
                    {
                        invenItem_obj[1].GetComponent<Image>().sprite = null;
                    }
                }
                else
                {
                    SetItem(1);
                    if (PlayerPrefs.GetInt("inventoryget2", 0) == 0)
                    {
                        invenItem_obj[2].SetActive(false);
                        if (invenItem_obj[2].GetComponent<Image>().sprite != null)
                        {
                            invenItem_obj[2].GetComponent<Image>().sprite = null;
                        }
                    }
                    else
                    {
                        SetItem(2);
                        if (PlayerPrefs.GetInt("inventoryget3", 0) == 0)
                        {
                            invenItem_obj[3].SetActive(false);
                            if (invenItem_obj[3].GetComponent<Image>().sprite != null)
                            {
                                invenItem_obj[3].GetComponent<Image>().sprite = null;
                            }
                        }
                        else
                        {
                            SetItem(3);
                        }
                    }
                }
            }

            a = PlayerPrefs.GetInt("inventorynum", 0);


            PlayerPrefs.SetInt("changeitem", 0);
        }

        if (GM.GetComponent<CharMove>().canMove==false)
        {

            if (inout_i == 1)
            {
                SelectMove();

                if (selected_i == selectedNow_i)
                {
                    DisSelectItem();
                    CheckSelect();
                }
                else
                {
                    SelectItem();
                }
            }
                
        }


        CheckSelect();
        
    }


    /// <summary>
    /// 아이템 번호를 받고 슬롯 이미지를 바꾸고 슬롯을 켜준다
    /// </summary>
    /// <param name="a"></param>
    void SetItem(int a)
    {
        int p = PlayerPrefs.GetInt("inventoryget" + a, 0);
        int o = PlayerPrefs.GetInt("itemnum" + p,0);
        int t = PlayerPrefs.GetInt("stacking", 0);
        int t2 = PlayerPrefs.GetInt("whierestacking", 0);

        /*
        if (p==13)
        {
            t = 1;
            t2 = 0 + a;
            PlayerPrefs.SetInt("stackinghelp", PlayerPrefs.GetInt("stackinghelp", 12) + 1);
        }
        if (p == 1)
        {
            t = 1;
            t2 = 0 + a;
            PlayerPrefs.SetInt("stackinghelp", PlayerPrefs.GetInt("stackinghelp", 0) + 1);
        }
        Debug.Log(PlayerPrefs.GetInt("stackinghelp", p) +"adw");
        */
        Debug.Log(PlayerPrefs.GetInt("inventoryget" + a, 6) + "p"+p+"p"+PlayerPrefs.GetInt("itemnum" + p, 0));


        if (t == 1&& t2==a)
        {
            /*
            PlayerPrefs.SetInt("stacking", 0);
            PlayerPrefs.SetInt("whierestacking", 0);
            invenItem_obj[a].SetActive(true);
            if (invenItem_obj[a].GetComponent<Image>().sprite == null)
            {
                invenItem_obj[a].GetComponent<Image>().sprite = Item_spr[p];
                items_i[a] = p;
                Debug.Log("1a"+ p);
            }
            else
            {
                invenItem_obj[a].GetComponent<Image>().sprite = Item_spr[p+o];
                items_i[a] = p+o;

                Debug.Log("2a" + o);
                //Debug.Log("a"+o);
            }
            */
            if (p == 13)
            {
                invenItem_obj[a].GetComponent<Image>().sprite = Item_spr[PlayerPrefs.GetInt("itemnum" + p, 0) + p - 1];
                items_i[a] = PlayerPrefs.GetInt("itemnum" + p, 0) + p - 1;

                invenItem_obj[a].SetActive(true);
                invenItem_obj[a].GetComponent<Image>().sprite = Item_spr[PlayerPrefs.GetInt("itemnum" + p, 0) + p - 1];
                //PlayerPrefs.SetInt("inventoryget" + a, items_i[a]);
            }
            if (p == 1)
            {
                invenItem_obj[a].GetComponent<Image>().sprite = Item_spr[PlayerPrefs.GetInt("itemnum" + p, 0) + p - 1];
                items_i[a] = PlayerPrefs.GetInt("itemnum" + p, 0) + p - 1;

                //PlayerPrefs.SetInt("inventoryget" + a, items_i[a]);

                invenItem_obj[a].SetActive(true);
                invenItem_obj[a].GetComponent<Image>().sprite = Item_spr[PlayerPrefs.GetInt("itemnum" + p, 0) + p - 1];
            }

            

            PlayerPrefs.SetInt("stacking", 0);
            PlayerPrefs.SetInt("whierestacking", 0);
        }
        else
        {

            if (p == 13 || p == 1)
            {
                if(PlayerPrefs.GetInt("itemnum" + p, 0) == 1)
                {
                    invenItem_obj[a].SetActive(true);
                    if (invenItem_obj[a].GetComponent<Image>().sprite == null)
                    {
                    }

                    invenItem_obj[a].GetComponent<Image>().sprite = Item_spr[p];
                    items_i[a] = p;
                }
            }
            else
            {
                invenItem_obj[a].SetActive(true);
                if (invenItem_obj[a].GetComponent<Image>().sprite == null)
                {
                }

                invenItem_obj[a].GetComponent<Image>().sprite = Item_spr[p];
                items_i[a] = p;
            }

            Debug.Log("3a" + p);
        }



    }

    /// <summary>
    /// 아래로 내려오기
    /// </summary>
    /// <returns></returns>
    IEnumerator ShowWindow()
    {

        SGM.GetComponent<SoundEvt>().soundItemWndOpen();
        while (in_i == 1)
        {
            position.y = position.y - 27f * Time.deltaTime;
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

        SGM.GetComponent<SoundEvt>().soundItemWndOpen();
        think_obj.SetActive(false);
        while (in_i == 1)
        {
            position.y = position.y + 27f * Time.deltaTime;
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


    void SelectItem()
    {
        if (items_i[selected_i] != 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                SGM.GetComponent<SoundEvt>().soundItemWndSelect();

                selected_obj.SetActive(true);
                selected_obj.GetComponent<Image>().sprite = invenItem_obj[selected_i].GetComponent<Image>().sprite;
                PlayerPrefs.SetInt("selecteditemnum", items_i[selected_i]);
                selectedNow_i = 0 + selected_i;
            }
        }
    }

    void DisSelectItem()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            selected_obj.SetActive(false);
            PlayerPrefs.SetInt("selecteditemnum", 0);
            selectedNow_i = -1;
        }
    }

    public void CheckSelect()
    {
        //Debug.Log("selectedNow_i" + selectedNow_i);
        if (selectedNow_i !=-1)
        {
            selected_obj.SetActive(true);
            selected_obj.GetComponent<Image>().sprite = invenItem_obj[selectedNow_i].GetComponent<Image>().sprite;
        }
        else
        {
            selected_obj.SetActive(false);
        }
    }

    public void DelItem()
    {

        a = PlayerPrefs.GetInt("inventorynum", 0);
        Debug.Log("aaaa" + a);
        a--;
        int p = PlayerPrefs.GetInt("inventoryget" + a, 0);
        int o = PlayerPrefs.GetInt("itemnum" + p);
        int t = PlayerPrefs.GetInt("stacking", 0);
        int t2 = PlayerPrefs.GetInt("whierestacking", 0);


        PlayerPrefs.SetInt("inventoryget" + a, 0);
        invenItem_obj[a].GetComponent<Image>().sprite = null;
        invenItem_obj[a].SetActive(false);
        items_i[a] = 0;
        selected_obj.SetActive(false);
        PlayerPrefs.SetInt("selecteditemnum", 0);
        selectedNow_i = -1;


        PlayerPrefs.SetInt("inventorynum", a);
    }

    void SelectMove()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SGM.GetComponent<SoundEvt>().soundItemWndAD();
            for (int i = 0; i < 7; i++)
            {
                selectBox_obj[i].SetActive(false);
            }
            if (selected_i < 6)
            {
                selected_i++;
            }

            selectBox_obj[selected_i].SetActive(true);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.D))
            {

                SGM.GetComponent<SoundEvt>().soundItemWndAD();
                for (int i = 0; i < 7; i++)
                {
                    selectBox_obj[i].SetActive(false);
                }

                if (selected_i > 0)
                {
                    selected_i--;
                }
                selectBox_obj[selected_i].SetActive(true);
            }
        }
    }
    


    void SeletR()
    {

    }
    void SeletL()
    {

    }



    public void quitGame()
    {
        Application.Quit();
    }

    public void showFeedback()
    {
        Application.OpenURL("https://forms.gle/CGuVE8nRbE1QaRSc6");
    }

    public void showESCwindow()
    {
        ESCevent.SetActive(true);
    }


    public void closeESCwindow()
    {
        ESCevent.SetActive(false);
    }
}
