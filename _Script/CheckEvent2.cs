using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEvent2 : MonoBehaviour
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
    public GameObject GM, GMI, GMC;

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

    public bool walk_b, walkW_b, pickup_b, broken_b, end_b,sheep_b;
    public GameObject triger_obj, plank_obj, plankHall_obj, plankA_obj;
    public GameObject rage_obj;


    public Vector3 position0;

    public GameObject black_obj, gameOff_obj, UIOff_obj;

    int in_i;

    Color color;

    public GameObject SheepC_obj;

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
                        if (PlayerPrefs.GetInt("foxclear", 0) == 0)
                        {
                            if (PlayerPrefs.GetInt("foxq", 0) == 0)
                            {
                                block();
                            }
                        }

                    }
                    if (sheep_b)
                    {
                        GM.GetComponent<CharMove>().canMove = false;
                        SheepC_obj.SetActive(true);

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

                    if (end_b)
                    {

                        if (PlayerPrefs.GetInt("gametestover", 0) == 0)
                        {
                            UIOff_obj.SetActive(false);
                            GM.GetComponent<CharMove>().canMove = false;
                            GM.GetComponent<CharMove>().Speed = 0f;

                            black_obj.SetActive(true);
                            StartCoroutine("FadeIn");
                            PlayerPrefs.SetInt("gametestover", 1);

                        }
                        //this.gameObject.SetActive(false);
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
        PlayerPrefs.SetInt("foxclear", 1);
        //StopCoroutine("EventDown");
        StartCoroutine("EventDown");
    }


    /// <summary>
    /// 뒤로 밀기
    /// </summary>
    /// <returns></returns>
    IEnumerator EventDown()
    {
        PlayerPrefs.SetInt("wait", 1);
        GM.GetComponent<CharMove>().canMove = false;
        //talk_b = false;
        int in_i = 1;
        position0 = player_obj.transform.position;

        yield return new WaitForSeconds(0.5f);
        SGM.GetComponent<SoundEvt>().auSE.GetComponent<AudioSource>().pitch = 1f;
        SGM.GetComponent<SoundEvt>().soundDamage();
        while (in_i == 1)
        {
            position0.x = position0.x - 6f * Time.deltaTime;
            player_obj.transform.position = position0;

            if (position0.x <= door1_obj.transform.position.x)
            {
                in_i = 0;
            }

            yield return new WaitForSeconds(0.01f);
        }
        //talk_b = true;
        GM.GetComponent<CharMove>().canMove = true;
        move_obj.GetComponent<Animator>().Play("ani_npc_fox");

        PlayerPrefs.SetInt("foxclear", 0);

        PlayerPrefs.SetInt("wait", 0);
    }



    IEnumerator FadeIn()
    {

        yield return new WaitForSeconds(0.5f);



        in_i = 1;

        black_obj.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);


        while (in_i == 1)
        {

            float i_f = 0f;

            for (i_f = 0f; i_f < 1f; i_f += 0.05f)
            {
                color.a = Mathf.Lerp(0f, 1f, i_f);
                black_obj.GetComponent<SpriteRenderer>().color = color;
                yield return new WaitForSeconds(0.05f);
            }
            yield return new WaitForSeconds(1f);
            in_i = 0;
        }

        GMC.GetComponent<ShaderEffect>().OffShader();
        gameOff_obj.SetActive(true);
        PlayerPrefs.SetInt("cursorActive", 1);
        //SGM.GetComponent<SoundEvt>().soundCloseDoor();
        //black_obj.SetActive(false);


        yield return new WaitForSeconds(1.5f); 
        
    }

}
