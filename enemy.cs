using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class enemy : MonoBehaviour
{
    BulletPool pool;
    public float speed = 5f;
    public float damage = 10f;
    public float FIreRate = 1f;
    private float shootTimer;

    private GameObject player;
    public GameObject gun1;
    public float bulletLifeTime = 3f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pool = GameObject.Find("Pool").GetComponent<BulletPool>();
        shootTimer = FIreRate;
    }

    void FixedUpdate()
    {
        shootTimer += Time.fixedDeltaTime;

        if (shootTimer >= 1/FIreRate)
        {
            Shoot();
            shootTimer = 0f;
        }
    }

    void Shoot()
    {
        GameObject bullet = pool.GetBullet();
        if (bullet == null) return;

        bullet.transform.position = gun1.transform.position;
        bullet.transform.right = player.transform.position - transform.position;
        bullet.SetActive(true);
        bullet.GetComponent<Bullet>().setLifeTime(bulletLifeTime);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = (player.transform.position - gun1.transform.position).normalized * speed;
    }
}