using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    
    
    private float lifeTime;
    public float damage;
    private float timer;



    public void setLifeTime(float time)
    {
        lifeTime = time;
    }
    
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= lifeTime)
        {
            timer = 0;
            gameObject.SetActive(false);
            
        }
        Vector2 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        if (viewPos.x > 1 || viewPos.x < 0 || viewPos.y < 0 || viewPos.y > 1)
        {
            gameObject.SetActive(false);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.SetActive(false);
    }
}
