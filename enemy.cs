using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{ 
    BulletPool pool; 
    public float speed = 5f;
    public float damage = 10f;
    public float lifeTime = 5f;
    private GameObject player;
    public GameObject gun1;
    
    void Start()
    {
        Destroy(gameObject, lifeTime);
        player = GameObject.FindGameObjectWithTag("Player");
        pool=GameObject.Find("Pool").GetComponent<BulletPool>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        GameObject bullet = pool.GetBullet();
        bullet.transform.position = gun1.transform.position;
        
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = (player.transform.position-gun1.transform.position).normalized * speed;

    }
}
