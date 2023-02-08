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

    public GameObject GMS;

    //
    public string SetItemPref_str = "text";
    public int SetItemPref_i = 0;
    public bool itemQ_b;
    public GameObject GetItem_obj, GetItemS_obj, GetItemO_obj;


    public string SetEventPref_str = "text";
    public int[] EventNum_i;
    public Sprite[] Event_spr;
    public GameObject talkBall_obj;

    private void OnEnable()
    {
        //StartCoroutine("Checking");
    }

    void Start()
    {
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
        
        position = this.transform.position;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, size);
    }

    private void Update()
    {
        Collider2D hit = Physics2D.OverlapBox(transform.position, size, 0, whatIsLayer);
        if (hit == null)
        {
            balloon_obj.SetActive(false);
            GMS.GetComponent<BounceAnim>().resetAnim();
        }
        else
        {
            //Debug.Log(hit.name);
            if (a == 0)
            {
                x_f = balloon_spr.bounds.size.x;
                y_f = balloon_spr.bounds.size.y;
                position.x = position.x - balloon_spr.bounds.size.x * 3f;
                position.y = position.y + (balloon_spr.bounds.size.y) * 1.5f;
                a = 1;
                balloon_obj.transform.position = position;
            }
            balloon_obj.SetActive(true);

            if (Input.GetKeyUp(KeyCode.Space))
            {
                EventOrItem();
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
        /*
        if (itemQ_b)
        {
            ItemSetting();
            
        }
        else
        {
            EventSetting();
        }
        */
    }

    /// <summary>
    /// 아이템값받아오고 인벤토리에넣는다.
    /// </summary>
    void ItemSetting()
    {
        int a = 0;
        a = PlayerPrefs.GetInt("inventorynum", 0);

        
        //if (PlayerPrefs.GetInt("itemnum" + SetItemPref_i, 0) == 0)
        //{


            int p = PlayerPrefs.GetInt("inventoryget" + a, 0);
            int o = PlayerPrefs.GetInt("itemnum" + p);

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
        //Debug.Log("o" + o);
        //Debug.Log("a" + a);
        PlayerPrefs.SetInt("inventorynum", a);

            PlayerPrefs.SetInt("itemnum" + p, o);
        Debug.Log("o" + o);
        //PlayerPrefs.SetInt("itemnum" + SetItemPref_i, 1);

        GetItem_obj.SetActive(true);
            GetItemS_obj.SetActive(true);
            balloon_obj.SetActive(false);
            this.gameObject.SetActive(false);

        PlayerPrefs.SetInt("changeitem", 1);
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

        for (int i = 0; i < k; i++)
        {
            if (PlayerPrefs.GetInt("inventoryget" + i, 0) == SetItemPref_i)
            {
                PlayerPrefs.SetInt("stacking", 1);
                PlayerPrefs.SetInt("whierestacking", i);
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

        Debug.Log("a"+ a);
        switch (EventNum_i[a])
        {
            case 0:
                break;
            case 1://말풍선띄우고 다음 행동으로
                talkBall_obj.GetComponent<SpriteRenderer>().sprite = Event_spr[a];
                StartCoroutine("talkBall");
                a++;
                break;
            case 2://말풍선 띄우고 아이템 요구
                talkBall_obj.GetComponent<SpriteRenderer>().sprite = Event_spr[a];
                StartCoroutine("talkBall");

                break;
            case 3://말풍선 띄우고 멈춤
                talkBall_obj.GetComponent<SpriteRenderer>().sprite = Event_spr[a];
                StartCoroutine("talkBall");
                break;
            case 4://말풍선 띄우고 특수 아이템요구
                talkBall_obj.GetComponent<SpriteRenderer>().sprite = Event_spr[a];
                StartCoroutine("talkBall");
                break;
            default:
                break;
        }
        PlayerPrefs.SetInt(SetEventPref_str, a);
    }

    void sw()
    {

        
    }


    IEnumerator talkBall()
    {
        int c = 1;
        while (c <= 100)
        {
            talkBall_obj.SetActive(true);
            yield return new WaitForSeconds(0.01f);
            c++;
        }

        talkBall_obj.SetActive(false);
    }

}
