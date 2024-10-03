using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Bullet prefab'i
    public Transform firePoint; // Bullet'ýn çýkacaðý nokta
    public float bulletSpeed = 20f; // Bullet hýzý
    public CharacterMovement2D anim;
    private SpriteRenderer spriteRenderer;
    public int maxBullets;// Maksimum mermi sayýsý
    public int damage=10; 
    private int currentBullets; // Mevcut mermi sayýsý
    public TMP_Text ammotext;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentBullets = maxBullets;
        UpdateAmmoText();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&& currentBullets>0)
        {
          
            Shoot();
            

        }
        if (Input.GetMouseButtonDown(0) == false)
        {
            StopShootingAnimation();
        }
    }
    void Shoot()
    {
        
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; 

      
        Vector3 shootDirection = (mousePosition - firePoint.position).normalized;
        UpdateCharacterDirection(shootDirection);


        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

     
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = shootDirection * bulletSpeed;
        anim.animator.SetBool("Shoot", true);
        Killing bulletScript = bullet.GetComponent<Killing>();
        bulletScript.damage = 10;
        currentBullets--;
        UpdateAmmoText();
    }
    void StopShootingAnimation()
    {
       
            anim.animator.SetBool("Shoot", false);
       
    }
    void UpdateCharacterDirection(Vector3 direction)
    {
        if (direction.x >= 0)
        {
            spriteRenderer.flipX = false; // Karakter saða bakýyor
        }
        else
        {
            spriteRenderer.flipX = true; // Karakter sola bakýyor
        }
    }
    void UpdateAmmoText()
    {
        ammotext.text = currentBullets.ToString(); 
       
    }

}
