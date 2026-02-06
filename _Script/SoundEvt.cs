using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundEvt : MonoBehaviour {

	//시스템 소리
	public AudioClip sp_start, sp_pickup, sp_damage, sp_damagex, sp_damage2, sp_damage3, sp_open_object, sp_jump, sp_water_walk;
	public AudioSource se_start, se_pickup, se_damage, se_damagex, se_damage2, se_damage3, se_open_object, se_jump, se_water_walk;

	//이벤트 관련
	public AudioClip sp_box_etc, sp_box_open, sp_box_bell, sp_crow_attack, sp_hide1, sp_doorclose, sp_bear_pop, sp_cotton, sp_boom, sp_cave_secret, sp_moving, sp_spider_catch, sp_spider_change, sp_spider_charse;
	public AudioSource se_box_etc, se_box_open, se_box_bell, se_crow_attack, se_hide1, se_doorclose, se_bear_pop, se_cotton, se_boom, se_cave_secret, se_moving, se_spider_catch, se_spider_change, se_spider_charse;

	//걷기 관련
	public AudioClip sp_walk, sp_walk_wood, sp_walk_cave;
	public AudioSource se_walk, se_walk_wood, se_walk_cave;





	//아이템 사용 관련
	public AudioClip sp_item_fail, sp_item_success, sp_item_use;
	public AudioSource se_item_fail, se_item_success, se_item_use;


	//아이템 창 관련
	public AudioClip sp_item_open, sp_item_select, sp_adkey, sp_item_select_no;
	public AudioSource se_item_open, se_item_select, se_adkey, se_item_select_no;


	//대화 관련
	public AudioClip sp_talk, sp_talk_low, sp_talk_low2, sp_mutantTalk;
	public AudioSource se_talk, se_talk_low, se_talk_low2, se_mutantTalk;

	public AudioSource auSE;
	public AudioClip auCP;

	public GameObject charGM;

    

	// Use this for initialization
	void Start()
	{
	}



	/// <summary>
	/// 타이틀에서
	/// </summary>
	public void soundStart()
	{
		putSound(se_start, sp_start);
		auSE.Play();
	}

	/// <summary>
	/// 아이템 줍는 소리
	/// </summary>
	public void soundPickUp()
	{
		putSound(se_pickup, sp_pickup);
		auSE.Play();
	}

	/// <summary>
	/// 데미지 소리
	/// </summary>
	public void soundDamage() 
	{
		putSound(se_damage, sp_damage);
		auSE.Play();
	}


	/// <summary>
	/// 튕기는 소리
	/// </summary>
	public void soundBearPop()
	{
		putSound(se_bear_pop, sp_bear_pop);
		auSE.Play();
	}


	/// <summary>
	/// 다리, 문 열리는 소리
	/// </summary>
	public void soundOpenObject()
	{
		putSound(se_open_object, sp_open_object);
		auSE.Play();
	}

	/// <summary>
	/// 점프소리
	/// </summary>
	public void soundJump()
	{
		putSound(se_jump, sp_jump);
		auSE.Play();
	}

	/// <summary>
	/// 배가 물위로 걷는소리
	/// </summary>
	public void soundWaterWalk()
	{
		putSound(se_water_walk, sp_water_walk);
		auSE.Play();
    }

    /// <summary>
    /// 걷는소리
    /// </summary>
    public void soundWalk()
    {
        putSound(se_walk, sp_walk);
        auSE.Play();
    }

    /// <summary>
    /// 튜토리얼 상자관련 WASD
    /// </summary>
    public void soundBoxWASD()
	{
		putSound(se_box_etc, sp_box_etc);
		auSE.Play();
	}

	/// <summary>
	/// 튜토리얼 상자오픈
	/// </summary>
	public void soundBoxOpen()
	{
		putSound(se_box_open, sp_box_open);
		auSE.Play();
	}

	/// <summary>
	/// 튜토리얼 상자 방울
	/// </summary>
	public void soundBoxBell()
	{
		putSound(se_box_bell, sp_box_bell);
		auSE.Play();
	}
	

	/// <summary>
	/// 까마귀의 습격
	/// </summary>
	public void soundCrowAttack()
	{
		putSound(se_crow_attack, sp_crow_attack);
		auSE.Play();
	}
	
	
	/// <summary>
	/// 문닫는 소리
	/// </summary>
	public void soundCloseDoor()
	{
		putSound(se_doorclose, sp_doorclose);
		auSE.Play();
	}
	
	
	/// <summary>
	/// 아이템 실패
	/// </summary>
	public void soundItemFail()
	{
		putSound(se_item_fail, sp_item_fail);
		auSE.Play();
	}
	
	
	/// <summary>
	/// 아이템 만들기 성공
	/// </summary>
	public void soundItemSuccess()
	{
		putSound(se_item_success, sp_item_success);
		auSE.Play();
	}
	
	
	/// <summary>
	/// 아이템 사용
	/// </summary>
	public void soundItemUse()
	{
		putSound(se_item_use, sp_item_use);
		auSE.Play();
	}	
	
	/// <summary>
	/// 아이템창 열기 'E'
	/// </summary>
	public void soundItemWndOpen()
	{
		putSound(se_item_open, sp_item_open);
		auSE.Play();
	}	

	/// <summary>
	/// 아이템창 선택 'space'
	/// </summary>
	public void soundItemWndSelect()
	{
		putSound(se_item_select, sp_item_select);
		auSE.Play();
	}

	/// <summary>
	/// 아이템창 선택해제
	/// </summary>
	public void soundItemWndSelectNO()
	{
		putSound(se_item_select_no, sp_item_select_no);
		auSE.Play();
	}
	



	/// <summary>
	/// 아이템창 좌우 'AD'
	/// </summary>
	public void soundItemWndAD()
	{
		putSound(se_adkey, sp_adkey);
		auSE.Play();
	}


	/// <summary>
	/// 대화소리 (몸집이 작은)
	/// </summary>
	public void soundTalk()
	{
		putSound(se_talk, sp_talk);
		auSE.Play();
	}

	/// <summary>
	/// 대화소리 (몸집이 큰)
	/// </summary>
	public void soundTalkLow()
	{
		putSound(se_talk_low, sp_talk_low);
		auSE.Play();
	}

	/// <summary>
	/// 대화소리2 (몸집이 큰)
	/// </summary>
	public void soundTalkLow2()
	{
		putSound(se_talk_low2, sp_talk_low2);
		auSE.Play();
	}



	/// <summary>
	/// 숨는소리
	/// </summary>
	public void soundHide1()
	{
		putSound(se_hide1, sp_hide1);
		auSE.Play();
    }

    /// <summary>
    /// 숨는소리
    /// </summary>
    public void soundCotton()
    {
        putSound(se_cotton, sp_cotton);
        auSE.Play();
    }

    /// <summary>
    /// 데미지 소리2
    /// </summary>
    public void soundDamagex()
    {
        putSound(se_damagex, sp_damagex);
        auSE.Play();
    }

    /// <summary>
    /// 데미지 소리2
    /// </summary>
    public void soundDamage2()
    {
        putSound(se_damage2, sp_damage2);
        auSE.Play();
    }

	/// <summary>
	/// 데미지 소리3
	/// </summary>
	public void soundDamage3()
	{
		putSound(se_damage3, sp_damage3);
		auSE.Play();
	}


	/// <summary>
	/// 폭탄 터지는 소리
	/// </summary>
	public void soundBoom()
	{
		putSound(se_boom, sp_boom);
		auSE.Play();
	}


	/// <summary>
	/// 동굴 히든 소리
	/// </summary>
	public void soundCaveSecret()
	{
		putSound(se_cave_secret, sp_cave_secret);
		auSE.Play();
	}


	/// <summary>
	/// 움직이는 소리
	/// </summary>
	public void soundMoving()
	{
		putSound(se_moving, sp_moving);
		auSE.Play();
	}

	/// <summary>
	/// 거미한테 잡히는 소리
	/// </summary>
	public void soundSpiderCatch()
	{
		putSound(se_spider_catch, sp_spider_catch);
		auSE.Play();
	}

	/// <summary>
	/// 거미 변신 소리
	/// </summary>
	public void soundSpiderChange()
	{
		putSound(se_spider_change, sp_spider_change);
		auSE.Play();
	}


	/// <summary>
	/// 거미 발걸음 소리
	/// </summary>
	public void soundSpiderCharse()
	{
		putSound(se_spider_charse, sp_spider_charse);
		auSE.Play();
	}


    /// <summary>
    /// 변의곰 소리
    /// </summary>
    public void mutantBear()
    {
        putSound(se_mutantTalk, sp_mutantTalk);
        auSE.Play();
    }





    public void putSound(AudioSource audioSE, AudioClip audioCP)
	{
		audioSE = gameObject.GetComponent<AudioSource>();
		audioSE.clip = audioCP;
		auSE = audioSE;
		auCP= audioCP;
		//auSE.GetComponent<AudioSource>().pitch = 1f;
	}























	public void soundSample(){

		//putSound(se_pickup, sp_pickup); //아이템 줍는소리
		putSound(se_jump, sp_jump); //점프소리
		auSE.Play ();
	}

	public void soundBook()
	{
		putSound(se_adkey, sp_adkey);
		auSE.GetComponent<AudioSource>().pitch = 1.2f;
		auSE.Play();
	}


	
}
