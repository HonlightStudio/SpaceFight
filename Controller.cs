using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Serialization;

public class Controller : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float Speed;
    [SerializeField] float smooth;
    [SerializeField] private RectTransform TopRight;
    [SerializeField] private RectTransform BottomLeft;
    [SerializeField] private Transform gun;
    [SerializeField] private float fireRate;
    [SerializeField] public BulletPool bulletPool;
    [SerializeField] private float BulletSpeed;


    private Camera cam;
    private GameObject Bullet;
    private float timer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        rb.linearVelocity = new Vector2(Mathf.SmoothStep(rb.linearVelocityX, movement.x * Speed, smooth),
            Mathf.SmoothStep(rb.linearVelocityY, movement.y * Speed, smooth));
        if (Input.GetKey(KeyCode.Space) && timer > (1 / fireRate))
        {
            timer = 0;
            Bullet = bulletPool.GetBullet();
            Debug.Log(Bullet);
            if (Bullet != null)
            {
                Bullet.transform.position = gun.position;
                Bullet.transform.rotation = gun.rotation;
                Rigidbody2D rb2d = Bullet.GetComponent<Rigidbody2D>();
                rb2d.linearVelocity = Vector2.zero;
                rb2d.AddForce(gun.up * BulletSpeed, ForceMode2D.Impulse);
            }
        }

        if (rb.position.y > cam.ScreenToWorldPoint(TopRight.position).y && rb.linearVelocityY > 0)
        {
            rb.linearVelocity = Vector2.zero;
        }

        if (rb.position.y < cam.ScreenToWorldPoint(BottomLeft.position).y && rb.linearVelocityY < 0)
        {
            rb.linearVelocity = Vector2.zero;
        }

        if (rb.position.x > cam.ScreenToWorldPoint(TopRight.position).x && rb.linearVelocityX > 0)
        {
            rb.linearVelocity = Vector2.zero;
        }

        if (rb.position.x < cam.ScreenToWorldPoint(BottomLeft.position).x && rb.linearVelocityX < 0)
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
}