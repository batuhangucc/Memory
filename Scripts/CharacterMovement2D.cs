using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 90f;
    public Animator animator;

    private Rigidbody2D rb;
    private Vector2 movement;
    private SpriteRenderer spriteRenderer;
    public BoxCollider2D boxbox;
    public float value;
    public float tolerance = 0.01f;
    public bool youshallpass=false;





    [SerializeField] private LayerMask platformLayerMask;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
   
    void Update()
    {

        // Hareket girdiðini al
        movement.x = Input.GetAxis("Horizontal");


        // Animator parametresini güncelle
        animator.SetFloat("Speed", Mathf.Abs(movement.x));

        // Karakteri döndür
        if (movement.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (movement.x > 0)
        {
            spriteRenderer.flipX = false;
        }

        // Yerde olup olmadýðýný kontrol et



        // Zýplama girdiðini kontrol et
        if (Isgrounded()&&Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
            animator.SetBool("Jumping", true);

        }
        if (!Isgrounded() && rb.velocity.y < 0)
        {
            animator.SetBool("Fall", true);
        }
        else
        {
            animator.SetBool("Fall", false );
        }

      

        if (rb.velocity.y == 0)
        {
            animator.SetBool("Jumping", false);
        }
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            youshallpass = true;
        }




    }
   

    private bool Isgrounded()
    {
        float extraheightText=0.3f;
        RaycastHit2D raycastHit= Physics2D.Raycast(boxbox.bounds.center, Vector2.down, boxbox.bounds.extents.y+ extraheightText, platformLayerMask);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;

           



        }
        else 
        {
            rayColor=Color.red;

           
        }
        
        
        Debug.DrawRay(boxbox.bounds.center, Vector2.down *  (boxbox.bounds.extents.y + extraheightText));
       
    
        return raycastHit.collider != null;
    }
 






    void FixedUpdate()
    {
        // Karakteri hareket ettir
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
        
       
    }
     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Lava")
        {
            Destroy(this.gameObject);
        }
        if (collision.tag == "EnemyBullet")
        {
            Destroy(this.gameObject);
        }
        if (collision.tag == "Finish" && youshallpass == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("Oldu");  
        }
    }




}
