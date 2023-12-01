using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForBGM : MonoBehaviour
{
    [System.Serializable]
    public struct BgmType
    {
        public string name;
        public AudioClip audio;
    }

    // Inspector 에표시할 배경음악 목록
    public BgmType[] BGMList;

    public AudioSource BGMfirst, BGM2, BGMbook;
    private string NowBGMname = "";

    int i; //bgmtest


    public float vols_f = 0.8f;

    void Start()
    {
        //BGMfirst.clip = BGMList[2].audio;
        //BGMfirst.loop = true;

        //BGM2.clip = BGMList[0].audio;
        //BGM2.loop = true;

        if (BGMList.Length > 0) PlayBGM(BGMList[0].name);

        //BGM2.Stop(); //특정 지역의 위치값에서 실행되기 위해 초기에 필요 없음

    }




    public void PlayBGM(string name)
    {
        if (NowBGMname.Equals(name)) return;


        for (int i = 0; i < BGMList.Length; ++i)
            if (BGMList[i].name.Equals(name))
            {
                BGMfirst.Play();
                NowBGMname = name;
            }
    }


    public void newchangeBGM()
    {
        BGMfirst.clip = BGMList[2].audio;
        BGM2.clip = BGMList[3].audio;

        BGMfirst.GetComponent<AudioSource>().volume = 1f * vols_f;

        BGM2.GetComponent<AudioSource>().volume = 0f;
        BGM2.GetComponent<AudioSource>().pitch = 0.8f;

        //BGMfirst.Play();
        BGM2.Play();
    }



    public void cha() //test
    {
        BGMfirst.clip = BGMList[i].audio; //타이틀브금
        BGMfirst.Play();

        if (i >= 4)
        {
            i = 0;
        }
        else
        {
            i++;
        }
    }

    public void forbook() //도감 열었을 때 배경음이 줄어들도록 음향 효과
    {
        BGMbook.GetComponent<AudioSource>().spatialBlend = 0.9f;
    }

}
