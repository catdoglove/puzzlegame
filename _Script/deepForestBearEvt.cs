using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deepForestBearEvt : MonoBehaviour
{
    public Animator BearAni;

    public GameObject brock_0bj;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        BearAni.Play("ani_npc_deepbear_appear");

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        brock_0bj.SetActive(true);
        Invoke("changeNormal",5f);
    }

    void changeNormal()
    {
        brock_0bj.SetActive(false);
        BearAni.Play("ani_npc_deepbear_normal");
    }
}
