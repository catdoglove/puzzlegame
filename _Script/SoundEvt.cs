using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundEvt : MonoBehaviour {

	//시스템 소리
	public AudioClip sp_start, sp_pickup, sp_damage, sp_open_object, sp_jump, sp_water_walk;
	public AudioSource se_start, se_pickup, se_damage, se_open_object, se_jump, se_water_walk;

	//이벤트 관련
	public AudioClip sp_box_etc, sp_box_open, sp_crow_attack, sp_hide1;
	public AudioSource se_box_etc, se_box_open, se_crow_attack, se_hide1;

	//걷기 관련
	public AudioClip sp_walk, sp_walk_wood;
	public AudioSource se_walk, se_walk_wood;





	//아이템 사용 관련
	public AudioClip sp_item_fail, sp_item_success, sp_item_use;
	public AudioSource se_item_fail, se_item_success, se_item_use;


	//아이템 창 관련
	public AudioClip sp_item_open, sp_item_select, sp_adkey;
	public AudioSource se_item_open, se_item_select, se_adkey;


	//대화 관련
	public AudioClip sp_talk, sp_talk_low;
	public AudioSource se_talk, se_talk_low;

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
	/// 까마귀의 습격
	/// </summary>
	public void soundCrowAttack()
	{
		putSound(se_crow_attack, sp_crow_attack);
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
	/// 숨는소리
	/// </summary>
	public void soundHide1()
	{
		putSound(se_hide1, sp_hide1);
		auSE.Play();
	}


	public void putSound(AudioSource audioSE, AudioClip audioCP)
	{
		audioSE = gameObject.GetComponent<AudioSource>();
		audioSE.clip = audioCP;
		auSE = audioSE;
		auCP= audioCP;
		auSE.GetComponent<AudioSource>().pitch = 1f;
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
