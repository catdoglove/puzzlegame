using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerEvent : MonoBehaviour
{
    public int move_i = 1;
    // Start is called before the first frame update


    Vector3 position;
    public Vector2 size;
    public LayerMask whatIsLayer;

    public Sprite balloon_spr;
    public GameObject balloon_obj;
    public float x_f, y_f;
    public int a = 0;
    int k = 0;
    public GameObject GMS,GM, GMI,GMM;

    //
    public string SetItemPref_str = "text";
    public int SetItemPref_i = 0;
    public bool itemQ_b;
    public GameObject GetItem_obj, GetItemS_obj, GetItemO_obj;


    public string SetEventPref_str = "text";
    public int[] EventNum_i, EventNum1_i, EventNum2_i;
    public Sprite[] Event_spr, Event2_spr;
    public GameObject talkBall_obj, talkBallB_obj;
    public int giveItemPref_i = 0;
    public int getItemPref_i = 0;


    public GameObject char_obj;


    public Vector3 position0;
    public GameObject move_obj;
    public GameObject[] npc_obj;

    public Sprite change_spr;

    /// <summary>
    /// 말중간에다른 상호작용금지
    /// </summary>
    public bool talk_b = true;
    int wait = 0;


    Color color;
    public GameObject fade_obj;
    public float moveY, moveX;
    Vector2 mouseDragPos;
    public Vector2 wldObjectPos;

    public Sprite item_spr;


    public GameObject SGM;


    public GameObject laterEvent_obj;

    public GameObject puzzle_obj,crow_obj;

    public GameObject hall_obj, hallFix_obj;

    public GameObject rideGM, moveGM;

    public bool d_b, water_b;

    private void OnEnable()
    {
        //StartCoroutine("Checking");
    }

    void Start()
    {

        //
        /*
        PlayerPrefs.SetInt("inventorynum", 0);
        PlayerPrefs.SetInt("inventoryget0", 0);
        PlayerPrefs.SetInt("item0", 0);
        PlayerPrefs.SetInt("inventoryget1", 0);
        PlayerPrefs.SetInt("item1", 0);
        PlayerPrefs.SetInt(SetEventPref_str, 0);
        PlayerPrefs.SetInt("inventorynum", 0);
        PlayerPrefs.SetInt("inventoryget0", 0);
        PlayerPrefs.SetInt("itemnum0", 0);
        PlayerPrefs.SetInt("inventoryget1", 0);
        PlayerPrefs.SetInt("itemnum1", 0);
        PlayerPrefs.SetInt("inventoryget2", 0);
        PlayerPrefs.SetInt("itemnum2", 0);
        PlayerPrefs.SetInt("mapindexnum", 0);
        PlayerPrefs.SetInt("stacking", 0);
        PlayerPrefs.SetInt("whierestacking", 0);
        PlayerPrefs.SetInt("changeitem", 0);
        */


    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, size);
    }

    private void Update()
    {

        wait = PlayerPrefs.GetInt("wait", 0);
        if (wait == 0)
        {

            Collider2D hit = Physics2D.OverlapBox(transform.position, size, 0, whatIsLayer);
            if (hit == null)
            {
                if (a == 1)
                {
                    balloon_obj.SetActive(false);
                    //GMS.GetComponent<BounceAnim>().resetAnim();
                }
                a = 0;
            }
            else
            {
                //Debug.Log(hit.name);
                if (a == 0)
                {
                    position = this.transform.position;
                    x_f = balloon_spr.bounds.size.x;
                    y_f = balloon_spr.bounds.size.y;
                    //position.x = position.x - balloon_spr.bounds.size.x * 3f;
                    position.y = position.y + (balloon_spr.bounds.size.y) * 1.5f + 0.2f;
                    a = 1;
                    balloon_obj.transform.position = position;
                }

                if (char_obj.transform.position.x > this.transform.position.x)
                {
                    position.x = this.transform.position.x - balloon_spr.bounds.size.x * 3f - 0.7f;
                    balloon_obj.GetComponent<SpriteRenderer>().flipX = false;
                }
                else
                {
                    position.x = this.transform.position.x + balloon_spr.bounds.size.x * 3f + 0.7f;
                    balloon_obj.GetComponent<SpriteRenderer>().flipX = true;
                }

                balloon_obj.transform.position = position;

                if (GM.GetComponent<CharMove>().canMove == true)
                {
                    balloon_obj.SetActive(true);
                }
                else
                {
                    balloon_obj.SetActive(false);
                }
                if (Input.GetKeyUp(KeyCode.Space))
                {

                    if (GMI.GetComponent<Inventory>().inout_i == 0)
                    {
                        EventOrItem();
                    }

                }
            }
        }

        if (PlayerPrefs.GetInt("crowatted", 0) == 0)
        {
            if (PlayerPrefs.GetInt("crowatt", 0) == 1)
            {
                if (Input.anyKey)
                {
                    //crow_obj.SetActive(false);

                    balloon_obj.SetActive(false);
                    talkBall_obj.SetActive(false);
                    GM.GetComponent<CharMove>().canMove = true;
                    GM.GetComponent<CharMove>().Speed = 2.5f;
                    SGM.GetComponent<SoundEvt>().soundCrowAttack();
                    PlayerPrefs.SetInt("crowatted", 1);
                    this.gameObject.SetActive(false);
                }
            }
        }
    }

    IEnumerator Checking()
    {
        while (move_i == 1)
        {
            yield return new WaitForSeconds(0.01f);
        }
    }

    /// <summary>
    ///  아이템인가
    /// </summary>
    void EventOrItem()
    {
        
        if (itemQ_b)
        {
            ItemSetting();
            
        }
        else
        {
            if (talk_b)
            {
                EventSetting();
            }
        }
        
    }

    /// <summary>
    /// 아이템값받아오고 인벤토리에넣는다.
    /// </summary>
    void ItemSetting()
    {


        SGM.GetComponent<SoundEvt>().soundPickUp();
        int a = 0;
        a = PlayerPrefs.GetInt("inventorynum", 0);

        
        //if (PlayerPrefs.GetInt("itemnum" + SetItemPref_i, 0) == 0)
        //{


            int p = PlayerPrefs.GetInt("inventoryget" + a, 0);
            int o = PlayerPrefs.GetInt("itemnum" + SetItemPref_i, 0);

        CheckStack();

        if (PlayerPrefs.GetInt("stacking", 0) == 1)
        {
            
        }
        else
        {
            if (PlayerPrefs.GetInt("inventoryget" + a, 0) == 0)
            {
                PlayerPrefs.SetInt("inventoryget" + a, SetItemPref_i);
                
            }
            a++;
        }

        
        o++;
        PlayerPrefs.SetInt("inventorynum", a);
        p = PlayerPrefs.GetInt("inventoryget" + a, 0);
        PlayerPrefs.SetInt("itemnum" + SetItemPref_i, o);
        //PlayerPrefs.SetInt("itemnum" + SetItemPref_i, 1);
        //GetItem_obj.SetActive(true);
            balloon_obj.SetActive(false);
            this.gameObject.SetActive(false);

        PlayerPrefs.SetInt("changeitem", 1);

        //StartCoroutine("imgFadeOut");
        //}
        DelThis();
    }

    void DelThis()
    {
        Destroy(GetItemO_obj);
    }

    void CheckStack()
    {
        int k = 7;

        if (SetItemPref_i == 14)
        {
            SetItemPref_i = 13;
        }
        if (SetItemPref_i == 2)
        {
            SetItemPref_i = 1;
        }
        
        for (int i = 0; i < k; i++)
        {
            //Debug.Log("inventoryget" + PlayerPrefs.GetInt("inventoryget" + i, 0)+"i"+ SetItemPref_i);

            if (PlayerPrefs.GetInt("inventoryget" + i, 0) == SetItemPref_i)
            {
                PlayerPrefs.SetInt("stacking", 1);
                PlayerPrefs.SetInt("whierestacking", i);
                PlayerPrefs.SetInt("saveinventoryget", SetItemPref_i);
                Debug.Log(i);
            }
        }
        
    }
    

    /// <summary>
    /// 아이템값받아오고 인벤토리에서지운다.
    /// </summary>
    void ItemRemoving()
    {
        int a = 0;
        a = PlayerPrefs.GetInt("inventorynum", 0);

        if (PlayerPrefs.GetInt("inventoryget" + a, 0) != 0)
        {
            PlayerPrefs.SetInt("inventoryget" + a, 0);
        }
        a--;
        if (a<0)
        {
            a = 0;
        }
        PlayerPrefs.SetInt("inventorynum", a);
    }
    


    /// <summary>
    /// 이벤트값받아오고 진행처리해준다.
    /// </summary>
    void EventSetting()
    {
        int a = 0;
        a = PlayerPrefs.GetInt(SetEventPref_str, 0);
        k = a;
        switch (EventNum_i[a])
        {
            case 0:
                break;
            case 1://말풍선띄우고 다음으로
                SGM.GetComponent<SoundEvt>().soundTalk();
                StopAndTalk();
                a++;
                break;
            case 2://말풍선 띄우고 아이템 요구
                SGM.GetComponent<SoundEvt>().soundTalk();
                break;
            case 3://대화 멈춤
                StopTalk();
                talkBallB_obj.SetActive(false);
                a++;
                break;
            case 4://말풍선 띄우고 특수 아이템요구
                SGM.GetComponent<SoundEvt>().soundTalk();
                StopAndTalk();
                a++;
                if (PlayerPrefs.GetInt("selecteditemnum", 0)== giveItemPref_i)
                {
                    a++;
                }
                break;
            case 5://대화 종료
                StopTalk();
                a--;
                break;
            case 6://아래 이동
                StopTalk();
                talkBallB_obj.SetActive(false);
                StartCoroutine("EventDown");
                a++;
                break;
            case 7://종료
                StopTalk();
                talkBallB_obj.SetActive(false);
                a--;
                break;
            case 8://특수 아이템요구 아이템제거
                SGM.GetComponent<SoundEvt>().soundItemFail();
                a++;
                if (PlayerPrefs.GetInt("selecteditemnum", 0) == giveItemPref_i)
                {

                    if (d_b)
                    {
                        SGM.GetComponent<SoundEvt>().soundDamage();
                    }
                    else
                    {
                        SGM.GetComponent<SoundEvt>().soundItemUse();
                    }
                    a++;
                    GMI.GetComponent<Inventory>().DelItems();
                    move_obj.GetComponent<SpriteRenderer>().sprite = change_spr;
                }
                
                k = a;
                //StopAndTalk();
                break;
            case 9://말풍선 띄우고 특수 플레그 요구
                SGM.GetComponent<SoundEvt>().soundTalk();
                a++;
                if (PlayerPrefs.GetInt(""+ SetItemPref_str, 0) == 1)
                {
                    a++;
                }

                k = a;
                StopAndTalk();
                break;
            case 10://말풍선 두가지반복
                StopTalk();
                talkBallB_obj.SetActive(false);
                a--;
                a--;
                break;
            case 11://특수 아이템요구 아이템제거 아이템획득
                SGM.GetComponent<SoundEvt>().soundItemFail();
                a++;
                if (PlayerPrefs.GetInt("selecteditemnum", 0) == getItemPref_i)
                {
                    SGM.GetComponent<SoundEvt>().soundItemUse();
                    a++;
                    GMI.GetComponent<Inventory>().DelItems();
                    ItemSettingOnEvent();
                    laterEvent_obj.SetActive(true);
                }

                k = a;



                break;
            case 12://특수 아이템요구 
                if (PlayerPrefs.GetInt("selecteditemnum", 0) == 36)
                {
                    if (water_b)
                    {
                        SGM.GetComponent<SoundEvt>().soundItemUse();
                        GMI.GetComponent<Inventory>().DelItems();
                        ItemSettingOnEvent();
                        this.gameObject.SetActive(false);
                    }
                    else
                    {
                        SGM.GetComponent<SoundEvt>().soundItemFail();
                        a++;
                    }
                }
                else
                {
                    if (SetItemPref_i == 17)
                    {

                        this.gameObject.SetActive(false);
                    }
                    SGM.GetComponent<SoundEvt>().soundItemFail();
                    a++;
                    Debug.Log(PlayerPrefs.GetInt("selecteditemnum", 0) + "d" + getItemPref_i);

                    if (PlayerPrefs.GetInt("selecteditemnum", 0) == giveItemPref_i)
                    {
                        SGM.GetComponent<SoundEvt>().soundItemUse();
                        Debug.Log(PlayerPrefs.GetInt("selecteditemnum", 0) + getItemPref_i);
                        a++;
                        move_obj.GetComponent<SpriteRenderer>().sprite = change_spr;
                        move_obj.gameObject.SetActive(false);
                        ItemSettingOnEvent();
                    }
                }

                k = a;
                //StopAndTalk();
                break;
            case 13://말풍선 띄우고 퀘스트 시작
                SGM.GetComponent<SoundEvt>().soundTalk();
                StopAndTalk();
                a++;
                PlayerPrefs.SetInt(SetItemPref_str, 1);
                npc_obj[1].SetActive(true);
                npc_obj[0].SetActive(false);
                npc_obj[3].SetActive(true);
                npc_obj[2].SetActive(false);
                break;
            case 14://위 이동
                StopTalk();
                talkBallB_obj.SetActive(false);
                StartCoroutine("EventUp");
                a++;
                break;
            case 15://퍼즐 이벤트
                //SGM.GetComponent<SoundEvt>().soundTalk();
                StopAndTalk();
                a++;
                PlayerPrefs.SetInt("nowtalk", 1);
                puzzle_obj.SetActive(true);
                GM.GetComponent<CharMove>().canMove = false;
                this.gameObject.SetActive(false);
                PlayerPrefs.SetInt("escdont", 1);
                balloon_obj.SetActive(false);
                break;

            case 16://특수 아이템요구 아이템제거 아이템획득
                SGM.GetComponent<SoundEvt>().soundItemFail();
                a++;
                if (PlayerPrefs.GetInt("selecteditemnum", 0) == getItemPref_i )
                {
                    SGM.GetComponent<SoundEvt>().soundItemUse();
                    a = 2;
                    GMI.GetComponent<Inventory>().DelItems();
                    hallFix_obj.SetActive(true);
                    hall_obj.SetActive(false);
                    SetItemPref_i = getItemPref_i;
                }
                if (PlayerPrefs.GetInt("selecteditemnum", 0) == getItemPref_i + 1)
                {
                    SGM.GetComponent<SoundEvt>().soundItemUse();
                    a = 2;
                    GMI.GetComponent<Inventory>().DelItems();
                    hallFix_obj.SetActive(true);
                    hall_obj.SetActive(false);
                    SetItemPref_i = getItemPref_i + 1;
                }
                k = a;
                break;

            case 17://특수 아이템요구 아이템제거 아이템획득
                SGM.GetComponent<SoundEvt>().soundPickUp();
                a = 0;
                    ItemSettingOnEvent();
                hallFix_obj.SetActive(false);
                hall_obj.SetActive(true);
                k = a;
                break;
            case 18://외부 함수 실행

                SGM.GetComponent<SoundEvt>().soundItemFail();
                a++;
                if (PlayerPrefs.GetInt("selecteditemnum", 0) == giveItemPref_i)
                {
                    SGM.GetComponent<SoundEvt>().soundItemUse();
                    StopTalk();
                    rideGM.GetComponent<example>().mapwhere = 99;
                    //
                    char_obj.SetActive(false);
                    GMI.GetComponent<Inventory>().DelItems();
                    move_obj.GetComponent<SpriteRenderer>().sprite = change_spr;
                }

                k = a;

                break;
            case 19:// 까마귀 삽화

                //moveGM.SetActive(true);

                //GM.GetComponent<CharMove>().canMove = false;
                break;
            case 20://퍼즐 이벤트

                //puzzle_obj.GetComponent<RockMini>().ShowPuzzle();
                //PlayerPrefs.SetInt("cursorActive", 1);
                if (PlayerPrefs.GetInt("selecteditemnum", 0) == giveItemPref_i)
                {
                    SGM.GetComponent<SoundEvt>().soundItemUse();
                    StopAndTalk();
                    a++;
                    GM.GetComponent<CharMove>().canMove = false;
                    PlayerPrefs.SetInt("cursorActive", 1);
                    puzzle_obj.GetComponent<RockMini>().ShowPuzzle();

                    GMI.GetComponent<Inventory>().DelItems();
                }
                else
                {
                    SGM.GetComponent<SoundEvt>().soundItemFail();
                }
                break;
            case 21://특수 아이템요구 
                if (PlayerPrefs.GetInt("selecteditemnum", 0) == 36)
                {
                    SGM.GetComponent<SoundEvt>().soundItemUse();
                    //move_obj.GetComponent<SpriteRenderer>().sprite = change_spr;
                    //move_obj.gameObject.SetActive(false);
                    GMI.GetComponent<Inventory>().DelItems();
                    ItemSettingOnEvent();
                }
                else
                {
                    SGM.GetComponent<SoundEvt>().soundItemFail();
                    a++;
                }

                k = a;
                //StopAndTalk();
                break;
            case 22:
                moveGM.SetActive(true);

                GM.GetComponent<CharMove>().canMove = false;
                break;
            case 25://퍼즐 이벤트
                //SGM.GetComponent<SoundEvt>().soundTalk();
                StopAndTalk();
                a++;
                PlayerPrefs.SetInt("nowtalk", 1);
                puzzle_obj.SetActive(true);
                GM.GetComponent<CharMove>().canMove = false;
                this.gameObject.SetActive(false);
                PlayerPrefs.SetInt("escdont", 1);
                balloon_obj.SetActive(false);
                break;

            default:
                break;
        }
        PlayerPrefs.SetInt(SetEventPref_str, a);



    }

    public void StopAndTalk()
    {
        GM.GetComponent<CharMove>().canMove = false;
        
    }



    public void StopTalk()
    {

        GM.GetComponent<CharMove>().canMove = true;


    }

    void sw()
    {

        
    }



    /// <summary>
    /// 아이템값받아오고 인벤토리에넣는다.
    /// </summary>
    public void ItemSettingOnEvent()
    {
        int a = 0;
        a = PlayerPrefs.GetInt("inventorynum", 0);

        int hel = 0;

        //if (PlayerPrefs.GetInt("itemnum" + SetItemPref_i, 0) == 0)
        //{


        int p = PlayerPrefs.GetInt("inventoryget" + a, 0);
        int o = PlayerPrefs.GetInt("itemnum" + SetItemPref_i, 0);

        CheckStack();
        if (PlayerPrefs.GetInt("stacking", 0) == 1)
        {

        }
        else
        {
            //Debug.Log("a"+a+"p"+GMI.GetComponent<Inventory>().items_i[a]);
            if (a != 0)
            {
                k = a - 1;
            }

            if (GMI.GetComponent<Inventory>().items_i[k] == 11)
            {

                Debug.Log(GMI.GetComponent<Inventory>().items_i[k]);
                PlayerPrefs.SetInt("inventoryget" + k, 6);
                hel = 1;
            }
            else
            {
                if (GMI.GetComponent<Inventory>().items_i[k] == 5)
                {

                    Debug.Log(GMI.GetComponent<Inventory>().items_i[k]);
                    PlayerPrefs.SetInt("inventoryget" + k, 6);
                    hel = 1;
                }
                else
                {
                    if (PlayerPrefs.GetInt("inventoryget" + a, 0) == 0)
                    {
                        PlayerPrefs.SetInt("inventoryget" + a, SetItemPref_i);
                    }
                }
            }


            //GetItem_obj.SetActive(true);

            PlayerPrefs.SetInt("changeitem", 1);

            //StartCoroutine("imgFadeOut");


            a++;


        }


        o++;
        PlayerPrefs.SetInt("inventorynum", a);
        p = PlayerPrefs.GetInt("inventoryget" + a, 0);
        PlayerPrefs.SetInt("itemnum" + SetItemPref_i, o);

        PlayerPrefs.SetInt("changeitem", 1);

        if (hel==1)
        {
            PlayerPrefs.SetInt("inventorynum", (a-1));
        }


        GMI.GetComponent<ItemGetMotion>().fade_obj.GetComponent<SpriteRenderer>().sprite = item_spr;
        GMI.GetComponent<ItemGetMotion>().fade_obj.transform.position = this.transform.position;
        GMI.GetComponent<ItemGetMotion>().FadeItem();
    }




    IEnumerator talkBall()
    {
        int c = 1;
        int s = 0;
        while (c <= 20)
        {
            if (s==0)
            {
                talkBall_obj.GetComponent<SpriteRenderer>().sprite = Event_spr[k];
                s = 1;
            }
            else
            {
                talkBall_obj.GetComponent<SpriteRenderer>().sprite = Event2_spr[k];
                s = 0;
            }
            yield return new WaitForSeconds(0.5f);
            //c++;
        }

    }



    /// <summary>
    /// 위로 올라가기
    /// </summary>
    /// <returns></returns>
    IEnumerator EventUp()
    {
        talk_b = false;
        int in_i = 1;
        position0 = transform.position;
        while (in_i == 1)
        {
            position0.y = position0.y + 20f * Time.deltaTime;
            transform.position = position0;

            if (position0.y >= move_obj.transform.position.y)
            {
                in_i = 0;
            }

            yield return new WaitForSeconds(0.01f);
        }
        talk_b = true;
    }


    /// <summary>
    /// 위로 올라가기
    /// </summary>
    /// <returns></returns>
    IEnumerator EventDown()
    {
        GM.GetComponent<CharMove>().canMove = false;
        talk_b = false;
        int in_i = 1;
        position0 = transform.position;
        while (in_i == 1)
        {
            position0.y = position0.y - 20f * Time.deltaTime;
            transform.position = position0;

            if (position0.y <= move_obj.transform.position.y)
            {
                in_i = 0;
            }

            yield return new WaitForSeconds(0.01f);
        }
        talk_b = true;
        GM.GetComponent<CharMove>().canMove = true;
    }


    IEnumerator imgFadeOut()
    {
        color = GetItem_obj.GetComponent<SpriteRenderer>().color;
        moveX = this.transform.position.x;
        moveY = this.transform.position.y;
        color.a = Mathf.Lerp(0f, 1f, 1f);
        for (float i = 1f; i > 0f; i -= 0.05f)
        {
            color.a = Mathf.Lerp(0f, 1f, i);
            GetItem_obj.GetComponent<SpriteRenderer>().color = color;
            moveY = moveY + 0.02f;
            GetItem_obj.transform.position = new Vector2(moveX, moveY);
            yield return null;
        }
        GetItem_obj.transform.position = new Vector2(15f, 15f);
    }


    public void GetS()
    {
            SGM.GetComponent<SoundEvt>().soundItemUse();
            a++;
            GMI.GetComponent<Inventory>().DelItems();
            ItemSettingOnEvent();
            laterEvent_obj.SetActive(true);
    }
}
