using System.Collections;
using UnityEngine;

public class Monster_1 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f; // 총알 속도
    public float raycastDistance = 100f; // 레이캐스트 거리
    public string playerTag = "Player"; // 플레이어 태그
    Animator m1_anim;
    private bool isFacingRight = true;
    private Transform playerTransform;
    private SpriteRenderer spriteRenderer;
    public Vector2 direction;

    public float attackspeed = 2f;
    void Start()
    {
        m1_anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerTransform = GameObject.FindGameObjectWithTag(playerTag).transform;

        // Start the shooting coroutine
        StartCoroutine(ShootEveryThreeSeconds());
    }

    IEnumerator ShootEveryThreeSeconds()
    {
        while (true)
        {

            yield return new WaitForSeconds(attackspeed);

            // Check for the player and shoot
            RaycastHit2D hitLeft = Physics2D.Raycast(firePoint.position, Vector2.left, raycastDistance);
            RaycastHit2D hitRight = Physics2D.Raycast(firePoint.position, Vector2.right, raycastDistance);

            if ((hitLeft.collider != null && hitLeft.collider.CompareTag(playerTag)))
            {
                direction = Vector2.left;
                m1_anim.SetTrigger("isAttack");
                AudioManager.Inst.PlaySFX("shell_spit");
                FlipToPlayer();


            }
            else if ((hitRight.collider != null && hitRight.collider.CompareTag(playerTag)))
            {

                direction = Vector2.right;
                m1_anim.SetTrigger("isAttack");
                AudioManager.Inst.PlaySFX("shell_spit");
                FlipToPlayer();


            }
        }
    }
    private void FlipToPlayer()
    {
        // Compare the player's position with the monster's position
        if (playerTransform.position.x > transform.position.x && isFacingRight)
        {
            Flip();
        }
        else if (playerTransform.position.x < transform.position.x && !isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        // 현재 상태를 반전
        isFacingRight = !isFacingRight;

        // SpriteRenderer를 이용하여 스프라이트를 뒤집음
        spriteRenderer.flipX = !isFacingRight;
    }

    public void ShootBullet()
    {
        // 총알을 생성하고 발사 방향을 설정
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        Destroy(bullet, 4f);
    }
}
