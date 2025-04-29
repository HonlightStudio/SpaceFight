using System;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float MaxHealth = 100f;
    [SerializeField] float CurrentHealth = 100f;
    [SerializeField] GameObject Explosive;
    
    
    private bool isAlive = true;
    public void Start()
    {

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
        if (other.gameObject.name.Contains("Bullet_Player"))
        {
            return;
        }
        
        else
        {
            TakeDamage(other.gameObject.GetComponent<Bullet>().damage);
        }
    }

    public void Death()
    {
        if (isAlive)
        {
            GameObject Boom = Instantiate(Explosive, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            Boom.SetActive(true);
            isAlive = false;
        }
        
    }
}
