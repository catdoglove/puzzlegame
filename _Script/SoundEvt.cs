using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundEvt : MonoBehaviour {

	//시스템 소리
	public AudioClip sp_start, sp_pickup, sp_damage, sp_open_object, sp_jump, sp_water_walk;
	public AudioSource se_start, se_pickup, se_damage, se_open_object, se_jump, se_water_walk;

	//이벤트 관련
	public AudioClip sp_box_etc, sp_box_open, sp_crow_attack;
	public AudioSource se_box_etc, se_box_open, se_crow_attack;

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





	public void putSound(AudioSource audioSE, AudioClip audioCP)
	{
		audioSE = gameObject.GetComponent<AudioSource>();
		audioSE.clip = audioCP;
		auSE = audioSE;
		auCP= audioCP;
	}


	// Use this for initialization
	void Start()
	{
		StartCoroutine("soundKeyboard");
	}


	public void soundSample(){

		//putSound(se_pickup, sp_pickup); //아이템 줍는소리
		putSound(se_jump, sp_jump); //점프소리
		auSE.Play ();
	}


	IEnumerator soundKeyboard()
	{
		while (true)
		{
			if (Input.GetKey(KeyCode.Space))
			{
				putSound(se_talk_low, sp_talk_low);
				//auSE.GetComponent<AudioSource>().pitch = 1.1f; 캐릭터마다 말하는 속도 조절
				auSE.Play();
			}
			else if (Input.GetKey(KeyCode.E))
			{
				putSound(se_item_open, sp_item_open);
				auSE.Play();
			}
			/*
			else if (Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.D)) //아이템창 열렸을 때
			{
				putSound(se_adkey, sp_adkey);
				auSE.Play();
			}
			else if (Input.GetKey(KeyCode.Space))
			{
				putSound(se_item_select, sp_item_select);
				auSE.Play();
			}
			*/

			yield return new WaitForSeconds(0.1f);
		}
	}


}
