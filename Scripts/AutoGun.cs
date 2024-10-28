using System.Collections;
using UnityEngine;

public class AutoGun : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform firePoint; 
    public float bulletSpeed = 20f; 
    public float fireRate = 0.5f; 
    public float invisibleDelay = 4f; 
    private bool invisibleBullets = false;
    public bool XorY;

    void Start()
    {
        
        Invoke("StartInvisibleBullets", invisibleDelay);
        
        InvokeRepeating("Shoot", 0f, fireRate);
    }

    void StartInvisibleBullets()
    {
        invisibleBullets = true; 
    }

    void Shoot()
    {
        
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

       
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (XorY == false)
        {
            rb.velocity = new Vector2(bulletSpeed, 0);
        }
        else 
        {
            rb.velocity = new Vector2(0, -bulletSpeed);
        } 

      
        if (invisibleBullets)
        {
            SpriteRenderer spriteRenderer = bullet.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = false; 
            }
        }
    }
    
}
