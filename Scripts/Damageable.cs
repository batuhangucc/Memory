using UnityEngine;

public class Damageable : MonoBehaviour
{
    public int maxHealth = 50;
    public int currentHealth;
    public GameObject healthBarPrefab;
    protected GameObject healthBarInstance;
    protected HealthBar healthBar;

    protected virtual void Start()
    {
        currentHealth = maxHealth;

        if (healthBarPrefab != null)
        {
            Canvas canvas = FindObjectOfType<Canvas>();
            if (canvas != null)
            {
                healthBarInstance = Instantiate(healthBarPrefab, canvas.transform);
                healthBar = healthBarInstance.GetComponent<HealthBar>();

                if (healthBar != null)
                {
                    healthBar.target = transform;
                    healthBar.offset = new Vector3(0, 1.5f, 0);
                    healthBar.SetMaxHealth(maxHealth);
                    healthBar.SetHealth(currentHealth);
                }
            }
        }
    }

    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        if (healthBarInstance != null)
        {
            Destroy(healthBarInstance);
        }
        Destroy(gameObject);
    }
}










