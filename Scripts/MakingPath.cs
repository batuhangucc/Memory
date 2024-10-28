using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakingPath : MonoBehaviour
{
    public GameObject makingPathv1;
    private AudioSource audioSource;
    public AudioClip pick;
    public float pickSoundVolume = 0.05f;
    void Start()
    {
        makingPathv1.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = pickSoundVolume;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            audioSource.clip = pick;
            audioSource.Play();
            makingPathv1.SetActive(true);
        }
    }
}
