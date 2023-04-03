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
    public GameObject GM;

    

    // Start is called before the first frame update
    void Start()
    {
        

        StartCoroutine("CheckingMap");


        //if (mapRespawn_obj[0] == null)
        //{
            //mapRespawn_obj = GameObject.FindGameObjectsWithTag("Map");
        //}
    }

    private void OnEnable()
    {
        StartCoroutine("CheckingMap");
    }

    IEnumerator CheckingMap()
    {
        while (mapTime_i == 1)
        {

            Collider2D hit = Physics2D.OverlapBox(transform.position, size, 0, whatIsLayer);
            
            if (hit == null)
            {
            }
            else
            {
                MovingMap();
                //position = player_obj.transform.position;
                //position.x = -5.66f;
                //position.y = -1.55f;
                //player_obj.transform.position = position;
                //Debug.Log("a");
                //-5.664642 -1.550424
                //StopCoroutine("CheckingMap");
            }
                yield return new WaitForSeconds(0.1f);
        }
    }

    /// <summary>
    /// 어느맵으로 갈지 찾아준다.
    /// </summary>
    void MovingMap()
    {
        //mapNow_i = PlayerPrefs.GetInt("mapindexnum", 0);

        //if (mapRespawn_obj[0] == null)
        //{
            //mapRespawn_obj = GameObject.FindGameObjectsWithTag("Map");
        //}

        map2_obj[mapToGo_i].SetActive(true);
        map_obj[mapToGo_i].SetActive(true);
        map2_obj[mapNow_i].SetActive(false);
        map_obj[mapNow_i].SetActive(false);

        int k = mapRespawn_obj.Length;
        k--;
        GM.GetComponent<CharMove>().canMove = false;
        //player_obj.transform.position = mapRespawn_obj[k-mapRespawn_i].transform.position;
        //GM.GetComponent<MoveCharacter>().position = mapRespawn_obj[k - mapRespawn_i].transform.position;
        player_obj.transform.position = mapRespawn_obj[0].transform.position;
        //GM.GetComponent<MoveCharacter>().position = mapRespawn_obj[0].transform.position;
        GM.GetComponent<CharMove>().canMove = true;

        PlayerPrefs.SetInt("mapindexnum", mapToGo_i);
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, size);
    }
}
