using System.Collections;
using UnityEngine;

public class Monster_3 : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Animator m3_anim;
    Rigidbody2D Rig2;
    public float moveSpeed; 
    public float jumpForce; 
    public LayerMask Ground; 
    public float pauseTime = 2f; 
    bool isPaused = false;
    bool isFacingRight = true;
    bool isGrounded = true;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        m3_anim = GetComponent<Animator>();
        Rig2 = GetComponent<Rigidbody2D>();
        StartCoroutine(RandomPause());
    }

    void Update()
    {
        Debug.Log(isGrounded);


        if (!isPaused)
        {
            Move();

            if (isGrounded)
            {
                Rig2.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                isGrounded = false;
            }
        }
    }

    void Move()
    {
        m3_anim.SetBool("isRun", true);

        if (!isPaused)
        {
            float moveDirection = isFacingRight ? 1 : -1;
            Vector3 movement = new Vector3(moveDirection * moveSpeed * Time.deltaTime, 0, 0);
            transform.Translate(movement);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & Ground) != 0)
        {
            isGrounded = true;
        }
        else
        {
            Flip();
        }
    }

    void Flip()
    {
        isFacingRight = Random.Range(0, 2) == 0;
        spriteRenderer.flipX = !isFacingRight;
    }

    IEnumerator RandomPause()
    {
        while (true)
        {
            Flip();
            m3_anim.SetBool("isRun", false);
            isPaused = !isPaused;
            yield return new WaitForSeconds(Random.Range(1f, pauseTime));
        }
    }
}
