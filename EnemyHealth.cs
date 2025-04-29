 using System;
 using UnityEngine;

 public class EnemyHealth : MonoBehaviour
 {
     [SerializeField] float health = 10f;
     /*[SerializeField]
     Bullet bullet;*/
     bool isAlive = true;
     [SerializeField]
     GameObject deathEffect;
     public void FixedUpdate()
     {
         if (health <= 0)
         {
             Death();
         }
     }

     private void OnTriggerEnter2D(Collider2D other)
     {
         if (other.gameObject.name.Contains("Bullet_Player")){
         health -= other.gameObject.GetComponent<Bullet>().damage;
         }
     }

     public void Death()
     {
         if (isAlive)
         {
             isAlive = false;
             GameObject Smoke= Instantiate(deathEffect, transform.position, Quaternion.identity);
             Smoke.SetActive(true);
             Destroy(gameObject);
         }
     }
 }
