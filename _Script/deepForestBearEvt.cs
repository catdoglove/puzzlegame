using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deepForestBearEvt : MonoBehaviour
{
    public Animator BearAni;

    public GameObject brock_0bj;

    public GameObject GM;


    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("foxclear", 0);

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        BearAni.Play("ani_npc_deepbear_appear");

        Invoke("Help", 0.25f);
        //GM.GetComponent<CheckEvent2>().
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //brock_0bj.SetActive(true);
        Invoke("changeNormal",5f);
    }

    public void Help()
    {
        GM.GetComponent<CheckEvent2>().block2();
    }

    void changeNormal()
    {
        brock_0bj.SetActive(false);
        BearAni.Play("ani_npc_deepbear_normal");
    }
}
