using System.Collections;
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


    public void changeShader()
    {
        Mcamera.SetActive(false);

        //photo.SCShader = Shader.Find("CameraFilterPack/Blend2Camera_Overlay");
        //photo.filterchoice = CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.Overlay;

        effectShaderimg.GetComponent<Image>().sprite = effectImg[3];

          photo.SCShader = Shader.Find("CameraFilterPack/Blend2Camera_Multiply");
          photo.filterchoice = CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.Multiply;

        Mcamera.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
