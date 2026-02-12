using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lastLoopMap : MonoBehaviour
{
    public Transform[] backgrounds;       // 배경 스프라이트들을 담은 Transform 배열
    public Transform player;              // 플레이어 Transform
    public float parallaxFactor = 0.05f;
    public float inputFallbackSpeed = 3f;
    public float[] layerParallaxFactors;
    public float shiftMultiplier = 2f;  // Shift 누를 때 배경 속도 배수

    public Camera mainCamera;                    // 비어있으면 Start에서 Camera.main을 사용
    public float cameraSizeIncreaseSpeed;   // 이동 중 카메라 size 증가 속도 (단위: size/sec)
    public float maxCameraSize;             // 최대 카메라 size
    private float baseCameraSize = 0f;
    public float restoreCameraSpeed;
    public GameObject playerOpj;

    // PhotoFilters 관련 (Camera Filter Pack의 PreFilters 스크립트)
    public CameraFilterPack_Colors_Adjust_PreFilters photoFilter; // 인스펙터에 연결
    public float fadeIncreaseSpeed;   // 이동 중 FadeFX 증가 속도 (단위: Fade/sec)
    public float fadeRestoreSpeed;    // 멈출 때 FadeFX 복구 속도
    public float maxFadeFX = 0.6f;             // 최대 FadeFX 값
    private float baseFadeFX = 0.2f;

    // 카메라 사이즈 트리거 관련
    public float triggerCameraSize = 6f;     // 이 값에 도달하면 PlayerPrefs를 설정
    public float triggerTolerance = 0.02f;   // 부동소수점 오차 허용치
    private bool cameraSizeTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        if (backgrounds != null && backgrounds.Length > 0)
        {
            if (layerParallaxFactors == null || layerParallaxFactors.Length != backgrounds.Length)
            {
                layerParallaxFactors = new float[backgrounds.Length];
                for (int i = 0; i < layerParallaxFactors.Length; i++)
                    layerParallaxFactors[i] = parallaxFactor;
            }
        }


        if (mainCamera == null)
            mainCamera = Camera.main;

        if (mainCamera != null)
            baseCameraSize = mainCamera.orthographicSize;
        // PhotoFilter 초기값이 있으면 사용
        if (photoFilter != null)
            baseFadeFX = photoFilter.FadeFX;

        //최종장에서는 캐릭터 사이즈가 줄어드는데 이걸 어딘가에 넣어줘야한다 
        //  playerOpj.transform.localScale = new Vector3(0.69f, 0.69f, 1f);
        //스피드 기본속도 2f 뛰는속도 4f  CharMove.cs에 있는 Speed = 3f과 5f항목;
    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerPrefs.GetInt("lastLoopMapOn") == 1)
        {
            if (player == null || backgrounds == null || backgrounds.Length == 0)
                return;

            // 캐릭터 위치와 무관하게 키보드 좌/우 입력으로 배경을 이동
            float h = Input.GetAxisRaw("Horizontal"); // -1, 0, 1
            if (Mathf.Abs(h) > 0f)
            {
                bool isShift = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

                for (int i = 0; i < backgrounds.Length; i++)
                {
                    float factor = (layerParallaxFactors != null && i < layerParallaxFactors.Length)
                        ? layerParallaxFactors[i]
                        : parallaxFactor;

                    // Shift 누르면 레이어별 계수에 배수 적용
                    float effectiveFactor = factor * (isShift ? shiftMultiplier : 1f);

                    // 음수 처리: 플레이어가 오른쪽으로 가면 배경은 왼쪽으로 이동
                    Vector3 move = new Vector3(-h * inputFallbackSpeed * effectiveFactor * Time.deltaTime, 0f, 0f);
                    backgrounds[i].position += move;
                }

                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))//오른쪽 이동
                {
                    if (mainCamera != null)
                        mainCamera.orthographicSize = Mathf.Min(maxCameraSize,
                            mainCamera.orthographicSize + cameraSizeIncreaseSpeed * Time.deltaTime);

                    if (PlayerPrefs.GetInt("triggerCameraSizeOn", 0) == 1)
                    {
                        float shiftMult = (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) ? shiftMultiplier : 1f;
                        if (photoFilter != null)
                            photoFilter.FadeFX = Mathf.Min(maxFadeFX, photoFilter.FadeFX + fadeIncreaseSpeed * shiftMult * Time.deltaTime);
                    }
                }
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))//왼쪽 이동
                {
                    if (mainCamera != null)
                        mainCamera.orthographicSize = Mathf.MoveTowards(mainCamera.orthographicSize,
                            baseCameraSize, restoreCameraSpeed * Time.deltaTime);

                    // 왼쪽 이동일 때는 FadeFX 감소 (최솟값은 baseFadeFX)
                    float shiftMult2 = (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) ? shiftMultiplier : 1f;
                    if (photoFilter != null)
                        photoFilter.FadeFX = Mathf.Max(baseFadeFX, photoFilter.FadeFX - fadeIncreaseSpeed * shiftMult2 * Time.deltaTime);
                }

                if (mainCamera.orthographicSize >= 7.2f || mainCamera.orthographicSize <= 5.07f) //끝에 도달하면 캐릭터 자유이동
                {
                    PlayerPrefs.SetInt("autoBGstartLast", 0);
                    PlayerPrefs.SetInt("lastLoopMapOn", 0);
                }
            }

            CheckCameraSizeAndEnableLastLoop();

        }

    }


    // 카메라 사이즈가 triggerCameraSize 범위 안에 들어오면 PlayerPrefs "lastLoopMapOn"을 1로 설정
    private void CheckCameraSizeAndEnableLastLoop()
    {
        if (cameraSizeTriggered)
            return;

        if (mainCamera == null)
            mainCamera = Camera.main;

        if (mainCamera == null)
            return;

        float currentSize = mainCamera.orthographicSize;
        if (Mathf.Abs(currentSize - triggerCameraSize) <= triggerTolerance)
        {
            PlayerPrefs.SetInt("triggerCameraSizeOn", 1);
        }
    }
}

