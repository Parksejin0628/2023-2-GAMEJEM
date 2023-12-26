using System.Collections;
using UnityEngine;

public class Monster_1 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f; // �Ѿ� �ӵ�
    public float raycastDistance = 100f; // ����ĳ��Ʈ �Ÿ�
    public string playerTag = "Player"; // �÷��̾� �±�
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
        // ���� ���¸� ����
        isFacingRight = !isFacingRight;

        // SpriteRenderer�� �̿��Ͽ� ��������Ʈ�� ������
        spriteRenderer.flipX = !isFacingRight;
    }

    public void ShootBullet()
    {
        // �Ѿ��� �����ϰ� �߻� ������ ����
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        Destroy(bullet, 4f);
    }
}
