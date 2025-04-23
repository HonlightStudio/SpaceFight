using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{ 
    BulletPool Bullet; 
    public float speed = 5f;
    public float damage = 10f;
    public float lifeTime = 5f;
    private GameObject player;
    public GameObject gun1;
    
    void Start()
    {
        Destroy(gameObject, lifeTime);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject bullet = Bullet.GetBullet();
        gun1.transform.LookAt(player.transform.position);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(gun1.transform.forward * speed);
        
    }
}
