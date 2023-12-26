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

    void OnMove(InputValue value)   //����Ű�� �����ų� �� �� ȣ��Ǵ� �Լ��̴�.
    {
        wasdVector = value.Get<Vector2>();     //���� ����Ű�� ������ ���� value�� Vector2�� ġȯ�Ѵ�. InputValue�� value�� ����ϱ� ���ϰ� Vector2�� ġȯ�� ���̴�.

        //������ addForce�� ó���ϸ鼭 maxSpeed�� ���صд��� ������ư�� ���� ���̿� ���� ���� ���̸� �ٲ�� �ϸ� ���?
    }

    void OnJump()   //�����̽��ٸ� ������ ȣ��Ǵ� �Լ��̴�.
    {
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpPower);
    }

}
