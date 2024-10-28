using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSkeleton : MonoBehaviour
{
    public GameObject enemy; 
    private Damageable damageableScript;
    private AudioSource audioSource;
    public AudioClip pick;
    public float pickSoundVolume = 0.05f;

    void Start()
    {
        
        damageableScript = enemy.GetComponent<Damageable>();
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = pickSoundVolume;

        
        if (damageableScript != null)
        {
            damageableScript.enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player") && damageableScript != null)
        {
            audioSource.clip = pick;
            audioSource.Play();
            enemy.tag = "Boss";
            damageableScript.enabled = true;
    
        }
    }
}
