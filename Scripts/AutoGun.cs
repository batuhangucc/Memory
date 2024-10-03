using System.Collections;
using UnityEngine;

public class AutoGun : MonoBehaviour
{
    public GameObject bulletPrefab; // Bullet prefab
    public Transform firePoint; // Bullet'ýn çýkacaðý nokta
    public float bulletSpeed = 20f; // Bullet hýzý
    public float fireRate = 0.5f; // Ateþ etme aralýðý (saniye cinsinden)
    public float invisibleDelay = 4f; // Mermilerin görünmez hale gelme süresi (public olarak ayarlandý)
    private bool invisibleBullets = false; // Mermilerin görünmez olup olmadýðýný kontrol eder

    void Start()
    {
        // invisibleDelay süresi sonra mermilerin görünmez hale gelmesini saðlar
        Invoke("StartInvisibleBullets", invisibleDelay);
        // Sürekli olarak ateþ etmeye baþla
        InvokeRepeating("Shoot", 0f, fireRate);
    }

    void StartInvisibleBullets()
    {
        invisibleBullets = true; // invisibleDelay geçtikten sonra mermiler görünmez olarak çýkacak
    }

    void Shoot()
    {
        // Mermi oluþtur
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // Mermiyi sadece x ekseni boyunca hareket ettir
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(bulletSpeed, 0); // Yalnýzca x ekseni üzerinde ileri doðru hareket ettir

        // Eðer invisibleBullets true ise mermiyi görünmez yap
        if (invisibleBullets)
        {
            SpriteRenderer spriteRenderer = bullet.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = false; // Mermiyi görünmez yap
            }
        }
    }
}
