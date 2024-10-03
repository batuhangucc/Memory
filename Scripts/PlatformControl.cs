using UnityEngine;

public class PlatformControl : MonoBehaviour
{
    public PlatformMove platformMove; // PlatformMove scriptini referans alacak

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
         
            Destroy(gameObject); // Butonu yok et

            if (platformMove != null)
            {
               
                platformMove.startMoving = true; // Platformu hareket ettirmeye baþla
            }
          
        }
    }
}

