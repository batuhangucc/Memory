using System.Collections;
using UnityEngine;

public class AutoGun : MonoBehaviour
{
    public GameObject bulletPrefab; // Bullet prefab
    public Transform firePoint; // Bullet'�n ��kaca�� nokta
    public float bulletSpeed = 20f; // Bullet h�z�
    public float fireRate = 0.5f; // Ate� etme aral��� (saniye cinsinden)
    public float invisibleDelay = 4f; // Mermilerin g�r�nmez hale gelme s�resi (public olarak ayarland�)
    private bool invisibleBullets = false; // Mermilerin g�r�nmez olup olmad���n� kontrol eder

    void Start()
    {
        // invisibleDelay s�resi sonra mermilerin g�r�nmez hale gelmesini sa�lar
        Invoke("StartInvisibleBullets", invisibleDelay);
        // S�rekli olarak ate� etmeye ba�la
        InvokeRepeating("Shoot", 0f, fireRate);
    }

    void StartInvisibleBullets()
    {
        invisibleBullets = true; // invisibleDelay ge�tikten sonra mermiler g�r�nmez olarak ��kacak
    }

    void Shoot()
    {
        // Mermi olu�tur
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // Mermiyi sadece x ekseni boyunca hareket ettir
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(bulletSpeed, 0); // Yaln�zca x ekseni �zerinde ileri do�ru hareket ettir

        // E�er invisibleBullets true ise mermiyi g�r�nmez yap
        if (invisibleBullets)
        {
            SpriteRenderer spriteRenderer = bullet.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = false; // Mermiyi g�r�nmez yap
            }
        }
    }
}
