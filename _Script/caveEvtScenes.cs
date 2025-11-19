using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caveEvtScenes : MonoBehaviour
{
    public Animator subCharAni;
    public GameObject mainChar, mainCharAni;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void animationJump()
    {
        Vector3 position = mainChar.transform.localPosition;
        position.x = 3.76f;
        position.y = -1.44f;
        mainChar.transform.localPosition = position;


        subCharAni.Play("ani_npc_unknown_cave1");
        subCharAni.Play("ani_npc_unknown_default");
        mainCharAni.SetActive(false);
        //mainChar.SetActive(true);
        PlayerPrefs.SetInt("startdialogfirst",1);
    }
}
