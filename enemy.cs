using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    BulletPool pool;
    public float speed = 5f;
    public float damage = 10f;
    public float lifeTime = 5f;
    public float shootInterval = 1f;
    private float shootTimer;

    private GameObject player;
    public GameObject gun1;

    void Start()
    {
        Destroy(gameObject, lifeTime);
        player = GameObject.FindGameObjectWithTag("Player");
        pool = GameObject.Find("Pool").GetComponent<BulletPool>();
        shootTimer = shootInterval;
    }

    void FixedUpdate()
    {
        shootTimer += Time.fixedDeltaTime;

        if (shootTimer >= shootInterval)
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
        bullet.transform.rotation = Quaternion.identity;
        bullet.SetActive(true);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = (player.transform.position - gun1.transform.position).normalized * speed;
    }
}