using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class enemy : MonoBehaviour
{
    [SerializeField]
    private Sprite sprite;
    BulletPool pool;
    public float speed = 5f;
    public float damage = 10f;
    public float FIreRate = 1f;
    private float shootTimer;
    private GameObject player;
    public GameObject gun1;
    public float bulletLifeTime = 3f;
    private bool CanFire = false;
    void Start()
    {
        player = GameObject.Find("Player");
        shootTimer = FIreRate;
        pool=GameObject.Find("Pool").GetComponent<BulletPool>();
    }

    void FixedUpdate()
    {
        shootTimer += Time.fixedDeltaTime;
        if (CanFire)
        {
            if (shootTimer >= 1 / FIreRate)
            {
                Shoot();
                shootTimer = 0f;
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = pool.GetBullet();
        bullet.GetComponent<SpriteRenderer>().sprite = sprite;
        if (bullet == null) return;

        bullet.transform.position = gun1.transform.position;
        bullet.transform.right = player.transform.position - transform.position;
        bullet.SetActive(true);
        bullet.GetComponent<Bullet>().setLifeTime(bulletLifeTime);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = (player.transform.position - gun1.transform.position).normalized * speed;
    }

    public void SetCanFire(bool canFire)
    {
        CanFire = canFire;
    }

    public bool GetCanFire()
    {
        return CanFire;
    }
}