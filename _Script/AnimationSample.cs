using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationSample : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator doorAni, NPC_hedgehogAni, NPC_rabbit1Ani, NPC_rabbit2Ani, NPC_cat1Ani, NPC_bear1Ani, NPC_bear2Ani, NPC_cat2Ani;
    public GameObject NPC_sheep1, lakeboat;
    public Sprite[] NPC_sheepSpr;
    public GameObject testBtnobj, ESCevent;


    float moveX, moveY;
    void Start()
    {
        doorAni.GetComponent<Animator>().speed = 0.0f;//멈춤
         StartCoroutine("openDoor");
        //talkAnimation();

        //낚시 고양이 애니 움직임 멈춤
        NPC_cat2Ani.speed = 0f;

    }

    void talkAnimation()
    {
        NPC_bear1Ani.Play("ani_npc_bear1_talk");
        NPC_bear2Ani.Play("ani_npc_bear2_talk");
        NPC_hedgehogAni.Play("ani_npc_hedgehog1_talk");
        NPC_rabbit1Ani.Play("ani_npc_rabbit1_talk");
        NPC_rabbit2Ani.Play("ani_npc_rabbit2_talk");
        NPC_cat1Ani.Play("ani_npc_cat1_talk");

        NPC_sheep1.GetComponent<SpriteRenderer>().sprite = NPC_sheepSpr[1];


    }




    IEnumerator openDoor() //이걸 이용해서 리버스 응용가능
    {
        yield return new WaitForSeconds(3f);
        doorAni.GetComponent<Animator>().speed = 1.0f;//실행
    }

    public void closeDoor() 
    {
         doorAni.SetFloat("speed", -1f);//리버스
        doorAni.GetComponent<Animator>().speed = 1.0f;
    }

    public void testBtn()
    {
        closeDoor();
    }

    private void Update()
    {
        if (doorAni.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
        {
            testBtnobj.SetActive(true);
        }//애니메이션이 종료됨을 감지하는 코드



        if (Input.GetKey(KeyCode.Escape))
        {
            showESCwindow();
        }

    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void showFeedback()
    {
        Application.OpenURL("https://forms.gle/CGuVE8nRbE1QaRSc6");
    }

    public void showESCwindow()
    {
        ESCevent.SetActive(true);
    }


    public void closeESCwindow()
    {
        ESCevent.SetActive(false);
    }

}
