using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSample : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator doorAni;
    public GameObject testBtnobj;
    void Start()
    {
        doorAni.GetComponent<Animator>().speed = 0.0f;//멈춤
         StartCoroutine("openDoor");
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
        
    }

}
