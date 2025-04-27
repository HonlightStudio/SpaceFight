using System;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float MaxHealth = 100f;
    [SerializeField] float CurrentHealth = 100f;
    [SerializeField] GameObject Explosive;

    public void Start()
    {
        Explosive.SetActive(false);
    }

    public float GetMaxHealth()
    {
        return MaxHealth;
    }

    public float GetCurrentHealth()
    {
        return CurrentHealth;
    }

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

    public void Death()
    {
        gameObject.SetActive(false);
        Explosive.transform.position = transform.position;
        Explosive.SetActive(true);
    }
}
