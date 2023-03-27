using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLine : MonoBehaviour
{
    // ball과 line의 SpriteRenderer 컴포넌트를 참조할 변수
    public SpriteRenderer ball;
    public SpriteRenderer line;

    // ball의 왼쪽 끝과 오른쪽 끝의 좌표를 저장할 변수
    private Vector3 leftEnd;
    private Vector3 rightEnd;

    // line의 크기를 조절할 변수
    private float lineScale;

    // Start is called before the first frame update
    void Start()
    {
        // ball의 왼쪽 끝과 오른쪽 끝의 좌표를 계산한다.
        // ball의 크기는 100x100 픽셀이므로 반지름은 50 픽셀이다.
        leftEnd = ball.transform.position - new Vector3(5f, 0f, 0f);
        rightEnd = ball.transform.position + new Vector3(5f, 0f, 0f);

        // line의 크기를 조절한다.
        // line의 크기는 100x100 픽셀이므로 화면 우측하단까지 이어지려면 x축으로 확장해야 한다.
        // 화면 우측하단의 x좌표는 Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, 0f)).x로 구할 수 있다.- rightEnd.x/ 100f
        lineScale = (Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, 0f)).x ) ;
        line.transform.localScale = new Vector3(lineScale, 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        // ball의 움직임에 따라 왼쪽 끝과 오른쪽 끝의 좌표를 갱신한다.
        leftEnd = ball.transform.position - new Vector3(5f, 0f, 0f);
        rightEnd = ball.transform.position + new Vector3(5f, 0f, 0f);

        // line의 위치와 각도를 조절한다.
        // line의 중심은 ball의 오른쪽 끝과 화면 우측하단의 중간점이다.
        // line의 각도는 ball의 오른쪽 끝과 화면 우측하단을 잇는 벡터와 x축 사이의 각도이다.
        Vector3 center = (rightEnd + Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, 0f))) / 2f;
        Vector3 direction = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, 0f)) - rightEnd;
        float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg)/1.5f+7;

        line.transform.position = center;
        line.transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}

