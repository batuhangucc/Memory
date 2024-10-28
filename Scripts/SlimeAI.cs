using UnityEngine;

public class SlimeAI : MonoBehaviour
{
    public float jumpForce = 5f; 
    public float detectionRadius = 5f; 
    public LayerMask playerLayer;
    public float jumpCooldown = 2f; 
    private Rigidbody2D rb;
    private Transform playerTransform;

    private bool playerDetected = false;
    private bool canJump = true; 
    private float jumpCooldownTimer = 0f; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       
        if (!canJump)
        {
            jumpCooldownTimer -= Time.deltaTime;
            if (jumpCooldownTimer <= 0f)
            {
                canJump = true; 
            }
        }

        DetectPlayer();
    }

    
    void DetectPlayer()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, detectionRadius, playerLayer);

        if (playerCollider != null && playerCollider.CompareTag("Player"))
        {
            playerTransform = playerCollider.transform;
            playerDetected = true;

            if (canJump) 
            {
                JumpTowardsPlayer(); 
            }
        }
        else
        {
            playerDetected = false;
        }
    }

    
    void JumpTowardsPlayer()
    {
        if (playerDetected && playerTransform != null && canJump)
        {
           
            Vector2 directionToPlayer = (playerTransform.position - transform.position).normalized;
            rb.velocity = new Vector2(directionToPlayer.x * jumpForce, jumpForce);

           
            canJump = false;
            jumpCooldownTimer = jumpCooldown; 
        }
    }

    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
