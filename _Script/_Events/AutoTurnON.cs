using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTurnON : MonoBehaviour
{
    public GameObject targetToTurnOff; // 인스펙터에서 끌 오브젝트를 연결하세요
    public GameObject targetToTurnON;
    public GameObject other, other1, other2;

    public GameObject stone;

    public Sprite stone_spr;

    public bool b;


    public Animator all_Ani;

    // 이 스크립트가 붙은 오브젝트가 활성화(SetActive true)될 때 실행됨
    private void OnEnable()
    {


        if (PlayerPrefs.GetInt("beartrap", 0)==1)
        {
            targetToTurnON.SetActive(true);
            targetToTurnOff.SetActive(false);
            all_Ani.Play("ani_npc_rabbit_df_dead");
            if (PlayerPrefs.GetInt("beartrap", 0) == 1)
            {
                all_Ani.Play("ani_npc_rabbit_df_qclear_after");
            }
        }

        if (PlayerPrefs.GetInt("beartrap", 0) == 2)
        {
            targetToTurnON.SetActive(false);
            targetToTurnOff.SetActive(true);
            other.SetActive(true);

            all_Ani.Play("ani_npc_rabbit_df_die");
            stone.GetComponent<SpriteRenderer>().sprite = stone_spr;
        }

    }
}
