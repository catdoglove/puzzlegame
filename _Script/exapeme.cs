using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exapeme : MonoBehaviour
{
    private float moveSpeed = 5.0f;                 //이동 속도
    private Rigidbody2D rigid2D;
    // Start is called before the first frame update
    void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");   //좌우 이동
        float y = Input.GetAxisRaw("Vertical");     //상하 이동

        // Rigidbody2D 컴포넌트에 있는 속력(velocity) 변수 설정
        rigid2D.velocity = new Vector3(x, y, 0) * moveSpeed;
    }
}
