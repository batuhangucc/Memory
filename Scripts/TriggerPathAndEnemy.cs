using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPathAndEnemy : MonoBehaviour
{
    public GameObject Gun;
    public bool pathandenemy=false;
    public GameObject objectToActivate;
    public GameObject enemyactive;
    public GameObject healthBar;
    void Start()
    {
        objectToActivate.SetActive(false);
        enemyactive.SetActive(false);
        healthBar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(Gun);
            pathandenemy = true;
            objectToActivate.SetActive(true);
            enemyactive.SetActive(true);
            healthBar.SetActive(true);
            Destroy(this.gameObject);
        }
    }
   
}
