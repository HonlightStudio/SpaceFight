using System;

using UnityEngine;
using Random = UnityEngine.Random;
public class Health : MonoBehaviour
{
    [SerializeField] public float MaxHealth = 100f;
    [SerializeField] public float CurrentHealth = 100f;
    [SerializeField] GameObject Explosive;
    [SerializeField] GameObject HealthPickup;
    public bool isAlive = true;
    private float timer;
    [SerializeField] private RectTransform TopRight;
    [SerializeField] private RectTransform BottomLeft;
    private GameObject heal;
    [SerializeField] private GameObject healanim;
    [SerializeField] private float healDuration = 100f;
    [SerializeField] private float healAmount = 10f;
    [SerializeField] private float damage= 30f;
    [SerializeField] private GameManager manager;
    
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


    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        
        
        
        if (other.gameObject.CompareTag("enemy"))
        {
            Debug.Log(other.gameObject.name);
            other.gameObject.GetComponent<EnemyHealth>().Death();
            CurrentHealth=Mathf.Max(CurrentHealth-damage,0);
        }
        if (other.gameObject.CompareTag("Heal"))
        {
            CurrentHealth = Mathf.Min(CurrentHealth+healAmount, MaxHealth);
            Instantiate(healanim, transform.position, Quaternion.identity).transform.SetParent(transform);
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("Bullet"))
        {
           
               TakeDamage(other.gameObject.GetComponent<Bullet>().damage);

            
            
        }
    }

    public void Death()
    {
        if (isAlive)
        {
            GameObject Boom = Instantiate(Explosive, transform.position, Quaternion.identity);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Boom.SetActive(true);
            isAlive = false;
            manager.EndGame();
        }
        
    }

    public GameObject MakeHeal()
    {

        Vector2 Spawnpoint;
        Spawnpoint.x =  Random.Range(Camera.main.ScreenToWorldPoint(TopRight.position).x,Camera.main.ScreenToWorldPoint(BottomLeft.position).x);
        Spawnpoint.y = Camera.main.ScreenToWorldPoint(TopRight.position).y+3;
        return Instantiate(HealthPickup,Spawnpoint , Quaternion.identity);
    }

    public void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >=healDuration)
        {
             heal=MakeHeal();

            timer = 0;
        }

        if (heal != null)
        {
            Vector2 viewPos = Camera.main.WorldToViewportPoint(heal.transform.position);
            if ((viewPos.x > 1 || viewPos.x < 0 || viewPos.y < 0))
            {
                Destroy(heal);
            }
        }
    }
}
