using UnityEngine;
using System.Collections;

public class Damageable : MonoBehaviour
{
    public int maxHealth = 50;
    public int currentHealth;
    public GameObject healthBarPrefab;
    protected GameObject healthBarInstance;
    protected HealthBar healthBar;
    public float height;
    public Animator animator;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();

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
                    healthBar.offset = new Vector3(0, height, 0);
                    healthBar.SetMaxHealth(maxHealth);
                    healthBar.SetHealth(currentHealth);
                }
            }
        }
    }

    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetBool("TakeDamage", true);
        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }
        if (currentHealth <= 0)
        {
            Die();
        }
        StartCoroutine(ResetDamageAnimation());
    }

    protected virtual void Die()
    {
        if (healthBarInstance != null)
        {
            Destroy(healthBarInstance);
        }
        Destroy(gameObject);
    }
    private IEnumerator ResetDamageAnimation()
    {
        yield return new WaitForSeconds(0.05f); 
        animator.SetBool("TakeDamage", false); 
    }
}










