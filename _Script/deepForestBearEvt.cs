using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deepForestBearEvt : MonoBehaviour
{
    public Animator BearAni;

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
        Invoke("changeNormal",5f);
    }

    void changeNormal()
    {
        BearAni.Play("ani_npc_deepbear_normal");
    }
}
