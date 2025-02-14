using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class MoveMap2 : MonoBehaviour
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
    public GameObject BGM1, BGM2, BGM4;

    public bool door_b, char_b, comeHere_b, dogam_b, bridge_b, bridgeback_b, lake_b, lake1_b, crow_b, rot_b, crowA_b, secret_b, secret2_b, sheep_b,sheepOff_b;
    public bool lakeOut_b, caveRoad_b, caveEnter_b, crowSet_b, setEff_b, hidden2_b, hidden3_b, hidden4_b, hidden5_b, hidden6_b, hidden7_b, waterOut_b, flip_b, BGM_b, soundback_b,crow2_b, dont_b;
    public bool nomalCave_b;
    public int event_i = 0;

    public GameObject door1_obj, door2_obj;
    public GameObject endEvent_obj, endEvent2_obj, endEvent3_obj, hideEvent1_obj;

    public bool muteOff_b, muteOn_b, offSound_b;

    public GameObject sheep_obj, sheep1_obj, sheep2_obj;
    public Sprite sheep_spr, sheepO_spr;


    public float vols_f = 0.8f;


    public Animator crow_Ani;


    public Vector3 position0;

    public bool caveMove_b;


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

                    if (event_i==96)
                    {
                        if (PlayerPrefs.GetInt("helprat", 0) == 1)
                        {
                            if (PlayerPrefs.GetInt("killrat", 0) == 1)
                            {
                                endEvent_obj.SetActive(true);
                            }
                            else
                            {
                                endEvent2_obj.SetActive(true);
                                door1_obj.SetActive(false);
                            }
                            endEvent3_obj.SetActive(true);
                            hideEvent1_obj.SetActive(false);
                        }
                    }


                    if (secret_b)
                    {

                        if (PlayerPrefs.GetInt("firsthideevent", 0) == 0)
                        {
                            sec();
                            PlayerPrefs.SetInt("firsthideevent", 1);
                        }

                        yield return new WaitForSeconds(0.3f);
                    }

                    if (sheep_b)
                    {
                        sheep1_obj.GetComponent<SpriteRenderer>().sprite = sheep_spr;
                        sheep2_obj.GetComponent<SpriteRenderer>().sprite = sheep_spr;
                        sheep_obj.GetComponent<SpriteRenderer>().sprite = sheep_spr;
                        yield return new WaitForSeconds(0.1f);
                    }
                    if (sheepOff_b)
                    {

                        sheep1_obj.GetComponent<SpriteRenderer>().sprite = sheepO_spr;
                        sheep2_obj.GetComponent<SpriteRenderer>().sprite = sheepO_spr;
                        sheep_obj.GetComponent<SpriteRenderer>().sprite = sheepO_spr;
                    }
                    if (crow2_b)
                    {
                        if (event_i==0)
                        {
                            crow_Ani.Play("ani_npc_crow_bg052");
                            Invoke("Oncrow", 0.5f);
                        }
                        if (event_i == 1)
                        {
                            endEvent3_obj.SetActive(true);
                            door1_obj.SetActive(true);
                            SGM.GetComponent<SoundEvt>().soundCrowAttack();
                            Invoke("OnBone", 0.5f);
                            Invoke("OnBone2", 2.5f);
                        }

                        this.gameObject.SetActive(false);
                    }

                    if (crowA_b)
                    {
                        //크로우어택 후 
                        BGM2.SetActive(false);
                        GM.GetComponent<CharMove>().Speed = 0f;
                        GM.GetComponent<CharMove>().canMove = false;
                        endEvent3_obj.SetActive(true);
                        yield return new WaitForSeconds(0.5f);
                        endEvent_obj.SetActive(true);
                        yield return new WaitForSeconds(5f);
                        endEvent2_obj.SetActive(true);
                        yield return new WaitForSeconds(4f);

                        endEvent3_obj.SetActive(false);
                        PlayerPrefs.SetInt("crowatt", 1);
                        PlayerPrefs.SetInt("lostbell", 1);
                        this.gameObject.SetActive(false);
                    }
                    else
                    {
                        if (comeHere_b)
                        {
                            GM.GetComponent<CharMove>().canMove = false;
                            PlayerPrefs.SetInt("clearitemgetimg", 1);
                            Invoke("MovingMap", 0.5f);
                            BGM1.GetComponent<ForBGM>().BGM2.GetComponent<AudioSource>().volume = 0f;
                        }
                        else
                        {
                            if (dont_b)
                            {

                            }
                            else
                            {
                                wait = 1;
                                PlayerPrefs.SetInt("wait", 1);
                                hit = null;
                                player_obj.transform.position = mapRespawn_obj[0].transform.position;

                                PlayerPrefs.SetInt("clearitemgetimg", 1);
                                Invoke("MovingMap", 0.02f);
                            }
                            //position = player_obj.transform.position;
                            //position.x = -5.66f;
                            //position.y = -1.55f;
                            //player_obj.transform.position = position;
                            //Debug.Log("a");
                            //-5.664642 -1.550424
                            //StopCoroutine("CheckingMap");
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

        GM.GetComponent<CharMove>().mark1_obj.SetActive(false);
        GM.GetComponent<CharMove>().mark2_obj.SetActive(false);

        if (crowA_b)
        {
            //크로우어택 후 스페이스바 누르면 엔딩
            endEvent_obj.SetActive(true);
            endEvent2_obj.SetActive(true);

            BGM2.SetActive(false);
        }
        else
        {
            if (nowDonMove_i == 0)
            {
                map2_obj[mapToGo_i].SetActive(true);
                map2_obj[mapNow_i].SetActive(false);
                if (caveMove_b)
                {

                    map_obj[mapToGo_i].SetActive(true);
                    map_obj[mapNow_i].SetActive(false);
                }

                int k = mapRespawn_obj.Length;
                k--;
                GM.GetComponent<CharMove>().canMove = false;
                GM.GetComponent<CharMove>().canMove = true;
                PlayerPrefs.SetInt("mapindexnum", mapToGo_i);

                wait = 0;
                PlayerPrefs.SetInt("wait", 0);
            }

            if (openSound_b == true)
            {
                SGM.GetComponent<SoundEvt>().soundOpenObject();
            }

            if (onSound_b == true)
            {
                BGM1.SetActive(true);
            }

            if (offSound_b == true)
            {
                BGM1.SetActive(false);
            }


            if (muteOff_b)
            {
                if (PlayerPrefs.GetInt("poped", 0) == 1)
                {
                    BGM1.GetComponent<AudioSource>().mute = true;
                    BGM1.GetComponent<ForBGM>().BGM2.GetComponent<AudioSource>().mute = true;
                }
            }
            if (muteOn_b)
            {
                BGM1.GetComponent<AudioSource>().mute = false;
                BGM1.GetComponent<ForBGM>().BGM2.GetComponent<AudioSource>().mute = false;
            }

            if (BGM_b)
            {
                if (BGM4.activeSelf)
                {
                    BGM4.SetActive(false);
                    BGM2.SetActive(true);
                }
                else
                {
                    BGM4.SetActive(true);
                    BGM2.SetActive(false);
                }
            }

            OpenDoor();
        }
    }

    void Oncrow()
    {

        SGM.GetComponent<SoundEvt>().soundCrowAttack();
    }

    void OnBone()
    {

        endEvent2_obj.SetActive(true);
    }
    void OnBone2()
    {

        endEvent3_obj.SetActive(false);
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, size);
    }



    void OpenDoor()
    {

        if (door_b)
        {
            if (PlayerPrefs.GetInt("opendoorone", 0)==1)
            {
                door1_obj.SetActive(false);
                door2_obj.SetActive(true);
            }
            else
            {
            }

            PlayerPrefs.SetInt("opendoorone", 1);
        }
        else
        {

        }

        if (char_b)
        {
            //player_obj.SetActive(true);
            GM.GetComponent<CharMove>().canMove = false;
            Invoke("WaitSec", 1f);
        }
        if (dogam_b)
        {
            GMI.GetComponent<Inventory>().WaitSec();
        }
        if (bridge_b)
        {
            GMC.GetComponent<ShaderEffect>().changeShader1();
            PlayerPrefs.SetInt("gobrige", 1);
        }
        if (bridgeback_b)
        {

            PlayerPrefs.SetInt("gobrige", 0);
        }
        if (lake_b)
        {

            GMC.GetComponent<ShaderEffect>().changeShader2();
            PlayerPrefs.SetInt("lakebool", 1);
        }
        if (lake1_b)
        {
            PlayerPrefs.SetInt("lakebool", 0);
        }
        if (crow_b)
        {

            PlayerPrefs.SetInt("escdont", 1);
            move_obj.GetComponent<Animator>().Play("ani_npc_crow_surprise");
            Invoke("WaitSecCrow", 1f);
        }
        if (rot_b)
        {
            GMI.GetComponent<Inventory>().RottonItemDel();
            PlayerPrefs.SetInt("rotton",1);
        }
        if (lakeOut_b)
        {
            GMC.GetComponent<ShaderEffect>().changeShader3();
            BGM4.GetComponent<AudioSource>().volume = 0.5f*vols_f;
        }
        if (caveRoad_b)
        {
            GMC.GetComponent<ShaderEffect>().changeShader4();
        }
        if (caveEnter_b)
        {
            GMC.GetComponent<ShaderEffect>().changeShader5();
        }
        if (hidden2_b)
        {
            GMC.GetComponent<ShaderEffect>().changeShader6();
            BGM4.GetComponent<AudioSource>().volume = 0f;
        }

        if (hidden3_b)
        {
            GMC.GetComponent<ShaderEffect>().changeShader9();

        }


        if (hidden4_b)
        {
            GMC.GetComponent<ShaderEffect>().changeShader10();

        }
        if (hidden5_b)
        {
            GMC.GetComponent<ShaderEffect>().changeShader11();

        }
        if (hidden6_b)
        {
            GMC.GetComponent<ShaderEffect>().changeShader12();

        }
        if (hidden7_b)
        {
            GMC.GetComponent<ShaderEffect>().changeShader14();

        }




        if (nomalCave_b)
        {
            GMC.GetComponent<ShaderEffect>().changeShader8();

        }

        if (setEff_b)
        {
            GMC.GetComponent<ShaderEffect>().OffShader();
        }

        if (waterOut_b)
        {
            GMC.GetComponent<ShaderEffect>().changeShader1();
        }
        if (flip_b)
        {

            GMC.GetComponent<ShaderEffect>().ShaderFilp();
        }

        if (crowSet_b)
        {
        }
        if (soundback_b)
        {
            BGM4.GetComponent<AudioSource>().volume = 1f * vols_f;
        }

        if (secret2_b)
        {
            hideEvent1_obj.SetActive(false);
        }


        if (PlayerPrefs.GetInt("bdone", 0) == 1)
        {
            endEvent_obj.SetActive(false);
            endEvent2_obj.SetActive(false);
            endEvent3_obj.SetActive(true);
            PlayerPrefs.SetInt("bdone", 2);
        }
    }

    void sec()
    {
        hideEvent1_obj.SetActive(true);

    }

    void SheepW()
    {
        hideEvent1_obj.SetActive(true);

    }

    void WaitSec()
    {
        GM.GetComponent<CharMove>().canMove = true;
    }
    void WaitSecCrow()
    {
        move_obj.GetComponent<Animator>().Play("ani_npc_crow_talk");
    }



}
