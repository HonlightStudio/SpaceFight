using UnityEngine;
using UnityEngine.Pool;

public class Controller : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    float Speed;
    [SerializeField]
    float smooth;
    [SerializeField] private RectTransform TopRight;
    [SerializeField] private RectTransform BottomLeft;
    private Camera cam;
    [SerializeField] private GameObject Bullet;
    [SerializeField] public BulletPool bulletPool;
    [SerializeField] private float BulletSpeed;

    private Transform transform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
            rb.linearVelocity = new Vector2(Mathf.SmoothStep(rb.linearVelocityX, movement.x * Speed, smooth), 
                Mathf.SmoothStep(rb.linearVelocityY, movement.y * Speed, smooth));
            if (Input.GetKey(KeyCode.Space))
            {
                Bullet = bulletPool.GetBullet();
                if (Bullet != null){
                    Bullet.transform.position = transform.position;
                    Bullet.transform.rotation = transform.rotation;
                    Rigidbody2D rb2d = Bullet.GetComponent<Rigidbody2D>();
                    rb2d.linearVelocity = Vector2.zero;
                    rb2d.AddForce(transform.right * BulletSpeed, ForceMode2D.Impulse);
                }
            }
        if (rb.position.y > cam.ScreenToWorldPoint(TopRight.position).y&&rb.linearVelocityY>0)
        {
            rb.linearVelocity=Vector2.zero;
        }
        if (rb.position.y <cam.ScreenToWorldPoint(BottomLeft.position).y  &&rb.linearVelocityY < 0)
        {
            rb.linearVelocity=Vector2.zero;
        }

        if (rb.position.x > cam.ScreenToWorldPoint(TopRight.position).x && rb.linearVelocityX > 0)
        {
            rb.linearVelocity=Vector2.zero;
        }

        if (rb.position.x < cam.ScreenToWorldPoint(BottomLeft.position).x && rb.linearVelocityX < 0)
        {
            rb.linearVelocity=Vector2.zero;
        }
    }
}
