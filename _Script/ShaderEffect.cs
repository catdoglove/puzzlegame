﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShaderEffect : MonoBehaviour
{
    public CameraFilterPack_Blend2Camera_PhotoshopFilters photo;
    public GameObject Mcamera, effectShaderimg;
    public Sprite[] effectImg;

    // Start is called before the first frame update

    /// <summary>
    /// 카메라 필터 교체 방법
    /// 메인카메라를 껐다가 킨다.
    /// </summary>
    void Start()
    {
    }

    /// <summary>
    /// 도교입구
    /// </summary>
    public void changeShader1()
    {
        Mcamera.SetActive(false);

        photo.SwitchCameraToCamera2 = 1f;
        photo.BlendFX = 1f;

        effectShaderimg.GetComponent<Image>().sprite = effectImg[0];

        photo.SCShader = Shader.Find("CameraFilterPack/Blend2Camera_Overlay");
        photo.filterchoice = CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.Overlay;

        Mcamera.SetActive(true);
    }

    /// <summary>
    /// 물맵
    /// </summary>
    public void changeShader2()
    {
        Mcamera.SetActive(false);

        photo.SwitchCameraToCamera2 = 1f;
        photo.BlendFX = 1f;

        effectShaderimg.GetComponent<Image>().sprite = effectImg[1];

        photo.SCShader = Shader.Find("CameraFilterPack/Blend2Camera_Overlay");
        photo.filterchoice = CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.Overlay;

        Mcamera.SetActive(true);
    }

    /// <summary>
    /// 숲히든
    /// </summary>
    public void changeShader3()
    {
        Mcamera.SetActive(false);

        photo.SwitchCameraToCamera2 = 1f;
        photo.BlendFX = 1f;

        effectShaderimg.GetComponent<Image>().sprite = effectImg[2];

        photo.SCShader = Shader.Find("CameraFilterPack/Blend2Camera_Multiply");
        photo.filterchoice = CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.Multiply;

        Mcamera.SetActive(true);
    }

    /// <summary>
    /// 동굴길
    /// </summary>
    public void changeShader4()
    {
        Mcamera.SetActive(false);

        photo.SwitchCameraToCamera2 = 1f;
        photo.BlendFX = 1f;

        effectShaderimg.GetComponent<Image>().sprite = effectImg[3];

        photo.SCShader = Shader.Find("CameraFilterPack/Blend2Camera_Multiply");
        photo.filterchoice = CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.Multiply;

        Mcamera.SetActive(true);
    }

    /// <summary>
    /// 동굴입구
    /// </summary>
    public void changeShader5()
    {
        Mcamera.SetActive(false);


        photo.SwitchCameraToCamera2 = 1f;
        photo.BlendFX = 1f;
        effectShaderimg.GetComponent<Image>().sprite = effectImg[4];

        photo.SCShader = Shader.Find("CameraFilterPack/Blend2Camera_Overlay");
        photo.filterchoice = CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.Overlay;

        Mcamera.SetActive(true);
    }

    public void changeShader6()
    {
        Mcamera.SetActive(false);


        photo.SwitchCameraToCamera2 = 1f;
        photo.BlendFX = 1f;
        effectShaderimg.GetComponent<Image>().sprite = effectImg[5];

        photo.SCShader = Shader.Find("CameraFilterPack/Blend2Camera_Multiply");
        photo.filterchoice = CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.Multiply;

        Mcamera.SetActive(true);
    }

    public void changeShader7()
    {
        Mcamera.SetActive(false);


        photo.SwitchCameraToCamera2 = 1f;
        photo.BlendFX = 1f;
        effectShaderimg.GetComponent<Image>().sprite = effectImg[6];

        photo.SCShader = Shader.Find("CameraFilterPack/Blend2Camera_Multiply");
        photo.filterchoice = CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.Multiply;

        Mcamera.SetActive(true);
    }


    public void OffShader()
    {
        Mcamera.SetActive(false);

        photo.SwitchCameraToCamera2 = 0f;
        photo.BlendFX = 0f;

        Mcamera.SetActive(true);
    }


    public void ShaderFilp()
    {
        if (effectShaderimg.transform.rotation.y == 0)
        {
            effectShaderimg.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            effectShaderimg.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
