using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEvent : MonoBehaviour
{
    public GameObject[] map_obj;
    public GameObject[] map2_obj;
    public GameObject[] mapRespawn_obj;
    public int mapToGo_i, mapNow_i, mapRespawn_i;

    public GameObject move_obj;
    public GameObject player_obj;
    Vector3 position;
    int mapTime_i = 1;
    public Vector2 size;
    public LayerMask whatIsLayer;
    public GameObject GM, GMI;

    int nowMoving_i = 1;
    int nowDonMove_i = 0;

    int wait = 0;

    public bool openSound_b, onSound_b;
    
    public GameObject SGM;
    public GameObject BGM1;


    int a = 0;

    public GameObject door1_obj, door2_obj;
    public GameObject endEvent_obj, endEvent2_obj, endEvent3_obj;

    public bool muteOff_b, muteOn_b;

    public bool walk_b, walkW_b, pickup_b, broken_b;
    public GameObject triger_obj, plank_obj, plankHall_obj, plankA_obj;
    public GameObject rage_obj;

    // Start is called before the first frame update
    void Start()
    {


        StopCoroutine("CheckingMap");
        StartCoroutine("CheckingMap");


        //if (mapRespawn_obj[0] == null)
        //{
            //mapRespawn_obj = GameObject.FindGameObjectsWithTag("Map");
        //}
    }

    private void OnEnable()
    {
        StopCoroutine("CheckingMap");
        StartCoroutine("CheckingMap");
    }

    IEnumerator CheckingMap()
    {

        while (mapTime_i == 1)
        {
            wait = PlayerPrefs.GetInt("wait", 0);
            if (wait == 0)
            {
                Collider2D hit = Physics2D.OverlapBox(transform.position, size, 0, whatIsLayer);

                if (hit == null)
                {
                }
                else
                {
                    if (walk_b)
                    {
                            GM.GetComponent<CharMove>().changeVolume3(triger_obj.transform.position.x);
                    }

                    if (pickup_b)
                    {
                        if (PlayerPrefs.GetInt("broken", 0) == 0)
                        {
                            block();
                        }

                    }
                    if (broken_b)
                    {

                        if (PlayerPrefs.GetInt("broken", 0) == 0)
                        {
                            for (int i = 6; i >= 0; i--)
                            {
                                if (GMI.GetComponent<Inventory>().items_i[i] == 21)
                                {
                                    BreakP();
                                }
                            }
                        }
                    }
                    



                }

            }
            yield return new WaitForSeconds(0.1f);
        }
        
    }

    /// <summary>
    /// 어느맵으로 갈지 찾아준다.
    /// </summary>
    public void MovingMap()
    {

    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, size);
    }

    /// <summary>
    /// 판자가 부서짐
    /// </summary>
    void BreakP()
    {
        plank_obj.SetActive(false);
        plankA_obj.SetActive(false);
        rage_obj.SetActive(false);
        plankHall_obj.SetActive(true);
        SGM.GetComponent<SoundEvt>().soundDamage();
        PlayerPrefs.SetInt("broken",1);
    }

    void block()
    {
        
            move_obj.GetComponent<Animator>().Play("ani_npc_fox_stop");
            SGM.GetComponent<SoundEvt>().auSE.GetComponent<AudioSource>().pitch = 1f;
            SGM.GetComponent<SoundEvt>().soundDamage();
        PlayerPrefs.SetInt("block", 1);
    }
}
