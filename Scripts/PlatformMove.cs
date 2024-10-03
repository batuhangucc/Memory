using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public Transform targetPosition; // Platformun gitmesi gereken hedef pozisyon
    public float speed = 5f; // Platformun hareket hýzý
    public bool startMoving = false; // Platformun hareket edip etmeyeceðini belirler

    private void Update()
    {
        if (startMoving)
        {
           
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, speed * Time.deltaTime);
        }
    }
}

