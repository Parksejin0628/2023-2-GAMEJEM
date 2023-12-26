using System.Collections;
using UnityEngine;

public class Monster_2 : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Animator m2_anim;
    public float moveSpeed; // Adjust the speed as needed
    public float pauseTime = 2f; // Adjust the pause time as needed
    bool isPaused = false;
    bool isFacingRight = true;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        m2_anim = GetComponent<Animator>();
        StartCoroutine(RandomPause());
    }

    void Update()
    {
        if (!isPaused)
        {
            Move();
        }
    }

    void Move()
    {
        m2_anim.SetBool("isRun", true);

        if (!isPaused)
        {
            float moveDirection = isFacingRight ? 1 : -1;
            Vector3 movement = new Vector3(moveDirection * moveSpeed * Time.deltaTime, 0, 0);
            transform.Translate(movement);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Flip();
        }
    }

    void Flip()
    {
        isFacingRight = Random.Range(0, 2) == 0; // Randomly set isFacingRight to true or false
        spriteRenderer.flipX = !isFacingRight;
    }

    IEnumerator RandomPause()
    {
        while (true)
        {
            Flip();
            m2_anim.SetBool("isRun", false);
            isPaused = !isPaused;
            yield return new WaitForSeconds(Random.Range(1f, pauseTime));
        }
    }
}
