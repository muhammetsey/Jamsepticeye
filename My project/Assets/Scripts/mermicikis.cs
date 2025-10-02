using UnityEngine;

public class MermiAtici2D : MonoBehaviour
{
    [SerializeField] private Transform[] firePoints;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 10f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (Transform firePoint in firePoints)
            {
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                   
                    rb.linearVelocity = firePoint.right * bulletSpeed;
                }
                else
                {
                    Debug.LogWarning("Mermi Rigidbody2D component'i bulunamadý!");
                }
            }
        }
    }
}
