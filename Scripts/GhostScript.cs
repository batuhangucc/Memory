using UnityEngine;
using System.Collections;
public class GhostScript : MonoBehaviour
{
    public float detectionRadius = 5f; 
    public LayerMask playerLayer; 
    public float dashSpeed = 10f;
    public float chargeTime = 1f; 
    private Transform playerTransform;
   
    private bool isDashing = false;

    private Animator animator; 
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        DetectPlayer();
    }

    public void DetectPlayer()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, detectionRadius, playerLayer);

        if (playerCollider != null && playerCollider.CompareTag("Player"))
        {
            playerTransform = playerCollider.transform;


            if (!isDashing) 
            {
                StartCoroutine(ChargeAndDash()); 
            }
        }
    }  

    private IEnumerator ChargeAndDash()
    {
        isDashing = true;

       
        animator.SetTrigger("Charge");

       
        yield return new WaitForSeconds(chargeTime);

        
        animator.SetTrigger("Dash");

        
        Vector2 dashDirection = (playerTransform.position - transform.position).normalized;
        float dashDuration = 0.2f; 
        float elapsedTime = 0f;

        while (elapsedTime < dashDuration)
        {
            transform.position += (Vector3)(dashDirection * dashSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isDashing = false;
    }

    void OnDrawGizmosSelected()
    {
       
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}

