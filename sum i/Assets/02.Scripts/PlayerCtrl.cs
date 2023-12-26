using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    //움직임과 관련된 변수
    public float moveSpeed = 3.0f;
    public float jumpPower = 10.0f;
    public float rayDistance = 0.2f;
    public int maxJumpCount = 1;
    public int jumpCount = 1;
    //플레이어 정보
    public int maxHp = 8;
    public int currentHp = 0;
    //기타
    public float jumpingBlockPower = 20.0f;

    Vector2 wasdVector;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        RaycastHit2D hit;
        CheckIsGround(LayerMask.GetMask("Ground"), out hit);
        Move();
        if (rigidbody2D.velocity.y < 0 && hit == true)
        {
            jumpCount = maxJumpCount;
        }
        if(hit == true && hit.collider.CompareTag("JumpingBlock"))
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpingBlockPower);
        }
        anim.SetBool("isWalk", rigidbody2D.velocity.x != 0);
        anim.SetFloat("velocityY", rigidbody2D.velocity.y);
        anim.SetBool("isFloat", !hit);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("Orange") && currentHp<maxHp)
        {
            currentHp++;
            coll.gameObject.SetActive(false);
        }
    }

    void Move()
    {
        rigidbody2D.velocity = new Vector2(wasdVector.x * moveSpeed, rigidbody2D.velocity.y); 
        if(wasdVector.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        if (wasdVector.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
    bool CheckIsGround(LayerMask layerMask, out RaycastHit2D hit) //layerMask 태크를 가진 땅인지 체크하는 함수
    {
        hit = Physics2D.BoxCast(transform.position + Vector3.down * transform.localScale.y / 4, transform.localScale / 3, 0, Vector2.down, rayDistance, layerMask);
        if (hit == true)
        {
            return true;
        }
        return false;
    }

    void OnMove(InputValue value)   //방향키를 누르거나 땔 때 호출되는 함수이다.
    {
        wasdVector = value.Get<Vector2>();     //현재 방향키의 정보를 담은 value를 Vector2로 치환한다. InputValue인 value를 사용하기 편하게 Vector2로 치환한 것이다.

        //점프도 addForce로 처리하면서 maxSpeed를 정해둔다음 점프버튼을 누른 길이에 따라 점프 높이를 바뀌도록 하면 어떨까?
    }

    void OnJump()   //스페이스바를 누르면 호출되는 함수이다.
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
                if(jumpCount <= 0)
                {
                    return;
                }
            }
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpPower);
            jumpCount--;
        }
    }

}
