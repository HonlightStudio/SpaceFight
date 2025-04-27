 using System;
 using UnityEngine;

 public class EnemyHealth : MonoBehaviour
 {
     [SerializeField] float health = 10f;
     [SerializeField]
     Bullet bullet;

     public void FixedUpdate()
     {
         if (health <= 0)
         {
             
             Destroy(gameObject);
         }
     }

     private void OnTriggerEnter2D(Collider2D other)
     {
         if (other.gameObject.name.Contains("Bullet_Player")){
         health -= other.gameObject.GetComponent<Bullet>().damage;
         }
     }
 }
