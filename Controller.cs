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
    [SerializeField] private Transform gun1;
    [SerializeField] private Transform gun2;
    [SerializeField] private float fireRate;
    [SerializeField] public BulletPool bulletPool;
    [SerializeField] private float BulletSpeed;
    [SerializeField] private float BulletLifeTime;

    private Camera cam;
    private GameObject Bullet1;
    private GameObject Bullet2;
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
            gun1.gameObject.SetActive(true);
            gun2.gameObject.SetActive(true);
            timer = 0;
            Bullet2 = bulletPool.GetBullet();
            Bullet1 = bulletPool.GetBullet();
            Debug.Log(Bullet2);
            if (Bullet2 != null && Bullet1 != null)
            {
                Bullet2.transform.position = gun1.position;
    
                Rigidbody2D rb2d = Bullet2.GetComponent<Rigidbody2D>();
                rb2d.linearVelocity = Vector2.zero;
                rb2d.AddForce(gun1.up * BulletSpeed, ForceMode2D.Impulse);
                Bullet1.transform.position = gun2.position;
                Bullet1.GetComponent<Bullet>().setLifeTime(BulletLifeTime);
                Bullet2.GetComponent<Bullet>().setLifeTime(BulletLifeTime);

                Bullet2.transform.right = Vector2.up;
                Bullet1.transform.right = Vector2.up;
                Rigidbody2D rb2d2 = Bullet1.GetComponent<Rigidbody2D>();
                rb2d2.linearVelocity = Vector2.zero;
                rb2d2.AddForce(gun2.up * BulletSpeed, ForceMode2D.Impulse);
                
            }
        }
        else
        {
            gun1.gameObject.SetActive(false);
            gun2.gameObject.SetActive(false);
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