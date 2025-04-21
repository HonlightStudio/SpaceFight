using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float lifeTime;
    public float damage;
    private float timer;
    void Start()
    {
        lifeTime = GameObject.Find("Pool").GetComponent<BulletPool>().lifetime;
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
        
    }
}
