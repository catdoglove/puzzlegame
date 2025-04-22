using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniHandler : MonoBehaviour
{


    #region Fields

    public GameObject map1_obj, map2_obj, mapRespawn_obj;
    public GameObject b_obj, in_obj;
    public GameObject player_obj, ani_obj;
    public Color color;
    public GameObject BGM, SGM;


    #endregion Fields

    #region Members
    private Animator m_Animator;

    #endregion Members


    #region Methods
    void Awake()
    {
        m_Animator = GetComponent<Animator>();
    }

    public void EnterNextScene()
    {
        // 애니메이션 재생
        //m_Animator.Play("Animation_Name");
    }

    public void OnEnterNextScene()
    {
        // 애니메이션이 끝난 후 처리
    }

    #endregion Methods

    public void AniFin()
    {
        StartCoroutine("imgFadeOut");
    }

    void MoveMap()
    {

    }

    public void AniFin2()
    {
        this.gameObject.SetActive(false);
    }
    public void AniFin3()
    {
        in_obj.SetActive(true);
        b_obj.SetActive(false);
        player_obj.GetComponent<SpriteRenderer>().flipX = true;
        player_obj.GetComponent<CharMove>().canMove = true;
        SGM.GetComponent<SoundEvt>().soundDamagex();
    }
    public void AniStart()
    {
        player_obj.GetComponent<CharMove>().canMove = false;
    }



    public void af()
    {
        this.gameObject.SetActive(false);
    }
    public void Jump()
    {
        SGM.GetComponent<SoundEvt>().soundJump();
    }

    

    public void BackSound()
    {

        SGM.GetComponent<SoundEvt>().soundHide1();
    }

    public void WalkSound()
    {

        SGM.GetComponent<SoundEvt>().soundWalk();
    }


    IEnumerator imgFadeOut()
    {

        yield return new WaitForSeconds(1.6f);

        b_obj.SetActive(true);
        color = b_obj.GetComponent<SpriteRenderer>().color;
        for (float i = 0f; i <= 1f; i += 0.05f)
        {
            //moveX = moveX + 0.01f;
            // CGM.transform.position = new Vector3(moveX, moveY, 0f);
            color.a = Mathf.Lerp(0f, 1f, i);
            b_obj.GetComponent<SpriteRenderer>().color = color;
            yield return new WaitForSeconds(0.05f);
        }
        color.a = Mathf.Lerp(0f, 1f, 1f);
        b_obj.GetComponent<SpriteRenderer>().color = color;

        //StopCoroutine("move");

        yield return new WaitForSeconds(1.2f);

        ani_obj.gameObject.SetActive(false);
        b_obj.SetActive(false);
        map1_obj.SetActive(true);
        map2_obj.SetActive(false);
        player_obj.SetActive(true);
        player_obj.transform.position = mapRespawn_obj.transform.position;
        BGM.GetComponent<AudioSource>().volume = 1;

        PlayerPrefs.SetInt("escdont", 0);
        Invoke("af", 0.8f);
        yield return new WaitForSeconds(0.8f);
        //CGM.GetComponent<CharMove>().Speed = 2.5f;
    }

    public void TurnOffB()
    {

        PlayerPrefs.SetInt("escdont", 1);
        StartCoroutine("BGMFadeOut");
    }

    public void Sound()
    {
        SGM.GetComponent<SoundEvt>().soundMoving();
    }


    IEnumerator BGMFadeOut()
    {

        for (float i = BGM.GetComponent<AudioSource>().volume; i > 0f; i -= 0.02f)
        {
            BGM.GetComponent<AudioSource>().volume = i;
            yield return new WaitForSeconds(0.05f);
        }

        
    }
}
