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
    public float rayDistance = 0.2f;
    public int maxJumpCount = 1;
    public int jumpCount = 1;

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
        if (rigidbody2D.velocity.y < 0 && CheckIsGround(LayerMask.GetMask("Ground"), out RaycastHit2D hit))
        {
            jumpCount = maxJumpCount;
        }
    }

    void Move()
    {
        rigidbody2D.velocity = new Vector2(wasdVector.x * moveSpeed, rigidbody2D.velocity.y);
    }
    bool CheckIsGround(LayerMask layerMask, out RaycastHit2D hit) //layerMask ��ũ�� ���� ������ üũ�ϴ� �Լ�
    {
        hit = Physics2D.BoxCast(transform.position + Vector3.down * transform.localScale.y / 4, transform.localScale / 3, 0, Vector2.down, rayDistance, layerMask);
        if (hit == true)
        {
            return true;
        }
        return false;
    }

    void OnMove(InputValue value)   //����Ű�� �����ų� �� �� ȣ��Ǵ� �Լ��̴�.
    {
        wasdVector = value.Get<Vector2>();     //���� ����Ű�� ������ ���� value�� Vector2�� ġȯ�Ѵ�. InputValue�� value�� ����ϱ� ���ϰ� Vector2�� ġȯ�� ���̴�.

        //������ addForce�� ó���ϸ鼭 maxSpeed�� ���صд��� ������ư�� ���� ���̿� ���� ���� ���̸� �ٲ�� �ϸ� ���?
    }

    void OnJump()   //�����̽��ٸ� ������ ȣ��Ǵ� �Լ��̴�.
    {
        if(CheckIsGround(LayerMask.GetMask("Ground"), out RaycastHit2D hit) && jumpCount == maxJumpCount)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpPower);
            jumpCount--;
        }
        else if(jumpCount > 0)
        {
            if (jumpCount == maxJumpCount)
            {
                jumpCount--;
            }
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpPower);
            jumpCount--;
        }
    }

}
