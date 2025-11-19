using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class FollowChar : MonoBehaviour
{
    public GameObject CGM, SGM;
    public GameObject charP_obj, subChar_obj;

    public Animator sub_Ani;


    public int i_i=0;

    Vector3 Vector3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("comhere");
    }




    IEnumerator comhere()
    {
        while (i_i == 0)
        {
            if (charP_obj.transform.position.x <= CGM.transform.position.x)
            {
                Vector3= new Vector3(subChar_obj.transform.position.x +0.1f, subChar_obj.transform.position.y, subChar_obj.transform.position.z);

                subChar_obj.transform.position = Vector3;

                //sub_Ani.Play("ani_npc_unknown_cave4");
                sub_Ani.StopPlayback();
            }
            else
            {
                sub_Ani.StartPlayback();
            }

            //sub_Ani.StartPlayback();
            //sub_Ani.Play("ani_npc_unknown_cave4");

            yield return new WaitForSeconds(0.01f);
        }

    }
}
