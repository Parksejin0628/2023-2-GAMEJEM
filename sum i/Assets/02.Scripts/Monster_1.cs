using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_1 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f; // 총알 속도


    // Start is called before the first frame update
    void Start()
    {

    }

    public void ShootBullet()
    {
        // 총알을 생성하고 발사 방향을 설정
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.left * bulletSpeed;
        Destroy(bullet, 4f);

    }

}
