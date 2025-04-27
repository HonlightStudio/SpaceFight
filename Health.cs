using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float MaxHealth = 100f;
    [SerializeField] float CurrentHealth = 100f;








    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
    }




    public void Heal(float heal)
    {
        CurrentHealth += heal;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(other.gameObject.GetComponent<Bullet>().damage);
        }
    }
}
