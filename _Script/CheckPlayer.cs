using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayer : MonoBehaviour
{
    public int move_i = 1;
    // Start is called before the first frame update


    Vector3 position;
    public Vector2 size;
    public LayerMask whatIsLayer;

    public Sprite balloon_spr;
    public GameObject balloon_obj;
    public float x_f, y_f;
    int a = 0;
    int k = 0;
    public GameObject GMS, GM, GMI;

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
    public GameObject move_obj, moveOther_obj;
    public GameObject[] npc_obj;


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



    public GameObject SGM, SGM2;

    public bool purple_b, soundLow_b;


    public GameObject bearColl_obj;

    public GameObject candyBar_obj;

    public bool broken_b;

    public Sprite candy_spr;

    public GameObject other_obj;

    public int animalNum_i;

    //까마귀 애니메이션

    public Animator crow_Ani;
    public bool flipX_b;

    //낚시대
    public GameObject stick_obj, makeBoad_obj;
    public bool stick_b, board_b;


    public string aniTalk_str, ani_str;
    public Animator all_Ani;

    public bool esterEgg_b, sheep_b, hidden_b, dontdis_b, function_b, bearmb;

    public GameObject BGM1, pop_obj;
    public Animator stop_Ani;

    public int num;

    public Sprite ori_spr;


    public GameObject q1_obj, q2_obj, q3_obj, q4_obj, o1_obj, o2_obj, o3_obj, o4_obj;

    public GameObject player_obj, playerPos_obj;

    public GameObject bbPos_obj, bearM_obj;
    public Vector3 b_position;

    public GameObject miniGame_obj;

    private void OnEnable()
    {
        GM.GetComponent<CharMove>().bulb_obj.SetActive(false);
        //StartCoroutine("Checking");
    }

    void Start()
    {

        if (itemQ_b)
        {
        }
        else
        {
            //ani_str = all_Ani;
            if (aniTalk_str == "")
            {
                aniTalk_str = ani_str + "_talk";
            }
        }
        ori_spr = this.GetComponent<SpriteRenderer>().sprite;
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
                    if (flipX_b)
                    {
                        position.x = this.transform.position.x + balloon_spr.bounds.size.x * 3f + 0.7f;
                        balloon_obj.GetComponent<SpriteRenderer>().flipX = true;
                    }
                }
                else
                {
                    position.x = this.transform.position.x + balloon_spr.bounds.size.x * 3f + 0.7f;
                    balloon_obj.GetComponent<SpriteRenderer>().flipX = true;
                    if (flipX_b)
                    {
                        position.x = this.transform.position.x - balloon_spr.bounds.size.x * 3f - 0.7f;
                        balloon_obj.GetComponent<SpriteRenderer>().flipX = false;
                    }
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
            if (function_b)
            {

                SGM.GetComponent<SoundEvt>().soundItemUse();
                talkBall_obj.SetActive(true);
                balloon_obj.SetActive(false);
                this.gameObject.SetActive(false);
            }
            else
            {
                ItemSettings();
            }
            //ItemSettingOnEvents();
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

        GMI.GetComponent<ItemGetMotion>().fade_obj.GetComponent<SpriteRenderer>().sprite = this.GetComponent<SpriteRenderer>().sprite;

        if (purple_b)
        {
            GMI.GetComponent<ItemGetMotion>().fade_obj.GetComponent<SpriteRenderer>().sprite = item_spr;
        }
        GMI.GetComponent<ItemGetMotion>().fade_obj.transform.position = this.transform.position;
        GMI.GetComponent<ItemGetMotion>().FadeItem();

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


        candy();

        //StartCoroutine("imgFadeOut");
        //}

        DelThis();
    }


    /// <summary>
    /// 아이템값받아오고 인벤토리에넣는다.
    /// </summary>
    void ItemSettings()
    {
        int a = 0;
        //빈공간저장하기
        a = PlayerPrefs.GetInt("itemgetpoint", 0);
        //소리
        SGM.GetComponent<SoundEvt>().soundPickUp();

        int hel = 0;
        if ((PlayerPrefs.GetInt("itemnum" + 1, 0) == 1 || PlayerPrefs.GetInt("itemnum" + 1, 0) == 2) && SetItemPref_i == 1)
        {
            int num = PlayerPrefs.GetInt("itemnum" + 1, 0);
            num++;
            PlayerPrefs.SetInt("itemnum" + 1, num);
        }
        else
        {
            if ((PlayerPrefs.GetInt("itemnum" + 13, 0) == 1 || PlayerPrefs.GetInt("itemnum" + 13, 0) == 2) && SetItemPref_i == 13)
            {
                int num = PlayerPrefs.GetInt("itemnum" + 13, 0);
                num++;
                PlayerPrefs.SetInt("itemnum" + 13, num);
            }
            else
            {

                if ((PlayerPrefs.GetInt("itemnum" + 27, 0) == 1 || PlayerPrefs.GetInt("itemnum" + 27, 0) == 2) && SetItemPref_i == 27)
                {
                    int num = PlayerPrefs.GetInt("itemnum" + 27, 0);
                    num++;
                    PlayerPrefs.SetInt("itemnum" + 27, num);
                }
                else
                {

                    if ((PlayerPrefs.GetInt("itemnum" + 30, 0) == 1 || PlayerPrefs.GetInt("itemnum" + 30, 0) == 2) && SetItemPref_i == 30)
                    {
                        int num = PlayerPrefs.GetInt("itemnum" + 30, 0);
                        num++;
                        PlayerPrefs.SetInt("itemnum" + 30, num);
                    }
                    else
                    {

                        if ((PlayerPrefs.GetInt("itemnum" + 1, 0) == 1 || PlayerPrefs.GetInt("itemnum" + 1, 0) == 2) && SetItemPref_i == 1)
                        {

                        }

                        //a번칸에 값저장
                        PlayerPrefs.SetInt("inventoryget" + a, SetItemPref_i);
                        PlayerPrefs.SetInt("changeitem", 1);
                        a++;
                        if (PlayerPrefs.GetInt("fillpotint", 0) < a)
                        {
                            Debug.Log("fillpotint1" + a);
                            PlayerPrefs.SetInt("fillpotint", a);

                            Debug.Log("aaaaa" + a);
                        }

                        Debug.Log("aaaaa" + a);
                        Debug.Log("fillpotint" + PlayerPrefs.GetInt("fillpotint", 0));
                        PlayerPrefs.SetInt("itemgetpoint", a);

                        //아이템갯수증가
                        int o = 0;
                        o = PlayerPrefs.GetInt("itemnum" + SetItemPref_i, 0);
                        PlayerPrefs.SetInt("inventorynum", a);
                        o++;
                        PlayerPrefs.SetInt("itemnum" + SetItemPref_i, o);


                        if (hel == 1)
                        {
                            PlayerPrefs.SetInt("inventorynum", (a - 1));
                        }
                    }
                }
            }
        }


        PlayerPrefs.SetInt("changeitem", 1);

        GMI.GetComponent<ItemGetMotion>().fade_obj.GetComponent<SpriteRenderer>().sprite = this.GetComponent<SpriteRenderer>().sprite;

        if (purple_b)
        {
            GMI.GetComponent<ItemGetMotion>().fade_obj.GetComponent<SpriteRenderer>().sprite = item_spr;
        }
        GMI.GetComponent<ItemGetMotion>().fade_obj.transform.position = this.transform.position;
        GMI.GetComponent<ItemGetMotion>().FadeItem();


        balloon_obj.SetActive(false);
        candy();
        if (dontdis_b)
        {

            this.gameObject.SetActive(false);
            if (PlayerPrefs.GetInt("itemnum27", 0) == 3)
            {
            }
        }
        else
        {
            DelThis();
            this.gameObject.SetActive(false);
        }
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
        if (a < 0)
        {
            a = 0;
        }
        PlayerPrefs.SetInt("inventorynum", a);
    }
    void SetDogam0()
    {
        if (PlayerPrefs.GetInt("canSeeMaterial" + animalNum_i, 0) == 0)
        {
            StopCoroutine("FadeIn");
            StartCoroutine("FadeIn");
        }
        PlayerPrefs.SetInt("showAnimal", animalNum_i); //0부터 해당 캐릭터 보여주기
        PlayerPrefs.SetInt("AmImet" + animalNum_i, 99); //캐릭터 만났는가 체크
        PlayerPrefs.SetInt("canSeeMaterial" + animalNum_i, 99); //퀘스트를 깼는가
    }

    void SetDogam1()
    {
        if (PlayerPrefs.GetInt("canSeeInfo_basic" + animalNum_i, 0) == 0)
        {
            StopCoroutine("FadeIn");
            StartCoroutine("FadeIn");
        }
        PlayerPrefs.SetInt("canSeeInfo_basic" + animalNum_i, 99); //퀘스트를 깼는가
    }
    void SetDogam2()
    {
        //PlayerPrefs.SetInt("showAnimal", animalNum_i); //0부터 해당 캐릭터 보여주기
        //PlayerPrefs.SetInt("AmImet" + animalNum_i, 99); //캐릭터 만났는가 체크
        //PlayerPrefs.SetInt("canSeeMaterial" + animalNum_i, 99); //퀘스트를 깼는가
        //PlayerPrefs.SetInt("canSeeInfo_detail" + animalNum_i, 0); //추가 퀘스트를 깼는가


        if (PlayerPrefs.GetInt("canSeeInfo_detail" + animalNum_i, 0) == 0)
        {
            StopCoroutine("FadeIn");
            StartCoroutine("FadeIn");
        }
        PlayerPrefs.SetInt("canSeeInfo_detail" + animalNum_i, 99); //퀘스트를 깼는가
    }
    void SetDogam3()
    {
        if (PlayerPrefs.GetInt("canSeeInfo_detailo" + animalNum_i, 0)==0)
        {
            StopCoroutine("FadeIn");
            StartCoroutine("FadeIn");
        }
        PlayerPrefs.SetInt("canSeeInfo_detailo" + animalNum_i, 99); //퀘스트를 깼는가
    }
    void SetDogam4()
    {
        if (PlayerPrefs.GetInt("canSeeInfo_detailt" + animalNum_i, 0) == 0)
        {
            StopCoroutine("FadeIn");
            StartCoroutine("FadeIn");
        }
        PlayerPrefs.SetInt("canSeeInfo_detailt" + animalNum_i, 99); //퀘스트를 깼는가
    }







    /// <summary>
    /// 이벤트값받아오고 진행처리해준다.
    /// </summary>
    public void EventSetting()
    {
        SetDogam0();
        SetDogam1();
        if (animalNum_i==8)
        {
            //SetDogam2();
        }
        int a = 0;
        a = PlayerPrefs.GetInt(SetEventPref_str, 0);
        k = a;


        if (PlayerPrefs.GetInt("selecteditemnum", 0) == 12)
        {
            if (esterEgg_b)
            {
                if (PlayerPrefs.GetInt("poped", 0) == 0)
                {
                    SGM.GetComponent<SoundEvt>().soundDamage();
                    this.gameObject.SetActive(false);
                    pop_obj.gameObject.SetActive(true);
                    BGM1.GetComponent<AudioSource>().mute = true;
                    BGM1.GetComponent<ForBGM>().BGM2.GetComponent<AudioSource>().mute = true;
                    stop_Ani.speed = 0f;
                    GMS.SetActive(false);
                    PlayerPrefs.SetInt("poped", 1);
                    //BGM1.GetComponent<ForBGM>().BGM2.GetComponent<AudioSource>().volume = 0f;
                    return;
                }
            }
        }
        //this.GetComponent<Animation>().Play();
        if (ani_str != "")
        {
            if (all_Ani == null)
            {
                this.GetComponent<Animator>().Play(aniTalk_str);
            }
            else
            {
                all_Ani.Play(aniTalk_str);
            }
        }

        if (sheep_b)
        {
            this.GetComponent<SpriteRenderer>().sprite = candy_spr;
            //NPC_sheep1.GetComponent<SpriteRenderer>().sprite = NPC_sheepSpr[1];
        }

        num = a;
        switch (EventNum_i[a])
        {
            case 0:
                break;
            case 1://말풍선띄우고 다음으로
                TalkSound();
                talkBall_obj.GetComponent<SpriteRenderer>().sprite = Event_spr[a];
                talkBallB_obj.SetActive(true);
                StopCoroutine("talkBall");
                StartCoroutine("talkBall");
                StopAndTalk();
                a++;


                if (animalNum_i == 4)
                {
                    if (PlayerPrefs.GetInt("canSeeInfo_detailo" + animalNum_i, 0) == 99)
                    {
                        SetDogam4();
                    }
                }



                if (animalNum_i == 0)
                {
                    if (PlayerPrefs.GetInt("canSeeInfo_detailo" + animalNum_i, 0) == 99)
                    {
                        SetDogam4();
                    }
                }
                break;
            case 2://말풍선 띄우고 아이템 요구
                TalkSound();
                talkBall_obj.GetComponent<SpriteRenderer>().sprite = Event_spr[a];
                talkBallB_obj.SetActive(true);
                StopCoroutine("talkBall");
                StartCoroutine("talkBall");
                break;
            case 3://대화 멈춤
                StopTalk();
                talkBallB_obj.SetActive(false);
                a++;
                if (animalNum_i == 8 && num >= 3)
                {
                    SetDogam3();
                }
                break;
            case 4://말풍선 띄우고 특수 아이템요구
                TalkSound();
                talkBall_obj.GetComponent<SpriteRenderer>().sprite = Event_spr[a];
                talkBallB_obj.SetActive(true);
                StopCoroutine("talkBall");
                StartCoroutine("talkBall");
                StopAndTalk();
                a++;
                if (PlayerPrefs.GetInt("selecteditemnum", 0) == giveItemPref_i)
                {
                    a++;
                    //SetDogam2();
                }
                break;
            case 5://대화 종료
                StopTalk();
                talkBallB_obj.SetActive(false);
                a--;

                if (PlayerPrefs.GetInt("bearbackmove", 0) == 1)
                {
                    if (bearmb)
                    {
                        StartCoroutine("BearR");
                    }
                }


                if (animalNum_i == 1)
                {
                    SetDogam2();
                }


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
            case 8://말풍선 띄우고 특수 아이템요구 아이템제거
                a++;
                if (PlayerPrefs.GetInt("selecteditemnum", 0) == 19)
                {
                    PlayerPrefs.SetInt("selecteditemnum", 18);
                }

                StopAndTalk();

                if (esterEgg_b)
                {

                    if (PlayerPrefs.GetInt("poped", 0) == 1)
                    {
                        if (PlayerPrefs.GetInt("selecteditemnum", 0) == 17)
                        {
                            SGM.GetComponent<SoundEvt>().soundItemSuccess();
                            bearColl_obj.SetActive(true);
                            StopTalk();

                            a++;
                            GMI.GetComponent<Inventory>().DelItems();
                            //SetDogam2();

                            if (stick_b)
                            { //stick_obj, makeBoad_obj;
                                makeBoad_obj.SetActive(true);
                            }
                            if (animalNum_i == 6)
                            {
                                SetDogam3();
                                SetDogam4();
                            }
                        }
                        else
                        {
                            SGM.GetComponent<SoundEvt>().soundItemFail();
                            StopTalk();
                            a--;
                        }
                    }
                    else
                    {
                        TalkSound();
                        if (PlayerPrefs.GetInt("selecteditemnum", 0) == giveItemPref_i)
                        {

                            a++;
                            GMI.GetComponent<Inventory>().DelItems();
                            //SetDogam2();

                            if (stick_b)
                            { //stick_obj, makeBoad_obj;
                                makeBoad_obj.SetActive(true);
                            }

                            if (animalNum_i == 6)
                            {
                                SetDogam3();
                                SetDogam4();
                            }
                        }
                    }
                }
                else
                {
                    TalkSound();
                    if (PlayerPrefs.GetInt("selecteditemnum", 0) == giveItemPref_i)
                    {
                        a++;
                        GMI.GetComponent<Inventory>().DelItems();
                        //SetDogam2();
                        /*
                        if (stick_b)
                        { //stick_obj, makeBoad_obj;
                            makeBoad_obj.SetActive(true);
                        }
                        */
                        if (animalNum_i == 6)
                        {
                            SetDogam3();
                            SetDogam4();
                        }
                    }

                }

                Debug.Log("awe" + a);
                StopCoroutine("talkBall");
                k = a;
                talkBall_obj.GetComponent<SpriteRenderer>().sprite = Event_spr[a];
                talkBallB_obj.SetActive(true);
                StartCoroutine("talkBall");



                break;
            case 9://말풍선 띄우고 특수 플레그 요구
                TalkSound();
                a++;
                if (PlayerPrefs.GetInt("" + SetItemPref_str, 0) == 1)
                {
                    a++;
                    //SetDogam2();
                }
                StopCoroutine("talkBall");
                k = a;
                talkBall_obj.GetComponent<SpriteRenderer>().sprite = Event_spr[a];
                talkBallB_obj.SetActive(true);
                StartCoroutine("talkBall");
                StopAndTalk();
                break;
            case 10://말풍선 두가지반복
                StopTalk();
                talkBallB_obj.SetActive(false);
                a--;
                a--;

                if (animalNum_i == 1)
                {
                    SetDogam4();
                }
                break;
            case 11://말풍선 띄우고 아이템 얻음
                TalkSound();
                talkBall_obj.GetComponent<SpriteRenderer>().sprite = Event_spr[a];
                talkBallB_obj.SetActive(true);
                StopCoroutine("talkBall");
                StartCoroutine("talkBall");
                StopAndTalk();
                a++;
                break;
            case 12://말풍선 띄우고 퀘스트 시작
                TalkSound();
                talkBall_obj.GetComponent<SpriteRenderer>().sprite = Event_spr[a];
                talkBallB_obj.SetActive(true);
                StopCoroutine("talkBall");
                StartCoroutine("talkBall");
                StopAndTalk();
                a++;
                PlayerPrefs.SetInt(SetItemPref_str, 1);
                break;
            case 13://말풍선 띄우고 퀘스트 시작
                TalkSound();
                talkBall_obj.GetComponent<SpriteRenderer>().sprite = Event_spr[a];
                talkBallB_obj.SetActive(true);
                StopCoroutine("talkBall");
                StartCoroutine("talkBall");
                StopAndTalk();
                a++;
                PlayerPrefs.SetInt(SetItemPref_str, 1);
                npc_obj[1].SetActive(true);
                npc_obj[0].SetActive(false);
                npc_obj[3].SetActive(true);
                npc_obj[2].SetActive(false);

                if (animalNum_i == 3)
                {
                    SetDogam2();
                }
                break;
            case 14://위 이동
                StopTalk();
                talkBallB_obj.SetActive(false);
                bearColl_obj.SetActive(false);
                a++;
                if (hidden_b)
                {
                    SetDogam4();
                    //PlayerPrefs.SetInt("canSeeInfo_detail" + animalNum_i, 99); //추가 퀘스트를 깼는가
                }
                else
                {

                    StartCoroutine("EventUp");
                }

                if (animalNum_i == 3)
                {
                    if (PlayerPrefs.GetInt("canSeeInfo_detailo" + animalNum_i, 0) == 99)
                    {
                        SetDogam4();
                    }
                }
                break;
            case 15://아이템 얻기
                ItemSettingOnEvents();
                talkBallB_obj.SetActive(false);
                a++;
                StopTalk();
                if (board_b)
                { //stick_obj, makeBoad_obj;
                    makeBoad_obj.SetActive(true);
                }
                if (animalNum_i==0)
                {
                    SetDogam3();
                }

                if (animalNum_i == 1)
                {
                    SetDogam3();
                }

                if (animalNum_i == 2)
                {
                    if (PlayerPrefs.GetInt("canSeeInfo_detail" + animalNum_i, 0) == 99)
                    {
                        SetDogam3();
                    }
                    SetDogam2();

                }


                if (animalNum_i == 4)
                {
                    if (PlayerPrefs.GetInt("canSeeInfo_detail" + animalNum_i, 0) == 99)
                    {
                        SetDogam3();
                    }
                    SetDogam2();
                }

                break;
            case 16://말풍선 띄우고 퀘스트 시작
                TalkSound();
                talkBall_obj.GetComponent<SpriteRenderer>().sprite = Event_spr[a];
                talkBallB_obj.SetActive(true);
                StopCoroutine("talkBall");
                StartCoroutine("talkBall");
                StopAndTalk();
                a++;
                PlayerPrefs.SetInt(SetItemPref_str, 1);
                break;
            case 17://애니메이션 재생
                StopTalk();
                talkBallB_obj.SetActive(false);
                bearColl_obj.SetActive(false);
                a++;

                //this.GetComponent<Animation>().Play();
                break;
            case 18://이동 오른쪽

                StopTalk();
                talkBallB_obj.SetActive(false);
                StartCoroutine("EventR");
                a++;
                bearColl_obj.SetActive(true);
                bearColl_obj.GetComponent<SpriteRenderer>().sprite = candy_spr;


                break;
            case 19://말풍선 띄우고 아이템 얻음
                TalkSound();
                talkBall_obj.GetComponent<SpriteRenderer>().sprite = Event_spr[a];
                talkBallB_obj.SetActive(true);
                StopCoroutine("talkBall");
                StartCoroutine("talkBall");
                ItemSettingOnEvents();
                StopAndTalk();
                a++;
                break;
            case 20://말풍선 띄우고 특수 아이템요구 아이템제거
                TalkSound();
                a++;
                if (PlayerPrefs.GetInt("selecteditemnum", 0) == giveItemPref_i)
                {
                    a++;
                    GMI.GetComponent<Inventory>().DelItems();
                    giveItemPref_i = 18;
                    SetItemPref_i = 21;
                    //SetDogam2();

                    if (stick_b)
                    {
                        stick_obj.SetActive(true);
                    }
                    if (animalNum_i == 7)
                    {
                        SetDogam2();
                    }
                }

                Debug.Log("awe" + a);
                StopCoroutine("talkBall");
                k = a;
                talkBall_obj.GetComponent<SpriteRenderer>().sprite = Event_spr[a];
                talkBallB_obj.SetActive(true);
                StartCoroutine("talkBall");
                StopAndTalk();
                break;
            case 21://말풍선띄우고 다음으로
                a++;
                TalkSound();
                talkBall_obj.GetComponent<SpriteRenderer>().sprite = Event_spr[a];
                talkBallB_obj.SetActive(true);
                StopCoroutine("talkBall");
                StartCoroutine("talkBall");
                StopAndTalk();
                break;
            case 22://말풍선띄우고 애니메이션 재생
                a++;
                if (PlayerPrefs.GetInt("selecteditemnum", 0) == giveItemPref_i)
                {
                    a++;
                    //SetDogam2();
                    crow_Ani.Play("ani_npc_crow_angry");

                    if (animalNum_i == 5)
                    {
                            SetDogam3();
                    }
                }
                else
                {

                    crow_Ani.Play("ani_npc_crow_talk");
                }
                TalkSound();
                talkBall_obj.GetComponent<SpriteRenderer>().sprite = Event_spr[a];
                if (PlayerPrefs.GetInt("selecteditemnum", 0) == giveItemPref_i)
                {
                    talkBall_obj.GetComponent<SpriteRenderer>().sprite = Event_spr[3];

                    k = 3;
                }
                talkBallB_obj.SetActive(true);
                StopCoroutine("talkBall");
                StartCoroutine("talkBall");
                StopAndTalk();
                break;
            case 23://까마귀 대화종료
                crow_Ani.Play("ani_npc_crow_sleep");
                StopTalk();
                talkBallB_obj.SetActive(false);
                a--;
                if (PlayerPrefs.GetInt("selecteditemnum", 0) == giveItemPref_i)
                {
                    talkBall_obj.GetComponent<SpriteRenderer>().sprite = Event_spr[3];
                    k = 3;
                }
                break;
            case 24://말풍선띄우고 다음으로
                crow_Ani.Play("ani_npc_crow_talk");
                TalkSound();
                talkBall_obj.GetComponent<SpriteRenderer>().sprite = Event_spr[a];
                if (PlayerPrefs.GetInt("selecteditemnum", 0) == giveItemPref_i)
                {
                    talkBall_obj.GetComponent<SpriteRenderer>().sprite = Event_spr[3];
                    k = 3;
                }
                talkBallB_obj.SetActive(true);
                StopCoroutine("talkBall");
                StartCoroutine("talkBall");
                StopAndTalk();
                a++;

                if (animalNum_i == 5)
                {
                    SetDogam2();
                }
                break;
            case 25://말풍선띄우고 다음으로
                a++;

                StopAndTalk();
                TalkSound();
                if (PlayerPrefs.GetInt("selecteditemnum", 0) == giveItemPref_i)
                {
                    a++;
                    GMI.GetComponent<Inventory>().DelItems();
                    //SetDogam2();
                    PlayerPrefs.SetInt("foxq", 1);
                }

                Debug.Log("awe" + a);
                StopCoroutine("talkBall");
                k = a;
                talkBall_obj.GetComponent<SpriteRenderer>().sprite = Event_spr[a];
                talkBallB_obj.SetActive(true);
                StartCoroutine("talkBall");

                if (animalNum_i == 8)
                {
                    SetDogam2();
                }


                break;
            case 26://말풍선 띄우고 특수 아이템요구 아이템제거
                a++;
                if (PlayerPrefs.GetInt("selecteditemnum", 0) == 19)
                {
                    PlayerPrefs.SetInt("selecteditemnum", 18);
                }

                StopAndTalk();
                
                    TalkSound();
                    if (PlayerPrefs.GetInt("selecteditemnum", 0) == giveItemPref_i)
                    {
                        a++;
                        GMI.GetComponent<Inventory>().DelItems();
                        //SetDogam2();
                    /*
                    if (stick_b)
                    { //stick_obj, makeBoad_obj;
                        makeBoad_obj.SetActive(true);
                    }
                    */
                    PlayerPrefs.SetInt("bearbackmove", 0);
                }
                else
                {
                    PlayerPrefs.SetInt("bearbackmove",1);
                }

                Debug.Log("awe" + a);
                StopCoroutine("talkBall");
                k = a;
                talkBall_obj.GetComponent<SpriteRenderer>().sprite = Event_spr[a];
                talkBallB_obj.SetActive(true);
                StartCoroutine("talkBall");


                break;
            case 27://솜사탕 미니 퍼즐
                miniGame_obj.SetActive(true);
                StopAndTalk();
                break;
            default:
                break;


            case 28://말풍선 띄우고 특수 아이템요구 아이템제거 8
                a++;

                if (animalNum_i == 6)
                {
                        SetDogam2();
                }
                if (PlayerPrefs.GetInt("selecteditemnum", 0) == 19)
                {
                    PlayerPrefs.SetInt("selecteditemnum", 18);
                }

                StopAndTalk();

                if (esterEgg_b)
                {

                    if (PlayerPrefs.GetInt("poped", 0) == 1)
                    {
                        if (PlayerPrefs.GetInt("selecteditemnum", 0) == 17)
                        {
                            SGM.GetComponent<SoundEvt>().soundItemSuccess();
                            bearColl_obj.SetActive(true);
                            StopTalk();

                            a++;
                            GMI.GetComponent<Inventory>().DelItems();
                            //SetDogam2();

                            if (stick_b)
                            { //stick_obj, makeBoad_obj;
                                makeBoad_obj.SetActive(true);
                            }
                            if (animalNum_i == 6)
                            {
                                SetDogam3();
                                SetDogam4();
                            }
                        }
                        else
                        {
                            SGM.GetComponent<SoundEvt>().soundItemFail();
                            StopTalk();
                            a--;
                        }
                    }
                    else
                    {
                        TalkSound();
                        if (PlayerPrefs.GetInt("selecteditemnum", 0) == giveItemPref_i)
                        {

                            a++;
                            a++;
                            GMI.GetComponent<Inventory>().DelItems();
                            //SetDogam2();

                            if (stick_b)
                            { //stick_obj, makeBoad_obj;
                                makeBoad_obj.SetActive(true);
                            }
                            if (animalNum_i == 7)
                            {
                                SetDogam3();
                                SetDogam4();
                            }
                            if (animalNum_i == 6)
                            {
                                SetDogam3();
                                SetDogam4();
                            }
                        }
                    }
                }
                else
                {
                    TalkSound();
                    if (PlayerPrefs.GetInt("selecteditemnum", 0) == giveItemPref_i)
                    {
                        a++;
                        a++;
                        GMI.GetComponent<Inventory>().DelItems();
                        //SetDogam2();
                        /*
                        if (stick_b)
                        { //stick_obj, makeBoad_obj;
                            makeBoad_obj.SetActive(true);
                        }
                        */
                        if (animalNum_i == 7)
                        {
                            SetDogam3();
                            SetDogam4();
                        }
                        if (animalNum_i == 6)
                        {
                            SetDogam3();
                            SetDogam4();
                        }
                    }

                }

                Debug.Log("awe" + a);
                StopCoroutine("talkBall");
                k = a;
                talkBall_obj.GetComponent<SpriteRenderer>().sprite = Event_spr[a];
                talkBallB_obj.SetActive(true);
                StartCoroutine("talkBall");


                break;

            case 29://말풍선 띄우고 특수 플레그 요구
                TalkSound();
                a++;
                if (PlayerPrefs.GetInt("" + SetItemPref_str, 0) == 1)
                {
                    a++;
                    a++;
                    //SetDogam2();
                }
                StopCoroutine("talkBall");
                k = a;
                talkBall_obj.GetComponent<SpriteRenderer>().sprite = Event_spr[a];
                talkBallB_obj.SetActive(true);
                StartCoroutine("talkBall");
                StopAndTalk();
                break;

            case 30://말풍선 띄우고 특수 아이템요구 아이템제거20
                TalkSound();
                a++;
                if (PlayerPrefs.GetInt("selecteditemnum", 0) == giveItemPref_i)
                {
                    a++;
                    a++;
                    GMI.GetComponent<Inventory>().DelItems();
                    giveItemPref_i = 18;
                    SetItemPref_i = 21;
                    //SetDogam2();

                    if (stick_b)
                    {
                        stick_obj.SetActive(true);
                    }

                    if (animalNum_i == 7)
                    {
                        SetDogam2();
                    }
                }

                Debug.Log("awe" + a);
                StopCoroutine("talkBall");
                k = a;
                talkBall_obj.GetComponent<SpriteRenderer>().sprite = Event_spr[a];
                talkBallB_obj.SetActive(true);
                StartCoroutine("talkBall");
                StopAndTalk();
                break;
        }
        PlayerPrefs.SetInt(SetEventPref_str, a);
    }

    public void StopAndTalk()
    {
        PlayerPrefs.SetInt("nowtalk", 1);
        GM.GetComponent<CharMove>().canMove = false;

    }

    void TalkSound()
    {
        SGM.GetComponent<SoundEvt>().auSE.GetComponent<AudioSource>().pitch = 1f;
        if (purple_b)
        {
            SGM.GetComponent<AudioSource>().pitch = 0.7f;
            SGM.GetComponent<SoundEvt>().soundTalk();
        }
        if (soundLow_b)
        {
            SGM.GetComponent<SoundEvt>().soundTalkLow();
        }
        else
        {
            SGM.GetComponent<SoundEvt>().soundTalk();
        }

        if (esterEgg_b)
        {

            if (PlayerPrefs.GetInt("poped", 0) == 1)
            {
                if (PlayerPrefs.GetInt("selecteditemnum", 0) == 17)
                {
                    SGM.GetComponent<SoundEvt>().soundItemSuccess();
                    bearColl_obj.SetActive(true);
                    StopTalk();

                }
                else
                {
                    SGM.GetComponent<SoundEvt>().soundItemFail();
                    StopTalk();
                }
            }
        }

    }


    public void StopTalk()
    {

        GM.GetComponent<CharMove>().canMove = true;


        if (ani_str != "")
        {
            if (all_Ani == null)
            {
                this.GetComponent<Animator>().Play(ani_str);
            }
            else
            {
                all_Ani.Play(ani_str);
            }
        }
        Debug.Log("a" + ani_str);


        if (sheep_b)
        {
            this.GetComponent<SpriteRenderer>().sprite = ori_spr;
        }

        PlayerPrefs.SetInt("nowtalk", 0);
    }

    void candy()
    {
        if (broken_b)
        {
            candyBar_obj.GetComponent<SpriteRenderer>().sprite = candy_spr;
            SGM.GetComponent<SoundEvt>().auSE.GetComponent<AudioSource>().pitch = 1f;
            SGM.GetComponent<SoundEvt>().soundDamage();
        }

    }



    /// <summary>
    /// 아이템값받아오고 인벤토리에넣는다.
    /// </summary>
    void ItemSettingOnEvent()
    {

        SGM.GetComponent<AudioSource>().pitch = 1f;
        SGM.GetComponent<SoundEvt>().soundItemSuccess();
        int a = 0;
        a = PlayerPrefs.GetInt("inventorynum", 0);
        PlayerPrefs.SetInt("itemgetpoint", a);
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

                Debug.Log("aaaaaaa" + SetItemPref_i);
                PlayerPrefs.SetInt("inventoryget" + k, 6);
                if (SetItemPref_i == 8)
                {
                    PlayerPrefs.SetInt("inventoryget" + k, 9);
                }
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

                    if (GMI.GetComponent<Inventory>().items_i[k] == 8)
                    {

                        Debug.Log(GMI.GetComponent<Inventory>().items_i[k]);
                        PlayerPrefs.SetInt("inventoryget" + k, 9);
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
        if (hel == 1)
        {
            PlayerPrefs.SetInt("inventorynum", (a - 1));
        }



        GMI.GetComponent<ItemGetMotion>().fade_obj.GetComponent<SpriteRenderer>().sprite = item_spr;
        GMI.GetComponent<ItemGetMotion>().fade_obj.transform.position = this.transform.position;
        GMI.GetComponent<ItemGetMotion>().FadeItem();
    }



    void ItemSettingOnEvents()
    {

        SGM.GetComponent<AudioSource>().pitch = 1f;
        int a = 0;
        //빈공간저장하기
        a = PlayerPrefs.GetInt("itemgetpoint", 0);
        //소리
        SGM.GetComponent<SoundEvt>().soundItemSuccess();


        int hel = 0;


        Debug.Log("iiiiiiiiiiihelp" + PlayerPrefs.GetInt("fillpotint", 0));

        for (int i = 0; i < PlayerPrefs.GetInt("fillpotint", 0); i++)
        {
            if (GMI.GetComponent<Inventory>().items_i[i] == 11)
            {
                Debug.Log(PlayerPrefs.GetInt("inventoryget" + i, 0));
                PlayerPrefs.SetInt("inventoryget" + i, 6);
                PlayerPrefs.SetInt("itemnum" + 6, 1);
                GMI.GetComponent<Inventory>().items_i[i] = 6;


                Debug.Log("iiiiiiiiiiihelp" + SetItemPref_i);
                if (SetItemPref_i == 8)
                {

                    Debug.Log("iiiiiiiiiiihelp" + i);
                    PlayerPrefs.SetInt("inventoryget" + i, 9);
                    PlayerPrefs.SetInt("itemnum" + 9, 1);
                    GMI.GetComponent<Inventory>().items_i[i] = 9;
                }
                hel = 1;
            }
            else
            {
                if (GMI.GetComponent<Inventory>().items_i[i] == 5)
                {
                    Debug.Log(PlayerPrefs.GetInt("inventoryget" + i, 0));
                    PlayerPrefs.SetInt("inventoryget" + i, 6);
                    PlayerPrefs.SetInt("itemnum" + 6, 1);
                    GMI.GetComponent<Inventory>().items_i[i] = 6;
                    hel = 1;
                }
                else
                {


                }
            }

            if (GMI.GetComponent<Inventory>().items_i[i] == 8)
            {
                PlayerPrefs.SetInt("inventoryget" + i, 9);
                PlayerPrefs.SetInt("itemnum" + 9, 1);
                GMI.GetComponent<Inventory>().items_i[i] = 9;
                hel = 1;
            }
        }
        

        //if (PlayerPrefs.GetInt("fillpotint", 0) == 0)
        //{



        if (hel == 1)
        {
            PlayerPrefs.SetInt("inventorynum", (a - 1));


        }
        else
        {
            //a번칸에 값저장
            PlayerPrefs.SetInt("inventoryget" + a, SetItemPref_i);
            PlayerPrefs.SetInt("changeitem", 1);
            a++;
            if (PlayerPrefs.GetInt("fillpotint", 0) < a)
            {
                PlayerPrefs.SetInt("fillpotint", a);
            }

            PlayerPrefs.SetInt("itemgetpoint", a);

            //아이템갯수증가
            int o = 0;
            o = PlayerPrefs.GetInt("itemnum" + SetItemPref_i, 0);
            PlayerPrefs.SetInt("inventorynum", a);
            o++;
            PlayerPrefs.SetInt("itemnum" + SetItemPref_i, o);
        }

        if (PlayerPrefs.GetInt("inventoryget" + (a + 1), 0) > 0)
        {
            PlayerPrefs.SetInt("itemgetpoint", (PlayerPrefs.GetInt("fillpotint", 0) + 1));
        }
        //}


        if (PlayerPrefs.GetInt("itemnum" + 11, 0) == 2)
        {
            PlayerPrefs.SetInt("inventoryget" + (a-1), 11);
            PlayerPrefs.SetInt("itemnum" + 11, 1);
            GMI.GetComponent<Inventory>().items_i[(a-1)] = 11;
            PlayerPrefs.SetInt("inventorynum", (a-1));
        }

        PlayerPrefs.SetInt("changeitem", 1);

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
            if (s == 0)
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
            position0.y = position0.y + 5f * Time.deltaTime;
            transform.position = position0;

            if (position0.y >= move_obj.transform.position.y)
            {
                in_i = 0;
            }

            yield return new WaitForSeconds(0.01f);
        }
        talk_b = true;

        SetQuest();

        if (animalNum_i == 3)
        {
            SetDogam3();
        }
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
            position0.y = position0.y - 5f * Time.deltaTime;
            transform.position = position0;

            if (position0.y <= move_obj.transform.position.y)
            {
                in_i = 0;
            }

            yield return new WaitForSeconds(0.01f);
        }
        talk_b = true;
        GM.GetComponent<CharMove>().canMove = true;
        if (animalNum_i==0)
        {
            SetDogam2();
        }
    }



    /// <summary>
    /// 오른쪽 이동
    /// </summary>
    /// <returns></returns>
    IEnumerator EventR()
    {
        balloon_obj.SetActive(true);
        GM.GetComponent<CharMove>().canMove = false;
        talk_b = false;
        int in_i = 1;
        position0 = moveOther_obj.transform.position;
        SGM.GetComponent<SoundEvt>().soundOpenObject();
        while (in_i == 1)
        {
            position0.x = position0.x + 4f * Time.deltaTime;
            moveOther_obj.transform.position = position0;

            if (position0.x >= move_obj.transform.position.x)
            {
                in_i = 0;
            }

            yield return new WaitForSeconds(0.01f);
        }
        talk_b = true;
        other_obj.SetActive(false);

        GM.GetComponent<CharMove>().canMove = true;

        if (PlayerPrefs.GetInt("poped", 0) == 1)
        {
            this.gameObject.SetActive(false);
        }
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


    void DistoryWood()
    {

    }

    /// <summary>
    /// 히든퀘스트 시작
    /// </summary>
    void SetQuest()
    {
        q4_obj.transform.position = new Vector2(o4_obj.transform.position.x, q4_obj.transform.position.y);
        q1_obj.SetActive(true);
        q2_obj.SetActive(true);
        q3_obj.SetActive(true);
        q4_obj.SetActive(true);
        o1_obj.SetActive(false);
        o2_obj.SetActive(false);
        o3_obj.SetActive(false);
        o4_obj.SetActive(false);
    }

    /// <summary>
    /// 곰뒤로밀치기
    /// </summary>
    void SetMoveBack()
    {

    }


    /// <summary>
    /// 밀치기
    /// </summary>
    /// <returns></returns>
    IEnumerator EventBack() //주인공이 밀려가는시간
    {

        PlayerPrefs.SetInt("bearbackmove", 0);
        GM.GetComponent<CharMove>().canMove = false;
        //talk_b = false;
        int in_i = 1;
        position0 = player_obj.transform.position;
        
        while (in_i == 1)
        {
            position0.x = position0.x - 8f * Time.deltaTime;  //숫자가 작을수록 느리고 클수록 빠름
            player_obj.transform.position = position0;

            if (position0.x <= playerPos_obj.transform.position.x)
            {
                in_i = 0;
            }

            yield return new WaitForSeconds(0.01f);
        }
        //talk_b = true;
        GM.GetComponent<CharMove>().canMove = true;

    }
    IEnumerator BearL()  //곰이 돌진하는 시간
    {
        //talk_b = false;
        int in_i = 1;
        position0 = bearM_obj.transform.position;

        yield return new WaitForSeconds(0.4f); //곰딜레이
        while (in_i == 1)
        {
            position0.x = position0.x - 10f * Time.deltaTime; //10f 무빙속도
            bearM_obj.transform.position = position0;

            if (position0.x <= b_position.x)
            {
                in_i = 0;
            }

            yield return new WaitForSeconds(0.01f);
        }
        StartCoroutine("EventBack");
        SGM.GetComponent<SoundEvt>().auSE.GetComponent<AudioSource>().pitch = 1f;
        SGM.GetComponent<SoundEvt>().soundBearPop();
    }
    IEnumerator BearR()  //곰이 뒷걸음치는 시간
    {
        StopTalk();
        talkBallB_obj.SetActive(false);
        b_position = bearM_obj.transform.position;
        GM.GetComponent<CharMove>().canMove = false;
        //talk_b = false;
        int in_i = 1;
        position0 = bearM_obj.transform.position;

        while (in_i == 1)
        {
            position0.x = position0.x + 10f * Time.deltaTime; //10f 무빙속도
            bearM_obj.transform.position = position0;

            if (position0.x >= bbPos_obj.transform.position.x)
            {
                in_i = 0;
            }

            yield return new WaitForSeconds(0.01f);
        }

        StartCoroutine("BearL");
    }


    void ShowBulb()
    {

    }


    IEnumerator FadeIn()
    {

        GM.GetComponent<CharMove>().bulb_obj.SetActive(true);
        SGM2.GetComponent<SoundEvt>().soundStart();
        int in_i = 1;
        color = new Color(1f, 1f, 1f);
        color.a = 1f;
        GM.GetComponent<CharMove>().bulb_obj.GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(1.7f);
        while (in_i == 1)
        {
            float i_f = 1f;
            for (i_f = 1f; i_f > 0f; i_f -= 0.05f)
            {
                color.a = Mathf.Lerp(0f, 1f, i_f);
                GM.GetComponent<CharMove>().bulb_obj.GetComponent<SpriteRenderer>().color = color;
                yield return new WaitForSeconds(0.01f);
            }
            //yield return new WaitForSeconds(2f);
            in_i = 0;
            GM.GetComponent<CharMove>().bulb_obj.SetActive(false);
        }
        GM.GetComponent<CharMove>().bulb_obj.SetActive(false);
        
    }
}
