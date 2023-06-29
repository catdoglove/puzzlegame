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

    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        position = itemWindow_obj.transform.position;
    }

    public void WaitSec()
    {

        MainGM.GetComponent<SceneAdd>().AtiveScene();
        PlayerPrefs.SetInt("helpdogam",1);
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
            if (GM.GetComponent<CharMove>().canMove )
            {
                if (in_i==0)
                {
                    SGM.GetComponent<SoundEvt>().soundItemWndOpen();
                    MainGM.GetComponent<SceneAdd>().AtiveScene();
                }
            }
            else
            {
            }
        }


        if (Input.GetKeyDown(KeyCode.E))
        {

            if (itemGetting_b == false)
            {


                if (in_i == 0)
                {
                    if (inout_i == 0)
                    {

                        if (GM.GetComponent<CharMove>().canMove)
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
        CheckThePoint();
        //Sub();
        AddItem();


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

    void Sub()
    {

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
            position.y = position.y - 10f * Time.deltaTime;
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
            position.y = position.y + 10f * Time.deltaTime;
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
            PlayerPrefs.SetInt("selecteditemnum", items_i[selectedNow_i]);
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

        /*
        for (int i = 0; i < a; i++)
        {
            int p_a = PlayerPrefs.GetInt("inventoryget" + (i + 1), 0);
            PlayerPrefs.SetInt("inventoryget" + i, p_a); items_i[i] = p_a;
            if (p_a != 0)
            {
                invenItem_obj[i].SetActive(true);
                invenItem_obj[i].GetComponent<Image>().sprite = Item_spr[p_a];
            }
            Debug.Log("afor" + a); Debug.Log("pafor" + p_a);
        }
        */

        PlayerPrefs.SetInt("inventoryget" + a, 0);
        invenItem_obj[a].GetComponent<Image>().sprite = null;
        invenItem_obj[a].SetActive(false);
        items_i[a] = 0;
        selected_obj.SetActive(false);
        PlayerPrefs.SetInt("selecteditemnum", 0);
        selectedNow_i = -1;


        PlayerPrefs.SetInt("inventorynum", a);
        /*
        */


        PlayerPrefs.SetInt("itemgetpoint", a);
    }

    public void DelItems()
    {

        a = 0 + selectedNow_i;
        int p = PlayerPrefs.GetInt("inventoryget" + a, 0);
        int o = PlayerPrefs.GetInt("itemnum" + p);
        int t = PlayerPrefs.GetInt("stacking", 0);
        int t2 = PlayerPrefs.GetInt("whierestacking", 0);


        Debug.Log("a"+a);

        PlayerPrefs.SetInt("inventoryget" + a, 0);
        PlayerPrefs.SetInt("itemnum" + p, 0);
        invenItem_obj[a].GetComponent<Image>().sprite = null;
        invenItem_obj[a].SetActive(false);
        items_i[a] = 0;
        selected_obj.SetActive(false);
        PlayerPrefs.SetInt("selecteditemnum", 0);
        selectedNow_i = -1;


        PlayerPrefs.SetInt("inventorynum", a);
        /*
        */
        Debug.Log("fillpotint1ii" + PlayerPrefs.GetInt("fillpotint", 0));
        if (PlayerPrefs.GetInt("itemgetpoint", 0) == PlayerPrefs.GetInt("fillpotint", 0)&& PlayerPrefs.GetInt("itemgetpoint", 0)!=0)
        {

            Debug.Log("fillpotint1i" + (PlayerPrefs.GetInt("fillpotint", 0) - 1));
            PlayerPrefs.SetInt("fillpotint", (PlayerPrefs.GetInt("fillpotint", 0) - 1));

            Debug.Log("itemgetpoint"+ PlayerPrefs.GetInt("itemgetpoint", 0));
        }
        else
        {
        }

        for (int i = 6; i >= 0; i--)
        {
            if (items_i[i] == 0)
            {
                PlayerPrefs.SetInt("itemgetpoint", a);
            }
        }

        /*
        if (PlayerPrefs.GetInt("itemgetpoint", 0) > a)
        {
            PlayerPrefs.SetInt("itemgetpoint", a);
        }
        */
        PlayerPrefs.SetInt("changeitem", 1);

    }

    void SelectMove()
    {
        if (Input.GetKeyDown(KeyCode.D))
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
            if (Input.GetKeyDown(KeyCode.A))
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


    public void CheckThePoint()
    {
        //아이템이 바뀌었는가?
        if (PlayerPrefs.GetInt("changeitem", 0) == 0)
        {

        }
        else
        {
            //아이템이 바뀌었을 때 아이템을 비워준다
            for (int i = 0; i < PlayerPrefs.GetInt("fillpotint", 0); i++)
            {
                if (PlayerPrefs.GetInt("inventoryget" + i, 0) == 0)
                {
                    invenItem_obj[i].SetActive(false);
                    if (invenItem_obj[i].GetComponent<Image>().sprite != null)
                    {
                        invenItem_obj[i].GetComponent<Image>().sprite = null;
                    }
                }
            }
            



        }
    }

    public void AddItem()
    {
        //아이템이 바뀌었는가?
        if (PlayerPrefs.GetInt("changeitem", 0) == 0)
        {

        }
        else
        {

            SetItems();


            a = PlayerPrefs.GetInt("inventorynum", 0);
        }
        PlayerPrefs.SetInt("changeitem", 0);
    }

    //아이템에 변화가 생기는 타이밍 아이템의 제거 아이템의 합체 아이템의 획득 아이템의 사용
    //아이템의 빈공간 포인트에 새 아이템을 넣는다
    //스택의 경우 예외처리
    //빈공간 포인트가 채워진 포인트보다 클경우 채워진 포인트를 증가시킨다

    void SetItems()
    {
        FillPoint();
        /*
        //p번 아이템이 a번째 칸에 차있다
        int p = PlayerPrefs.GetInt("inventoryget" + a, 0);
        //p번 아이템을 o 개자지고 있다
        int o = PlayerPrefs.GetInt("itemnum" + p, 0);
        //쌓이는가
        int t = PlayerPrefs.GetInt("stacking", 0);
        //t2에 쌓여있다
        int t2 = PlayerPrefs.GetInt("whierestacking", 0);

        int g = 0;

        //채워진 곳까지 아이템이미지 갱신
        if (PlayerPrefs.GetInt("fillpotint", 0)<8)
        {
            for (int i = 0; i < PlayerPrefs.GetInt("fillpotint", 0); i++)
            {
                p = PlayerPrefs.GetInt("inventoryget" + i, 0);
                o = PlayerPrefs.GetInt("itemnum" + p, 0);
                if (o != 0)
                {
                    invenItem_obj[i].GetComponent<Image>().sprite = Item_spr[p + o - 1];
                    items_i[i] = p + o - 1;
                }
                invenItem_obj[i].SetActive(true);
                if (p == 13)
                {
                    invenItem_obj[i].GetComponent<Image>().sprite = Item_spr[PlayerPrefs.GetInt("itemnum" + p, 0) + p - 1];
                    items_i[i] = PlayerPrefs.GetInt("itemnum" + p, 0) + p - 1;
                    invenItem_obj[i].SetActive(true);
                }
                if (p == 1)
                {
                    invenItem_obj[i].GetComponent<Image>().sprite = Item_spr[PlayerPrefs.GetInt("itemnum" + p, 0) + p - 1];
                    items_i[i] = PlayerPrefs.GetInt("itemnum" + p, 0) + p - 1;
                    invenItem_obj[i].SetActive(true);
                }
                


                if (o == 0 && g == 0)
                {
                    PlayerPrefs.SetInt("itemgetpoint", i);
                    g = 1;
                }

            }
        }
        */

    }

    void FillPoint()
    {
        //p번 아이템이 a번째 칸에 차있다
        int p = PlayerPrefs.GetInt("inventoryget" + a, 0);
        //p번 아이템을 o 개자지고 있다
        int o = PlayerPrefs.GetInt("itemnum" + p, 0);
        //쌓이는가
        int t = PlayerPrefs.GetInt("stacking", 0);
        //t2에 쌓여있다
        int t2 = PlayerPrefs.GetInt("whierestacking", 0);

        int g = 0;

        for (int i = 0; i < 7; i++)
        {
            p = PlayerPrefs.GetInt("inventoryget" + i, 0);
            o = PlayerPrefs.GetInt("itemnum" + p, 0);
            if (p == 18 || p == 19)
            {
                o = 1;
            }
            if (o != 0)
            {
                invenItem_obj[i].GetComponent<Image>().sprite = Item_spr[p + o - 1];
                items_i[i] = p + o - 1;
            }
            invenItem_obj[i].SetActive(true);
            if (p == 13)
            {
                invenItem_obj[i].GetComponent<Image>().sprite = Item_spr[PlayerPrefs.GetInt("itemnum" + p, 0) + p - 1];
                items_i[i] = PlayerPrefs.GetInt("itemnum" + p, 0) + p - 1;
                invenItem_obj[i].SetActive(true);
            }
            if (p == 1)
            {
                invenItem_obj[i].GetComponent<Image>().sprite = Item_spr[PlayerPrefs.GetInt("itemnum" + p, 0) + p - 1];
                items_i[i] = PlayerPrefs.GetInt("itemnum" + p, 0) + p - 1;
                invenItem_obj[i].SetActive(true);
            }

            if (items_i[i]==0)
            {
                invenItem_obj[i].SetActive(false);
            }


            if (o == 0 && g == 0)
            {
                PlayerPrefs.SetInt("itemgetpoint", i);
                g = 1;
            }

        }
    }

    /*
     * 겹치는 아이템을 받을 때 1. 가지고 있는 아이탬 종류의 수를 늘리지 않음 2. 아이템창을 새로고침함 3. 먼저 얻은 아이템을 사용할때 아이탬의 위치가 바뀌지 않음 
     * 4. 좌측정렬로 변환 5. 빈공간포인터는 좌측에서 제일 가까운 빈공간을 가르킨다 6. 아이탬이 몇번까지 차있는지 포인트가 가르키고 있다. 
     * 7. 아이템
     * 아이템을 
     
    */
}
