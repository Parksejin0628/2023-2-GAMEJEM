using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidbody2D;

    public float moveSpeed = 3.0f;
    public float jumpPower = 10.0f;
    Vector2 wasdVector;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rigidbody2D.velocity = new Vector2(wasdVector.x * moveSpeed, rigidbody2D.velocity.y);
    }

    void OnMove(InputValue value)   //방향키를 누르거나 땔 때 호출되는 함수이다.
    {
        wasdVector = value.Get<Vector2>();     //현재 방향키의 정보를 담은 value를 Vector2로 치환한다. InputValue인 value를 사용하기 편하게 Vector2로 치환한 것이다.

        //점프도 addForce로 처리하면서 maxSpeed를 정해둔다음 점프버튼을 누른 길이에 따라 점프 높이를 바뀌도록 하면 어떨까?
    }

    void OnJump()   //스페이스바를 누르면 호출되는 함수이다.
    {
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpPower);
    }

}
