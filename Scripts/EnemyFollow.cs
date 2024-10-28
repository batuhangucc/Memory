using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyFollow : Damageable
{
    public Transform Player;
    public float enemyspeed = 2f;
    private SpriteRenderer spriteRenderer;
    public float visual;

    private bool stopFollowing = false; 

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(ToggleVisibility());
    }

    void Update()
    {
        if (Player != null && !stopFollowing) 
        {
            Vector3 targetPosition = Player.position;
            Vector3 direction = (targetPosition - transform.position).normalized;
            transform.position += direction * enemyspeed * Time.deltaTime;
        }
        else
        {
            StopFollowing(); 
        }
    }

    private void StopFollowing()
    {
        stopFollowing = true; 
        enemyspeed = 0; 
    }

    private IEnumerator ToggleVisibility()
    {
        while (true)
        {
            yield return new WaitForSeconds(visual);
            spriteRenderer.enabled = !spriteRenderer.enabled;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            SceneManager.LoadScene(1);
        }
    }
}

