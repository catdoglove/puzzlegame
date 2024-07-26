using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBack : MonoBehaviour
{
    public Vector3 position0;
    public GameObject GM;

    public GameObject player_obj;

    public GameObject move_obj;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnEnable()
    {
        StartCoroutine("EventBack");

    }

    /// <summary>
    /// 뒤로 밀기
    /// </summary>
    /// <returns></returns>
    IEnumerator EventBack()
    {
        PlayerPrefs.SetInt("wait", 1);
        GM.GetComponent<CharMove>().canMove = false;
        //talk_b = false;
        int in_i = 1;
        position0 = player_obj.transform.position;

        //yield return new WaitForSeconds(0.5f);
        //SGM.GetComponent<SoundEvt>().auSE.GetComponent<AudioSource>().pitch = 1f;
        //SGM.GetComponent<SoundEvt>().soundDamage();
        while (in_i == 1)
        {

            GM.GetComponent<CharMove>().Speed = 0f;
            GM.GetComponent<CharMove>().canMove = false;
            position0.x = position0.x - 8f * Time.deltaTime;
            player_obj.transform.position = position0;

            if (position0.x <= move_obj.transform.position.x)
            {
                in_i = 0;
            }

            yield return new WaitForSeconds(0.01f);
        }
        move_obj.SetActive(false);
        //talk_b = true;
        GM.GetComponent<CharMove>().canMove = true;
        //move_obj.GetComponent<Animator>().Play("ani_npc_fox");

        //PlayerPrefs.SetInt("foxclear", 0);

        PlayerPrefs.SetInt("wait", 0);
    }
}
