using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletPool : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed;
    private List<GameObject> bulletPool;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletPool = new List<GameObject>();
        for (int i = 0; i < 100; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
    }

    public GameObject GetBullet()
    {
        foreach (GameObject bullet in bulletPool)
        {
            if (!bullet.activeInHierarchy)
            {
                bullet.SetActive(true);
                return bullet;
            }
        }
        return null;
    }
    public float lifetime = 2f;

    void OnEnable()
    {
        Invoke("Disable", lifetime);
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        CancelInvoke();
    }
}
