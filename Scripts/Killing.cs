
using UnityEngine;


public class Killing : MonoBehaviour
{
    public int damage = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Enemy") || collision.tag == ("Boss") || collision.tag == ("Slime") || collision.tag=="Lava")
        {
            Damageable damageable = collision.GetComponent<Damageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(damage);
                Destroy(gameObject); 
            }
        }
        if (collision.tag == "Block")
        {
            Destroy(gameObject);
        }
    }
}
