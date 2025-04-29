using System;
using UnityEngine;

public class ShieldHealth : MonoBehaviour
{
    [SerializeField]
    int health = 50;
    [SerializeField]
    GameObject Exp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Instantiate(Exp, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("salam");
            health=Mathf.Max(health-1, 0);
        }
    }
}
