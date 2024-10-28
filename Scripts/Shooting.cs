using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    public CharacterMovement2D anim;
    private SpriteRenderer spriteRenderer;
    public int maxBullets;
    public int damage = 10;
    private int currentBullets;
    public TMP_Text ammotext;

    public AudioClip shootSound;
    public float shootVolume = 0.1f;
    private List<AudioSource> audioSourcePool; 
    public int audioPoolSize = 5;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentBullets = maxBullets;
        UpdateAmmoText();

      
        audioSourcePool = new List<AudioSource>();
        for (int i = 0; i < audioPoolSize; i++)
        {
            AudioSource newAudioSource = gameObject.AddComponent<AudioSource>();
            newAudioSource.clip = shootSound;
            newAudioSource.volume = shootVolume;
            audioSourcePool.Add(newAudioSource);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentBullets > 0)
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

       
        PlayShootSound();
    }

    void PlayShootSound()
    {
        
        AudioSource availableSource = audioSourcePool.Find(source => !source.isPlaying);

        if (availableSource != null)
        {
           
            availableSource.Play();
        }
        else
        {
          
            audioSourcePool[0].Stop();
            audioSourcePool[0].Play();
        }
    }

    void StopShootingAnimation()
    {
        anim.animator.SetBool("Shoot", false);
    }

    void UpdateCharacterDirection(Vector3 direction)
    {
        if (direction.x >= 0)
        {
            spriteRenderer.flipX = false; 
        }
        else
        {
            spriteRenderer.flipX = true; 
        }
    }

    void UpdateAmmoText()
    {
        ammotext.text = currentBullets.ToString();
    }
}


