using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class ShaderEffect : MonoBehaviour
{
    public CameraFilterPack_Blend2Camera_PhotoshopFilters photo;
    public CameraFilterPack_Colors_Adjust_PreFilters photoF;
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


    /// <summary>
    /// 동굴안
    /// </summary>
    public void changeShader8()
    {
        Mcamera.SetActive(false);


        photo.SwitchCameraToCamera2 = 1f;
        photo.BlendFX = 1f;
        effectShaderimg.GetComponent<Image>().sprite = effectImg[6];

        photo.SCShader = Shader.Find("CameraFilterPack/Blend2Camera_Overlay");
        photo.filterchoice = CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.Multiply;

        Mcamera.SetActive(true);
    }


    /// <summary>
    /// 동굴안B1
    /// </summary>
    public void changeShader9()
    {
        Mcamera.SetActive(false);


        photo.SwitchCameraToCamera2 = 1f;
        photo.BlendFX = 1f;
        effectShaderimg.GetComponent<Image>().sprite = effectImg[7];

        photo.SCShader = Shader.Find("CameraFilterPack/Blend2Camera_Multiply");
        photo.filterchoice = CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.Multiply;

        Mcamera.SetActive(true);
    }
    /// <summary>
    /// 동굴안B2
    /// </summary>
    public void changeShader10()
    {
        Mcamera.SetActive(false);


        photo.SwitchCameraToCamera2 = 1f;
        photo.BlendFX = 1f;
        effectShaderimg.GetComponent<Image>().sprite = effectImg[8];

        photo.SCShader = Shader.Find("CameraFilterPack/Blend2Camera_Multiply");
        photo.filterchoice = CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.Multiply;

        Mcamera.SetActive(true);
    }

    /// <summary>
    /// 동굴안D5
    /// </summary>
    public void changeShader11()
    {
        Mcamera.SetActive(false);


        photo.SwitchCameraToCamera2 = 1f;
        photo.BlendFX = 1f;
        effectShaderimg.GetComponent<Image>().sprite = effectImg[9];

        photo.SCShader = Shader.Find("CameraFilterPack/Blend2Camera_Multiply");
        photo.filterchoice = CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.Multiply;

        Mcamera.SetActive(true);
    }

    /// <summary>
    /// 동굴안D6
    /// </summary>
    public void changeShader12()
    {
        Mcamera.SetActive(false);


        photo.SwitchCameraToCamera2 = 1f;
        photo.BlendFX = 1f;
        effectShaderimg.GetComponent<Image>().sprite = effectImg[10];

        photo.SCShader = Shader.Find("CameraFilterPack/Blend2Camera_Multiply");
        photo.filterchoice = CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.Multiply;

        Mcamera.SetActive(true);
    }

    /// <summary>
    /// 동굴안C
    /// </summary>
    public void changeShader13()
    {
        Mcamera.SetActive(false);


        photo.SwitchCameraToCamera2 = 1f;
        photo.BlendFX = 1f;
        effectShaderimg.GetComponent<Image>().sprite = effectImg[8];

        photo.SCShader = Shader.Find("CameraFilterPack/Blend2Camera_Multiply");
        photo.filterchoice = CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.Multiply;

        Mcamera.SetActive(true);
    }

    /// <summary>
    /// 동굴안C
    /// </summary>
    public void changeShader14()
    {
        Mcamera.SetActive(false);


        photo.SwitchCameraToCamera2 = 1f;
        photo.BlendFX = 1f;
        effectShaderimg.GetComponent<Image>().sprite = effectImg[11];

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

    /// <summary>
    /// 맵 분위기 필터 효과 (깊은 숲에서 필요)
    /// </summary>
    public void changePhotoFilter()
    {
        photoF.filterchoice = CameraFilterPack_Colors_Adjust_PreFilters.filters.PopRocket;
        photoF.FadeFX = 0.5f;

        /* 기본값
         * photoF.filterchoice = CameraFilterPack_Colors_Adjust_PreFilters.filters.DarkPink;  
         * photoF.FadeFX = 0.4f; */
    }

    // Update is called once per frame
    void Update()
    {
    }
}
