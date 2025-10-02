using UnityEngine;

public class CharController : MonoBehaviour
{
    public float moveSpeed = 5f;          // Karakterin hareket h�z�
    public GameObject bulletPrefab;       // Ate�lenecek mermi prefab'�
    public Transform firePoint;           // Merminin ��k�� noktas�
    public float bulletSpeed = 10f;       // Mermi h�z�

    private Rigidbody2D rb;
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Hareket giri�i
        moveInput = 0;
        if (Input.GetKey(KeyCode.A))
            moveInput = -1;
        if (Input.GetKey(KeyCode.D))
            moveInput = 1;

        // Ate�leme
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        // Karakteri hareket ettir
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            if (bulletRb != null)
            {
                bulletRb.linearVelocity = Vector2.up * bulletSpeed; 
            }
        }
    }
}
