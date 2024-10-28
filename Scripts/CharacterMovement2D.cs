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
    public bool youshallpass = false;
    public AudioClip jumpSound; 
    public AudioClip walkSound; 
    public AudioClip ambianceSound;
    private AudioSource audioSource; 
    private AudioSource ambianceSource;
    public float ambianceVolume = 0.05f;
    private bool isSliding = false;
    public float slideSpeed = 10f; 
    public float slideDuration = 0.3f; 
    private float slideTimer; 
    private Vector2 originalOffset; 
    private Vector2 originalSize;





    [SerializeField] private LayerMask platformLayerMask;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.freezeRotation = true;
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;

        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        ambianceSource = gameObject.AddComponent<AudioSource>();
        ambianceSource.clip = ambianceSound;
        ambianceSource.loop = true; 
        ambianceSource.volume = ambianceVolume;
        ambianceSource.Play();
        originalOffset = boxbox.offset;
        originalSize = boxbox.size;



    }

    void Update()
    {

        
        movement.x = Input.GetAxis("Horizontal");


        
        animator.SetFloat("Speed", Mathf.Abs(movement.x));

       
        if (movement.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (movement.x > 0)
        {
            spriteRenderer.flipX = false;
        }

        if (Isgrounded() && Mathf.Abs(movement.x) > 0.1f && !audioSource.isPlaying)
        {
            audioSource.clip = walkSound;

            audioSource.Play();
        }
        else if (Isgrounded() && Mathf.Abs(movement.x) <= 0.1f && audioSource.clip == walkSound && audioSource.isPlaying)
        {
            audioSource.Stop();  
        }



      
        if (Isgrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
            animator.SetBool("Jumping", true);
            animator.SetBool("Fall", false);
            audioSource.PlayOneShot(jumpSound);


        }
        if (!Isgrounded() && rb.velocity.y < 0)
        {
            animator.SetBool("Jumping", false);  
            animator.SetBool("Fall", true);
        }
        if (Isgrounded())
        {
          
            animator.SetBool("Fall", false); 
        }

       
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            youshallpass = true;
        }
        if (Isgrounded() && Input.GetKeyDown(KeyCode.LeftShift) && !isSliding && Mathf.Abs(movement.x) > 0.1f)
        {
            StartSlide();
        }


        if (isSliding)
        {
            slideTimer -= Time.deltaTime;
            if (slideTimer <= 0)
            {
                StopSlide();
            }
        }
        







    }


    public bool Isgrounded()
    {
        float extraheightText = 0.5f;
        RaycastHit2D raycastHit = Physics2D.Raycast(boxbox.bounds.center, Vector2.down, boxbox.bounds.extents.y + extraheightText, platformLayerMask);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
            
            if (raycastHit.collider.CompareTag("DestructibleBlock"))
            {
                
                raycastHit.collider.GetComponent<BlockDestroyer>().TriggerDestruction();
            }





        }
        else
        {
            rayColor = Color.red;


        }


        Debug.DrawRay(boxbox.bounds.center, Vector2.down * (boxbox.bounds.extents.y + extraheightText));


        return raycastHit.collider != null;
    }







    void FixedUpdate()
    {
        
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
        if (!isSliding)
        {
            rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(spriteRenderer.flipX ? -slideSpeed : slideSpeed, rb.velocity.y);
        }


    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Lava")
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(1);
        }
        if (collision.tag == "EnemyBullet")
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(1);
        }
        if (collision.tag == "Bone")
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(1);
        }
        if (collision.tag == "Boss")
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(1);
        }
        if (collision.tag == "Slime")
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(1);
        }
        if (collision.tag == "Finish" && youshallpass == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("Oldu");
        }
    }
    private void OnDestroy()
    {
        if (ambianceSource != null)
        {
            ambianceSource.Stop(); 
        }
    }
    private void StartSlide()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 8)
        {


            isSliding = true;
            animator.SetBool("Sliding", true);
            slideTimer = slideDuration;
            boxbox.offset = new Vector2(0.003662661f, -0.06519809f);
            boxbox.size = new Vector2(0.2150067f, 0.2740208f);
         }




    }
    private void StopSlide()
    {

        isSliding = false;
        animator.SetBool("Sliding", false);
        boxbox.offset = originalOffset;
        boxbox.size = originalSize;
    }
}
