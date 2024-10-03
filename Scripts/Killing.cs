
using UnityEngine;


public class Killing : MonoBehaviour
{
    public int damage = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Damageable damageable = collision.GetComponent<Damageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(damage);
                Destroy(gameObject); // Mermiyi yok et
            }
        }
    }
}
