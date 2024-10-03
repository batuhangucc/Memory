
using System.Collections;
using UnityEngine;

public class EnemyFollow : Damageable
{
    public Transform Player;
    public float enemyspeed = 2f;
    private SpriteRenderer spriteRenderer;
    public float visual;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(ToggleVisibility());
    }

    void Update()
    {
        Vector3 targetposion = Player.position;
        Vector3 direction = (targetposion - transform.position).normalized;
        transform.position += direction * enemyspeed * Time.deltaTime;
    }

    private IEnumerator ToggleVisibility()
    {
        while (true)
        {
            yield return new WaitForSeconds(visual);
            spriteRenderer.enabled = !spriteRenderer.enabled;
            // Saðlýk barý görünürlüðünü deðiþtir
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
