using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    private Rigidbody2D rigid;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update() // 하나의 생명 주기마다 호출되는 함수.
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        // Input.GetAxisRaw 를 사용하면 더욱 명확한 컨트롤을 구현할 수 있음.
        inputVec.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate() // 물리 엔진 변수는 Update가 아닌 이곳에서 사용.
    {
        // 1. 힘을 준다.
        // rigid.AddForce(inputVec);
        
        // 2. 속도 제어.
        // rigid.velocity = inputVec;
        
        // 3. 위치 이동.
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime; 
        // normalized 벡터 값의 크기가 1이 되도록 좌표가 수정된 값을 리턴함.
        // time.fixedDeltaTime 물리 프레임 하나가 소비한 시간.
        rigid.MovePosition(rigid.position + nextVec); // MovePosition은 위치 이동이라 현재 위치도 더해주어야 함.
    } 
    
}
