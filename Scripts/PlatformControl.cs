
using UnityEngine;
public class PlatformControl : MonoBehaviour
{
    public PlatformMove platformMove;
    public GameObject buton; 
    private SpriteRenderer spriteRenderer; 

    void Start()
    {
        
        spriteRenderer = buton.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            
            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = false;
            }

            
            if (platformMove != null)
            {
                platformMove.startMoving = true; 
            }
        }
    }
}


