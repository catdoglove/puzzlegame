using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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


    public Vector3 position0, position_fox, position_nomal;
    public GameObject move_obj, moveOther_obj;
    public GameObject[] npc_obj;


    /// <summary>
    /// 말중간에다른 상호작용금지
    /// </summary>
    public bool talk_b = true;
    int wait = 0;
    int wait2 = 0;


    Color color;
    public GameObject fade_obj;
    public float moveY, moveX;
    Vector2 mouseDragPos;
    public Vector2 wldObjectPos;
    public Sprite item_spr;



    public GameObject SGM, SGM2;

    public bool purple_b, soundLow_b, soundLow2_b;


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

    public bool esterEgg_b, sheep_b, hidden_b, dontdis_b, function_b, bearmb, donfalse_b,event_b,scFalse_b;

    public GameObject BGM1, pop_obj;
    public Animator stop_Ani;

    public int num;

    public Sprite ori_spr;


    public GameObject q1_obj, q2_obj, q3_obj, q4_obj, o1_obj, o2_obj, o3_obj, o4_obj;

    public GameObject player_obj, playerPos_obj;

    public GameObject bbPos_obj, bearM_obj;
    public Vector3 b_position;

    public GameObject miniGame_obj;

    public bool dogam_b, fox_b;


    public float checkX_f, checkY_f, checkR_f;

    public GameObject hallFix_obj, hall_obj;

    public int events_i=0;

    int ok = 0;

    public Sprite[] items_spr;



    public int cut_i = 0;



    public Sprite[] cutS_spr;
    public int dr_i;
    public GameObject ori_obj, scene_obj;
    public GameObject cutS_obj;
    public int w_i=0;

    private void OnEnable()
    {
        GM.GetComponent<CharMove>().bulb_obj.SetActive(false);
        //StartCoroutine("Checking");


        position_fox = new Vector3(transform.position.x - 2.5f, transform.position.y, transform.position.z);
        position_nomal = new Vector3(transform.position.x - checkX_f, transform.position.y - checkY_f, transform.position.z);



        if (events_i == 1293)
        {
            SetDogam0();
            SetDogam4();
        }

        if (events_i == 1294)
        {
            SetDogam3();

        }



        if (events_i == 1193 && PlayerPrefs.GetInt("killrat", 0) == 1)
        {

            if (PlayerPrefs.GetInt("helprat", 0) == 1)
            {
                SetDogam0();
                SetDogam3();
                SetDogam4h();
            }
        }

        if (events_i == 1192&& PlayerPrefs.GetInt("meetrat", 0) == 0)
        {

            if (PlayerPrefs.GetInt("helprat", 0) == 1)
            {
                if (PlayerPrefs.GetInt("killrat", 0) == 1)
                {
                    //SetDogam0();
                    //SetDogam3();
                    //SetDogam4h();
                }
                else
                {
                    SetDogam0();
                    SetDogam3();
                    SetDogam4();
                    PlayerPrefs.SetInt("meetrat", 1);
                }
            }
        }

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
        if (fox_b)
        {
            position_fox = new Vector3(transform.position.x - 2.5f, transform.position.y, transform.position.z);
            Gizmos.DrawWireCube(position_fox, size);
        }
        else
        {
            //position_nomal = new Vector3(transform.position.x - checkX_f, transform.position.y - checkY_f, transform.position.z);
            Gizmos.DrawWireCube(position_nomal, size);
        }
    }

    private void Update()
    {

        if (PlayerPrefs.GetInt("bhelpon", 0) == 1&&events_i==2727)
        {
            SetDogam2();
            SetDogam3();
            PlayerPrefs.SetInt("bhelpon", 0);
        }

        wait = PlayerPrefs.GetInt("wait", 0);
        if (wait == 0&& wait2==0)
        {
            Collider2D hit;
            if (fox_b)
            {
                hit = Physics2D.OverlapBox(position_fox, size, 0, whatIsLayer);
            }
            else
            {
                hit = Physics2D.OverlapBox(position_nomal, size, checkR_f, whatIsLayer);
            }
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

            if (SetItemPref_i >= 50 && SetItemPref_i <= 55)
            {
                int a= PlayerPrefs.GetInt("stackdish",0);
                a++;
                PlayerPrefs.SetInt("stackdish", a);
            }

            if (function_b)
            {

                SGM.GetComponent<SoundEvt>().soundItemUse();
                talkBall_obj.SetActive(true);
                balloon_obj.SetActive(false);
                this.gameObject.SetActive(false);
            }
            else
            {
                if (events_i == 8)
                {
                    move_obj.SetActive(true);
                }
                if (events_i == 9)
                {
                    if (PlayerPrefs.GetInt("cats2", 0) == 0)
                    {
                        color = new Color(1f, 1f, 1f, 1f);
                        move_obj.GetComponent<SpriteRenderer>().color = color;
                        move_obj.GetComponent<CheckPlayer>().wait2 = 0;
                        PlayerPrefs.SetInt("sss", 1);
                        //move_obj.GetComponent<CheckPlayer>().all_Ani.Play("ani_npc_cat_forest");
                        //move_obj.GetComponent<CheckPlayer>().StopTalk();
                    }
                    else
                    {
                        color = new Color(1f, 1f, 1f, 1f);
                        moveOther_obj.GetComponent<SpriteRenderer>().color = color;
                        moveOther_obj.GetComponent<CheckPlayer>().wait2 = 0;
                        PlayerPrefs.SetInt("sss", 1);
                        //fade_obj.GetComponent<SpriteRenderer>().color = color;
                        //moveOther_obj.GetComponent<CheckPlayer>().all_Ani.Play("ani_npc_cat_forest");
                        //moveOther_obj.GetComponent<CheckPlayer>().StopTalk();
                    }
                }
                ItemSettings();
            }
            //ItemSettingOnEvents();
        }
        else
        {
            if (talk_b)
            {
                if (cut_i>0)
                {

                }
                else
                {
                    EventSetting();
                }
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
    public void ItemSettings()
    {
        if (PlayerPrefs.GetInt("setselectone", 0) == 0)
        {
            move_obj.SetActive(true);
            PlayerPrefs.SetInt("setselectone", 1);
        }

        int a = 0;
        //빈공간저장하기
        a = PlayerPrefs.GetInt("itemgetpoint", 0);

        for (int i = 0; i < 8; i++)
        {
            if (GMI.GetComponent<Inventory>().items_i[i] == 0)
            {
                a = 0 + i;

                i = 10;
            }
        }




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

                    if ((PlayerPrefs.GetInt("itemnum" + 30, 0) == 1 || PlayerPrefs.GetInt("itemnum" + 30, 0) == 2 || PlayerPrefs.GetInt("itemnum" + 30, 0) == 3) && SetItemPref_i == 30)
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


        //Debug.Log("a" + GMI.GetComponent<Inventory>().selectedNow_i);
        if (GMI.GetComponent<Inventory>().selectedNow_i < 0)
        {

            if (a <= 0)
            {

            }
            else
            {
                if (SetItemPref_i == 13 || SetItemPref_i == 30)
                {
                    if (PlayerPrefs.GetInt("itemnum" + SetItemPref_i, 0) <= 1)
                    {
                        GMI.GetComponent<Inventory>().selected_i = a-1;
                        PlayerPrefs.SetInt("selectN", 1);
                    }
                }
                else
                {
                    GMI.GetComponent<Inventory>().selected_i = a-1;
                    PlayerPrefs.SetInt("selectN", 1);
                }
            }
            //Debug.Log("a" + GMI.GetComponent<Inventory>().selected_i);
            //GMI.GetComponent<Inventory>().CallSelectItem();
        }


        PlayerPrefs.SetInt("changeitem", 1);

        GMI.GetComponent<ItemGetMotion>().fade_obj.GetComponent<SpriteRenderer>().sprite = this.GetComponent<SpriteRenderer>().sprite;

        if (purple_b)
        {
            GMI.GetComponent<ItemGetMotion>().fade_obj.GetComponent<SpriteRenderer>().sprite = item_spr;
        }
        if (donfalse_b)
        {
            GMI.GetComponent<ItemGetMotion>().fade_obj.GetComponent<SpriteRenderer>().sprite = item_spr;
        }
        GMI.GetComponent<ItemGetMotion>().fade_obj.transform.position = this.transform.position;
        GMI.GetComponent<ItemGetMotion>().FadeItem();


        balloon_obj.SetActive(false);
        candy();
        if (donfalse_b)
        {

        }
        else
        {
            if (dontdis_b)
            {

                this.gameObject.SetActive(false);
                if (PlayerPrefs.GetInt("itemnum27", 0) == 3)
                {
                }
            }
            else
            {
                if (dogam_b)
                {

                }
                else
                {
                    DelThis();
                    this.gameObject.SetActive(false);
                }
            }
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


            if (events_i == 1294)
            {
                StopCoroutine("FadeIn2");
                StartCoroutine("FadeIn2");
            }

            PlayerPrefs.SetInt("canSeeInfo_detailo" + animalNum_i, 99); //퀘스트를 깼는가
        }
    }

    void SetDogam3h()
    {
        if (PlayerPrefs.GetInt("canSeeInfo_detailo" + animalNum_i, 0) == 0)
        {
            //StopCoroutine("FadeIn");
            //StartCoroutine("FadeIn");
            if (animalNum_i==9)
            {
                StopCoroutine("FadeIn");
                StartCoroutine("FadeIn");
            }
        }

        PlayerPrefs.SetInt("canSeeInfo_detailo" + animalNum_i, 98); //퀘스트를 깼는가
        
    }
    void SetDogam4()
    {
        if (PlayerPrefs.GetInt("canSeeInfo_detailt" + animalNum_i, 0) == 0)
        {
            StopCoroutine("FadeIn");
            StartCoroutine("FadeIn");
            PlayerPrefs.SetInt("canSeeInfo_detailt" + animalNum_i, 99); //퀘스트를 깼는가
        }
    }
    void SetDogam4h()
    {
        if (PlayerPrefs.GetInt("canSeeInfo_detailt" + animalNum_i, 0) == 0)
        {
            //StopCoroutine("FadeIn");
            //StartCoroutine("FadeIn");
        }
        PlayerPrefs.SetInt("canSeeInfo_detailt" + animalNum_i, 98); //퀘스트를 깼는가
        if (animalNum_i==6)
        {
            PlayerPrefs.SetInt("canSeeInfo_detailt" + 7, 98);
        }
    }


    void SetDogam5()
    {

        PlayerPrefs.SetInt("canSeeInfo_detailo" + animalNum_i, 99); //퀘스트를 깼는가
        
    }





    /// <summary>
    /// 이벤트값받아오고 진행처리해준다.
    /// </summary>
    public void EventSetting()
    {
        if (dogam_b)
        {

        }
        else
        {
            SetDogam0();
            SetDogam1();
        }
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

                    SetDogam3h();
                    SetDogam4h();
                    return;
                }
            }
        }


        scFalse_b = false;

        if (animalNum_i == 9 && PlayerPrefs.GetInt("selecteditemnum", 0) == 41)
        {
            scFalse_b = true;
        }

        //this.GetComponent<Animation>().Play();
        if (ani_str != "")
        {
            if (all_Ani == null)
            {
                this.GetComponent<Animator>().Play(aniTalk_str);
                //Debug.Log("aaa" + aniTalk_str);
            }
            else
            {

                if (scFalse_b)
                {
                }
                else
                {
                    all_Ani.Play(aniTalk_str);
                }
            }
        }

        if (sheep_b)
        {
            this.GetComponent<SpriteRenderer>().sprite = candy_spr;
            //NPC_sheep1.GetComponent<SpriteRenderer>().sprite = NPC_sheepSpr[1];
        }

        num = a;

        PlayerPrefs.SetInt("aplus", 0);



        if (scFalse_b)
        {

            all_Ani.Play("ani_npc_cat_forest_danger");
            if (PlayerPrefs.GetInt("poped", 0) == 1)
            {
                SetDogam4h();
            }
            else
            {
                SetDogam4();
            }
            SGM.GetComponent<SoundEvt>().soundItemFail();
            Invoke("danger", 0.1f);
        }
        else
        {
            
            
            switch (EventNum_i[a])
            {
                case 0:
                    break;
                case 1://말풍선띄우고 다음으로
                    if (animalNum_i==8&& PlayerPrefs.GetInt("selecteditemnum", 0) == 49)
                    {
                        if (a>2)
                        {
                            Event_spr[a] = Event_spr[8];
                            Event2_spr[a] = Event2_spr[8];
                            a = 8;
                            GMI.GetComponent<Inventory>().DelItems();
                            SetDogam4();
                        }
                    }

                    if (animalNum_i == 9 && PlayerPrefs.GetInt("selecteditemnum", 0) == giveItemPref_i)
                    {
                        if (num > 0)
                        {
                            Event_spr[a] = Event_spr[(a + 1)];
                            Event2_spr[a] = Event2_spr[(a + 1)];
                        }
                        if (events_i == 2)
                        {
                            Event_spr[a] = Event_spr[(a + 1)];
                            Event2_spr[a] = Event2_spr[(a + 1)];
                        }

                    }

                    if (animalNum_i == 11 && PlayerPrefs.GetInt("selecteditemnum", 0) == giveItemPref_i)
                    {
                        Event_spr[a] = Event_spr[(a + 4)];
                        Event2_spr[a] = Event2_spr[(a + 4)];

                        moveOther_obj.SetActive(true);

                        color = new Color(1f, 1f, 1f, 0f);
                        this.GetComponent<SpriteRenderer>().color = color;
                    }


                    if (SetItemPref_i == 45 && PlayerPrefs.GetInt("selecteditemnum", 0) == 42)
                    {
                        PlayerPrefs.SetInt("aplus", 1);
                    }
                    if (SetItemPref_i == 38 && PlayerPrefs.GetInt("selecteditemnum", 0) == 42)
                    {
                        PlayerPrefs.SetInt("aplus", 1);
                    }



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


                    if (animalNum_i == 11 && events_i == 1)
                    {
                        SetDogam4();
                    }

                    if (animalNum_i == 10)
                    {
                        SetDogam2();
                    }

                    if (animalNum_i == 14)
                    {
                        SetDogam0();
                        SetDogam1();
                        SetDogam2();
                    }

                    if (animalNum_i == 13)
                    {

                        SetDogam0();
                    }

                    if (events_i==119)
                    {
                        npc_obj[0].GetComponent<SpriteRenderer>().sprite= items_spr[0];
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
                    talk_b = false;
                    StartCoroutine("TalkBOff");
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

                    talk_b = false;
                    StartCoroutine("TalkBOff");

                    if (events_i == 5 && animalNum_i == 10)
                    {
                        StopCoroutine("TalkBOff");
                        PlayerPrefs.SetInt("escdont", 0);
                        this.gameObject.SetActive(false);
                        move_obj.SetActive(true);
                    }

                    if (events_i == 119)
                    {
                        npc_obj[0].GetComponent<SpriteRenderer>().sprite = items_spr[1];
                    }


                    if (events_i == 833)
                    {
                        moveOther_obj.SetActive(true);
                        this.gameObject.SetActive(false);
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
                                    //SetDogam3();
                                    //SetDogam4();

                                    SetDogam3h();
                                    SetDogam4h();
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

                    if (animalNum_i == 1 && SetItemPref_i == 8)
                    {
                        SetDogam4();
                    }

                    if (events_i == 3 && ok == 1)
                    {/*
                    StopCoroutine("talkBall");
                    move_obj.SetActive(true);
                    fade_obj.SetActive(false);
                    Invoke("SetB", 15f);
                    StopTalk();
                    talkBallB_obj.SetActive(false);
                    */
                    }
                    else
                    {
                        talk_b = false;
                        StartCoroutine("TalkBOff");
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
                    /*
                    if (animalNum_i == 3)
                    {
                        if (PlayerPrefs.GetInt("canSeeInfo_detailo" + animalNum_i, 0) == 99)
                        {
                            SetDogam4();
                        }
                    }
                    */
                    break;
                case 15://아이템 얻기
                    if (donfalse_b)
                    {
                        if (animalNum_i==7)
                        {
                            cutS_obj.GetComponent<SpriteRenderer>().sprite = cutS_spr[0];
                            cutS_obj.SetActive(true);
                            if (dr_i==1)
                            {
                                cutS_obj.SetActive(false);
                                ItemSettings();
                                a++;
                                StopTalk();
                            }
                        }
                        else
                        {
                            ItemSettings();
                        }
                    }
                    else
                    {
                        ItemSettingOnEvents();
                    }
                    talkBallB_obj.SetActive(false);

                    if (animalNum_i == 7)
                    {
                        dr_i = 1;
                    }
                    else
                    {
                        a++;
                        StopTalk();
                    }
                    if (board_b)
                    { //stick_obj, makeBoad_obj;
                        makeBoad_obj.SetActive(true);
                    }
                    if (animalNum_i == 0)
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
                    talk_b = false;
                    if (animalNum_i == 9)
                    {
                        npc_obj[0].SetActive(true);
                        this.gameObject.SetActive(false);

                    }
                    else
                    {

                        StartCoroutine("TalkBOff");
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

                    talk_b = false;
                    StartCoroutine("TalkBOff");
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


                    if (PlayerPrefs.GetInt("" + SetItemPref_str, 0) == 0)
                    {
                        PlayerPrefs.SetInt("" + SetItemPref_str, 1);
                        npc_obj[1].SetActive(true);
                        npc_obj[0].SetActive(false);
                        npc_obj[3].SetActive(true);
                        npc_obj[2].SetActive(false);

                        if (animalNum_i == 3)
                        {
                            SetDogam2();

                        }
                    }

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
                        PlayerPrefs.SetInt("bearbackmove", 1);
                    }

                    Debug.Log("awe" + a);
                    StopCoroutine("talkBall");
                    k = a;
                    talkBall_obj.GetComponent<SpriteRenderer>().sprite = Event_spr[a];
                    talkBallB_obj.SetActive(true);
                    StartCoroutine("talkBall");


                    break;
                case 27://솜사탕 미니 퍼즐

                    if (events_i==299)
                    {
                        move_obj.SetActive(true);
                    }
                    else
                    {
                        miniGame_obj.SetActive(true);
                    }
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
                                    //SetDogam3();
                                    //SetDogam4();

                                    SetDogam3h();
                                    SetDogam4h();
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

                case 31://말풍선 띄우고 특수 아이템요구 
                    if (PlayerPrefs.GetInt("selecteditemnum", 0) == giveItemPref_i)
                    {
                        //GMI.GetComponent<Inventory>().DelItems();
                        k = a;
                        ItemSettings();
                        GetItem_obj.SetActive(false);
                        balloon_obj.SetActive(false);
                    }
                    else
                    {
                        SGM.GetComponent<SoundEvt>().soundItemFail();
                    }
                    break;
                case 32://말풍선 띄우고 특수 아이템요구 
                    if (PlayerPrefs.GetInt("selecteditemnum", 0) == giveItemPref_i)
                    {
                        //GMI.GetComponent<Inventory>().DelItems();
                        k = a;
                        ItemSettings();
                        GetItem_obj.SetActive(false);
                        balloon_obj.SetActive(false);
                        move_obj.SetActive(false);
                        if (events_i == 1)
                        {
                            npc_obj[0].SetActive(false);
                            npc_obj[1].SetActive(true);
                        }
                    }
                    else
                    {
                        SGM.GetComponent<SoundEvt>().soundItemFail();
                    }
                    break;
                case 33://말풍선 띄우고 특수 아이템요구 
                    if (giveItemPref_i == 35)
                    {
                        item_spr = items_spr[0];
                    }
                    if (giveItemPref_i == 35 && PlayerPrefs.GetInt("selecteditemnum", 0) == 40)
                    {

                        //

                        if (PlayerPrefs.GetInt("selecteditemnum", 0) == 40)
                        {
                            item_spr = items_spr[1];
                        }

                        GMI.GetComponent<Inventory>().DelItems();
                        k = a;
                        SetItemPref_i = 41;
                        ItemSettings();
                        SGM.GetComponent<SoundEvt>().soundDamage();
                        Invoke("get", 0.7f);
                        SetItemPref_i = 47;
                        GetItem_obj.SetActive(false);
                        balloon_obj.SetActive(false);
                    }
                    else
                    {
                        if (PlayerPrefs.GetInt("selecteditemnum", 0) == giveItemPref_i)
                        {
                            if (giveItemPref_i == 36)
                            {

                                cutS_obj.GetComponent<SpriteRenderer>().sprite = cutS_spr[0];
                                cutS_obj.SetActive(true);
                                GM.GetComponent<CharMove>().canMove = false;
                                if (dr_i==1)
                                {
                                    cutS_obj.GetComponent<SpriteRenderer>().sprite = cutS_spr[1];
                                }
                                if (dr_i==2)
                                {
                                    cutS_obj.SetActive(false);
                                    GM.GetComponent<CharMove>().canMove = true;
                                    GMI.GetComponent<Inventory>().DelItems();
                                    k = a;
                                    ItemSettings();
                                    GetItem_obj.SetActive(false);
                                    balloon_obj.SetActive(false);
                                }
                                if (w_i==0)
                                {
                                    w_i = 1;
                                    Invoke("WaitCut", 0.9f);
                                }
                                //
                            }
                            else
                            {
                                GMI.GetComponent<Inventory>().DelItems();
                                k = a;
                                ItemSettings();
                                GetItem_obj.SetActive(false);
                                balloon_obj.SetActive(false);
                            }
                            if (SetItemPref_i == 46)
                            {
                                this.gameObject.SetActive(false);
                            }
                            if (events_i == 5)
                            {

                                SGM.GetComponent<SoundEvt>().soundDamage();
                            }
                        }
                        else
                        {
                            SGM.GetComponent<SoundEvt>().soundItemFail();
                        }
                    }
                    break;
                case 34://특수 아이템요구 아이템제거 아이템획득
                    SGM.GetComponent<SoundEvt>().soundItemFail();
                    a++;
                    if (PlayerPrefs.GetInt("selecteditemnum", 0) == getItemPref_i)
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
                case 35://특수 아이템요구 아이템제거 아이템획득
                    SGM.GetComponent<SoundEvt>().soundPickUp();
                    a = 0;
                    ItemSettings();
                    hallFix_obj.SetActive(false);
                    hall_obj.SetActive(true);
                    k = a;
                    break;
                case 36:
                    SGM.GetComponent<SoundEvt>().soundItemFail();
                    //a++;
                    Debug.Log(PlayerPrefs.GetInt("selecteditemnum", 0) + "d" + getItemPref_i);

                    if (PlayerPrefs.GetInt("selecteditemnum", 0) == giveItemPref_i)
                    {
                        SGM.GetComponent<SoundEvt>().soundItemUse();
                        Debug.Log(PlayerPrefs.GetInt("selecteditemnum", 0) + getItemPref_i);
                        a++;
                        move_obj.gameObject.SetActive(false);
                        ItemSettings();

                        if (SetItemPref_i == 17)
                        {

                            this.gameObject.SetActive(false);
                            balloon_obj.gameObject.SetActive(false);
                        }
                    }
                    k = a;
                    break;
                case 37://말풍선 띄우고 특수 아이템요구 
                    if (PlayerPrefs.GetInt("selecteditemnum", 0) == giveItemPref_i)
                    {
                        GMI.GetComponent<Inventory>().DelItems();
                        k = a;
                        //ItemSettings();
                        GetItem_obj.SetActive(false);
                        balloon_obj.SetActive(false);
                        move_obj.SetActive(true);
                        //this.gameObject.SetActive(false);
                        if (giveItemPref_i == 41)
                        {
                            SGM.GetComponent<SoundEvt>().soundDamage();
                        }
                        else
                        {
                            SGM.GetComponent<SoundEvt>().soundItemUse();
                        }
                        if (giveItemPref_i == 44)
                        {
                            other_obj.SetActive(true);
                        }
                    }
                    else
                    {
                        SGM.GetComponent<SoundEvt>().soundItemFail();
                    }
                    break;


                case 38://말풍선 띄우고 특수 아이템요구 

                    if (events_i==21)
                    {
                        moveOther_obj.SetActive(true);
                    }

                    if (animalNum_i == 10|| animalNum_i == 12)
                    {
                        SetDogam2();
                    }
                    if (animalNum_i == 13)
                    {
                        SetDogam1();
                    }
                    TalkSound();
                    a++;
                    if (SetItemPref_i == 45 && PlayerPrefs.GetInt("selecteditemnum", 0) == 42)
                    {
                        GMI.GetComponent<Inventory>().DelItems();

                        if (events_i == 1 || events_i == 2)
                        {
                            StopTalk();
                            talkBallB_obj.SetActive(false);
                            talk_b = false;
                            StartCoroutine("TalkBOff");
                            all_Ani.Play("ani_npc_cat_get2");
                            SGM.GetComponent<SoundEvt>().soundWaterWalk();
                            Invoke("Anis2", 2f);
                            wait2 = 1;
                            PlayerPrefs.SetInt("cats2", 1);
                        }

                        

                    }
                    else if (SetItemPref_i == 38 && PlayerPrefs.GetInt("selecteditemnum", 0) == 42)
                    {
                        GMI.GetComponent<Inventory>().DelItems();


                        if (events_i == 1 || events_i == 2)
                        {
                            StopTalk();
                            talkBallB_obj.SetActive(false);
                            talk_b = false;
                            StartCoroutine("TalkBOff");
                            all_Ani.Play("ani_npc_cat_get2");
                            SGM.GetComponent<SoundEvt>().soundWaterWalk();
                            Invoke("Anis2", 2f);
                            wait2 = 1;

                            //a = 2;
                            
                        }

                        

                    }
                    else
                    {
                        if (PlayerPrefs.GetInt("selecteditemnum", 0) == giveItemPref_i)
                        {
                            a++;
                            a++;
                            GMI.GetComponent<Inventory>().DelItems();
                            //giveItemPref_i = 18;
                            //SetItemPref_i = 21;
                            //SetDogam2();

                            if (stick_b)
                            {
                                stick_obj.SetActive(true);
                            }
                            if (animalNum_i == 7)
                            {
                                SetDogam2();
                            }
                            if (animalNum_i == 9)
                            {
                                SetDogam2();
                                if (events_i == 2)
                                {
                                    if (PlayerPrefs.GetInt("poped", 0) == 1)
                                    {
                                        SetDogam3h();
                                    }
                                    else
                                    {
                                        SetDogam3();
                                    }
                                }
                            }

                            if (animalNum_i == 11)
                            {
                                PlayerPrefs.SetInt("bhelpon",1);
                                //SetDogam2();
                                //SetDogam3();
                            }
                            //ani_str = "ani_npc_cat_get1";
                            if (events_i == 1)
                            {
                                StopTalk();
                                talkBallB_obj.SetActive(false);
                                talk_b = false;
                                StartCoroutine("TalkBOff");
                                all_Ani.Play("ani_npc_cat_get1");
                                SGM.GetComponent<SoundEvt>().soundWaterWalk();
                                Invoke("Anis", 3f);


                            }
                            else if (events_i == 2)
                            {
                                StopTalk();
                                talkBallB_obj.SetActive(false);
                                talk_b = false;
                                StartCoroutine("TalkBOff");
                                all_Ani.Play("ani_npc_cat_get3");
                                SGM.GetComponent<SoundEvt>().soundWaterWalk();
                                Invoke("Anis", 3f);
                            }
                            if (events_i == 3)
                            {
                                ok = 1;

                                StopCoroutine("talkBall");
                                move_obj.SetActive(true);
                                fade_obj.SetActive(false);
                                Invoke("SetB", 15f);
                                npc_obj[0].SetActive(false);
                                npc_obj[1].SetActive(true);
                                SGM.GetComponent<SoundEvt>().soundDamage2();
                                StopTalk();
                                talkBallB_obj.SetActive(false);

                                //Invoke("Bulbfalse", 1f);
                            }
                            //move_obj.SetActive(true);

                            if (events_i == 4)
                            {

                                SGM.GetComponent<SoundEvt>().soundItemUse();
                                StopCoroutine("talkBall");
                                miniGame_obj.SetActive(true);
                                PlayerPrefs.SetInt("escdont", 1);
                                StopTalk();
                                talkBallB_obj.SetActive(false);
                                GM.GetComponent<CharMove>().canMove = false;
                            }


                            if (events_i == 5)
                            {
                                //StopTalk();
                                //talkBallB_obj.SetActive(false);
                                // talk_b = false;
                                // StartCoroutine("TalkBOff");
                                Invoke("fox2", 0.1f);

                                StopCoroutine("talkBall");
                                k = a + 1;
                                talkBallB_obj.SetActive(true);
                                StartCoroutine("talkBall");
                                StopAndTalk();
                                a++;
                                all_Ani.Play("ani_npc_fox_purple_good");
                            }

                        }
                        else
                        {
                            Debug.Log("awe" + a);
                            StopCoroutine("talkBall");
                            k = a;


                            talkBall_obj.GetComponent<SpriteRenderer>().sprite = Event_spr[a];
                            talkBallB_obj.SetActive(true);
                            StartCoroutine("talkBall");
                            StopAndTalk();
                        }

                    }



                    break;
                case 39://말풍선 띄우고 특수 아이템요구 
                    if (PlayerPrefs.GetInt("selecteditemnum", 0) == giveItemPref_i)
                    {
                        GMI.GetComponent<Inventory>().DelItems();
                        k = a;
                        //ItemSettings();
                        GetItem_obj.SetActive(false);
                        balloon_obj.SetActive(false);
                        move_obj.SetActive(true);
                        Invoke("WaitCook", 15f);
                        SGM.GetComponent<SoundEvt>().soundItemUse();
                    }
                    else
                    {
                        SGM.GetComponent<SoundEvt>().soundItemFail();
                    }
                    break;
                case 40://퍼즐
                    if (PlayerPrefs.GetInt("selecteditemnum", 0) == giveItemPref_i)
                    {
                        SGM.GetComponent<SoundEvt>().soundItemUse();
                        StopAndTalk();
                        a++;
                        GM.GetComponent<CharMove>().canMove = false;
                        //PlayerPrefs.SetInt("cursorActive", 1);
                        //puzzle_obj.GetComponent<RockMini>().ShowPuzzle();
                        miniGame_obj.SetActive(true);
                        PlayerPrefs.SetInt("escdont", 1);
                        GMI.GetComponent<Inventory>().DelItems();
                        this.gameObject.SetActive(false);
                    }
                    else
                    {
                        SGM.GetComponent<SoundEvt>().soundItemFail();
                    }
                    break;

                case 41://특수 아이템요구 두가지의 경우
                    if (PlayerPrefs.GetInt("selecteditemnum", 0) == giveItemPref_i)
                    {
                        GMI.GetComponent<Inventory>().DelItems();
                        k = a;
                        ItemSettings();
                        GetItem_obj.SetActive(false);
                        balloon_obj.SetActive(false);
                        if (SetItemPref_i == 46)
                        {
                            this.gameObject.SetActive(false);
                        }
                        if (events_i == 5)
                        {

                            SGM.GetComponent<SoundEvt>().soundDamage();
                        }
                    }
                    else
                    {
                        SGM.GetComponent<SoundEvt>().soundItemFail();
                    }
                    break;
                case 42://돌부수기
                    if (PlayerPrefs.GetInt("selecteditemnum", 0) == giveItemPref_i)
                    {
                        if (events_i == 96)
                        {
                            PlayerPrefs.SetInt("killrat", 1);

                        }

                        k = a;

                        balloon_obj.SetActive(false);
                        //잔해
                        fade_obj.SetActive(true);
                        //돌
                        GetItem_obj.SetActive(false);


                        SGM.GetComponent<SoundEvt>().soundDamage();

                    }
                    else
                    {
                        SGM.GetComponent<SoundEvt>().soundItemFail();
                    }
                    break;
                case 43://퍼즐
                    if (PlayerPrefs.GetInt("selecteditemnum", 0) >=50 && PlayerPrefs.GetInt("selecteditemnum", 0) <= 55&& PlayerPrefs.GetInt("stackdish", 0)==5)
                    {
                        SGM.GetComponent<SoundEvt>().soundItemUse();
                        //StopAndTalk();
                        a++;
                        PlayerPrefs.SetInt("cursorActive", 1);
                        //puzzle_obj.GetComponent<RockMini>().ShowPuzzle();

                        for (int i = 6; i >= 0; i--)
                        {
                            if (GMI.GetComponent<Inventory>().items_i[i] >= 50 && GMI.GetComponent<Inventory>().items_i[i] <= 55)
                            {
                                GMI.GetComponent<Inventory>().selectedNow_i = i;
                                GMI.GetComponent<Inventory>().DelItems();


                                //GMI.GetComponent<Inventory>().CheckSelect();
                            }
                        }

                        GM.GetComponent<CharMove>().canMove = false;
                        PlayerPrefs.SetInt("escdont", 1);
                        miniGame_obj.SetActive(true);
                        this.gameObject.SetActive(false);
                    }
                    else
                    {
                        SGM.GetComponent<SoundEvt>().soundItemFail();
                    }
                    break;
                case 44://퍼즐
                    if (PlayerPrefs.GetInt("selecteditemnum", 0) >= 50 && PlayerPrefs.GetInt("selecteditemnum", 0) <= 55)
                    {
                        SGM.GetComponent<SoundEvt>().soundItemUse();
                        a++;
                        GMI.GetComponent<Inventory>().Item_spr[PlayerPrefs.GetInt("selecteditemnum", 0)] = GMI.GetComponent<Inventory>().Item_spr[55];


                        for (int i = 6; i >= 0; i--)
                        {
                            if (GMI.GetComponent<Inventory>().items_i[i] >= 50 && GMI.GetComponent<Inventory>().items_i[i] <= 55)
                            {
                                GMI.GetComponent<Inventory>().invenItem_obj[GMI.GetComponent<Inventory>().selectedNow_i].GetComponent<Image>().sprite = GMI.GetComponent<Inventory>().Item_spr[55];



                            }
                        }

                        GM.GetComponent<CharMove>().canMove = false;
                        PlayerPrefs.SetInt("escdont", 1);
                        miniGame_obj.SetActive(true);
                    }
                    else
                    {
                        SGM.GetComponent<SoundEvt>().soundItemFail();
                    }
                    break;
                case 45://컷씬

                    StopAndTalk();
                    cutS_obj.GetComponent<SpriteRenderer>().sprite = cutS_spr[0];
                    cutS_obj.SetActive(true);
                    a++;
                    break;
                case 46://컷씬

                    StopAndTalk();
                    cutS_obj.GetComponent<SpriteRenderer>().sprite = cutS_spr[1];
                    cutS_obj.SetActive(true);

                    if (animalNum_i==0|| animalNum_i == 1)
                    {
                        ori_obj.SetActive(true);

                        color = new Color(1f, 1f, 1f, 0f);
                        other_obj.GetComponent<SpriteRenderer>().color = color;
                        PlayerPrefs.SetInt("wait", 1);
                        Invoke("WaitTalk", 1f);
                    }

                    a++;
                    break;
                case 47://컷씬

                    if (animalNum_i == 0 || animalNum_i == 1)
                    {
                    }
                    else
                    {
                        ori_obj.SetActive(true);
                        StopTalk();
                    }
                    scene_obj.SetActive(false);
                    cutS_obj.SetActive(false);
                    a++;
                    break;
                case 48://종이
                    StopAndTalk();
                    cutS_obj.SetActive(true);
                    a++;
                    break;
                case 49://종이
                    StopTalk();
                    cutS_obj.SetActive(false);
                    a--;
                    break;
            }
        }

        PlayerPrefs.SetInt(SetEventPref_str, a);

        //talk_b = false;
        //StartCoroutine("TalkBOff");

        if (PlayerPrefs.GetInt("sss", 0)==1)
        {
            PlayerPrefs.SetInt("sss", 0);
            Invoke("DontAni",0.1f);
        }


    }

    void Anis()
    {
        move_obj.SetActive(true);
        color = new Color(1f, 1f, 1f, 0f);
        this.GetComponent<SpriteRenderer>().color = color;
        //balloon_obj.SetActive(false);
        //wait2 = 1;
    }

    void Anis2()
    {
        //this.gameObject.SetActive(false);

        color = new Color(1f, 1f, 1f, 0f);
        this.GetComponent<SpriteRenderer>().color = color;
        StopTalk();
        //StopCoroutine("talkBall");
        all_Ani.Play("ani_npc_cat_forest");
        balloon_obj.SetActive(false);
        other_obj.SetActive(true);
        //PlayerPrefs.SetInt("checktalk", 1);
    }

    void Anis3()
    {
        balloon_obj.SetActive(false);

        StopCoroutine("talkBall");
        k = a;


        talkBall_obj.GetComponent<SpriteRenderer>().sprite = Event_spr[a];
        talkBallB_obj.SetActive(true);
        StartCoroutine("talkBall");
        StopAndTalk();
    }

    //void wa
    void SetB()
    {
        PlayerPrefs.SetInt("bdone",1);
        //move_obj.SetActive(false);
        //fade_obj.SetActive(true);
    }

    void WaitCook()
    {
        move_obj.SetActive(false);
        fade_obj.SetActive(true);
        SGM.GetComponent<SoundEvt>().soundDamagex();
    }

    public void StopAndTalk()
    {
        balloon_obj.SetActive(false);
        PlayerPrefs.SetInt("nowtalk", 1);
        GM.GetComponent<CharMove>().canMove = false;
        wait2 = 1;
        Invoke("Wait", 1f);
    }

    void Wait()
    {
        wait2 = 0;
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
            if (soundLow2_b)
            {
                SGM.GetComponent<SoundEvt>().soundTalkLow2();
            }
            else
            {
                SGM.GetComponent<SoundEvt>().soundTalk();
            }
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
                Debug.Log("a" + ani_str);
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

        if (GMI.GetComponent<Inventory>().selectedNow_i < 0)
        {
            PlayerPrefs.SetInt("selectN", 1);
            GMI.GetComponent<Inventory>().selected_i = a-1;
            //GMI.GetComponent<Inventory>().CallSelectItem();
        }
    }



    IEnumerator talkBall()
    {
        if (PlayerPrefs.GetInt("aplus", 0) == 1)
        {
            k = k + 2;
        }

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
            yield return new WaitForSeconds(0.4f);
            //c++;
        }

    }



    /// <summary>
    /// 위로 올라가기
    /// </summary>
    /// <returns></returns>
    IEnumerator EventUp()
    {

        PlayerPrefs.SetInt("wait", 1);
        balloon_obj.SetActive(false);
        PlayerPrefs.SetInt("escdont", 1);
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

            position_nomal = new Vector3(transform.position.x - checkX_f, transform.position.y - checkY_f, transform.position.z);
            yield return new WaitForSeconds(0.01f);
        }
        talk_b = true;
        PlayerPrefs.SetInt("wait", 0);
        PlayerPrefs.SetInt("escdont", 0);

        if (animalNum_i == 3)
        {
            miniGame_obj.SetActive(true);

        }
        SetQuest();
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
            position0.y = position0.y - 5.2f * Time.deltaTime;
            transform.position = position0;
            position_nomal = new Vector3(transform.position.x - checkX_f, transform.position.y - checkY_f, transform.position.z);

            if (position0.y <= move_obj.transform.position.y)
            {
                in_i = 0;
            }

            yield return new WaitForSeconds(0.01f);
        }
        if (animalNum_i == 0)
        {
            SetDogam2();
        }

        yield return new WaitForSeconds(0.2f);
        talk_b = true;
        GM.GetComponent<CharMove>().canMove = true;

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
        //StopCoroutine("FadeIn");
        //GM.GetComponent<CharMove>().bulb_obj.SetActive(false);
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

        PlayerPrefs.SetInt("wait", 0);

    }
    IEnumerator BearL()  //곰이 돌진하는 시간
    {

        PlayerPrefs.SetInt("wait", 1);
        //talk_b = false;
        int in_i = 1;
        position0 = bearM_obj.transform.position;

        yield return new WaitForSeconds(0.4f); //곰딜레이
        while (in_i == 1)
        {
            position0.x = position0.x - 10f * Time.deltaTime; //10f 무빙속도
            bearM_obj.transform.position = position0;

            position_nomal = new Vector3(transform.position.x - checkX_f, transform.position.y - checkY_f, transform.position.z);
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
            position_nomal = new Vector3(transform.position.x - checkX_f, transform.position.y - checkY_f, transform.position.z);

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
        yield return new WaitForSeconds(1f);
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


    IEnumerator FadeIn2()
    {

        miniGame_obj.SetActive(true);
        SGM2.GetComponent<SoundEvt>().soundStart();
        int in_i = 1;
        color = new Color(1f, 1f, 1f);
        color.a = 1f;
        miniGame_obj.GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(1f);
        while (in_i == 1)
        {
            float i_f = 1f;

            for (i_f = 1f; i_f > 0f; i_f -= 0.05f)
            {
                color.a = Mathf.Lerp(0f, 1f, i_f);
                miniGame_obj.GetComponent<SpriteRenderer>().color = color;
                yield return new WaitForSeconds(0.01f);
            }
            //yield return new WaitForSeconds(2f);
            in_i = 0;
            miniGame_obj.SetActive(false);
        }
        miniGame_obj.SetActive(false);

    }



    IEnumerator TalkBOff()  //대화딜레이
    {
        PlayerPrefs.SetInt("escdont",1);

        int in_i = 1;

        while (in_i == 1)
        {
            yield return new WaitForSeconds(0.8f);
            in_i = 0;
        }

        talk_b = true;
        PlayerPrefs.SetInt("escdont", 0);
    }



    void get()
    {
        item_spr = items_spr[2];


        SetItemPref_i = 42;
        ItemSettings();
        SetItemPref_i = 47;
        SGM.GetComponent<SoundEvt>().soundDamage();
    }


    void fox2()
    {
        SetDogam3();
        SetDogam4();
    }


    void attack()
    {
        all_Ani.StopPlayback();
    }


    public void DontAni()
    {
        StopTalk();
        all_Ani.Play("ani_npc_cat_forest");
    }

    void danger()
    {
        all_Ani.Play("ani_npc_cat_forest_danger");
    }


    void Bulbfalse()
    {

        GM.GetComponent<CharMove>().bulb_obj.SetActive(false);


    }


    void WaitTalk()
    {
        PlayerPrefs.SetInt("wait", 0);
    }


    void WaitCut()
    {
        dr_i++;
        w_i = 0;
    }

}
