
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LizzardMove : Damageable
{
    public Transform Player;
    public float enemyspeed = 2f;
    public float Lizzardvisual;
    private SpriteRenderer spriteRenderer;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(ToggleVisibility());
    }

    void Update()
    {
        
        if (Player == null)
        {
           
            return; 
        }

        Vector3 targetPosition = new Vector3(Player.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, enemyspeed * Time.deltaTime);

        if (Player.position.x > transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else if (Player.position.x < transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
    }

    private IEnumerator ToggleVisibility()
    {
        while (true)
        {
            yield return new WaitForSeconds(Lizzardvisual);
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
