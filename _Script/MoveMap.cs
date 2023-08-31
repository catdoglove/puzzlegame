using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMap : MonoBehaviour
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

    public bool door_b, char_b, comeHere_b, dogam_b, bridge_b, bridgeback_b, lake_b, lake1_b, crow_b, rot_b;
    public bool lakeOut_b, caveRoad_b, caveEnter_b, crowSet_b, setEff_b, hidden2_b, waterOut_b;


    public GameObject door1_obj, door2_obj;
    public GameObject endEvent_obj, endEvent2_obj, endEvent3_obj;

    public bool muteOff_b, muteOn_b;

    

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


                    if (comeHere_b)
                    {
                        GM.GetComponent<CharMove>().canMove = false;
                        endEvent3_obj.SetActive(true);
                        Invoke("MovingMap", 0.5f);
                        BGM1.GetComponent<ForBGM>().BGM2.GetComponent<AudioSource>().volume = 0f;
                    }
                    else
                    {

                        wait = 1;
                        PlayerPrefs.SetInt("wait", 1);
                        hit = null;
                        player_obj.transform.position = mapRespawn_obj[0].transform.position;

                        Invoke("MovingMap", 0.02f);
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
                yield return new WaitForSeconds(0.1f);
            }
        
    }

    /// <summary>
    /// 어느맵으로 갈지 찾아준다.
    /// </summary>
    public void MovingMap()
    {
        if (comeHere_b)
        {
            //크로우어택 후 스페이스바 누르면 엔딩
            endEvent_obj.SetActive(true);
            endEvent2_obj.SetActive(true);
        }
        else
        {
            if (nowDonMove_i == 0)
            {
                map2_obj[mapToGo_i].SetActive(true);
                map2_obj[mapNow_i].SetActive(false);

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


            OpenDoor();
        }
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
        }
        if (setEff_b)
        {
            GMC.GetComponent<ShaderEffect>().OffShader();
        }

        if (waterOut_b)
        {
            GMC.GetComponent<ShaderEffect>().changeShader1();
        }

        if (crowSet_b)
        {
            //PlayerPrefs.SetInt("lostbell", 1);
        }
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
