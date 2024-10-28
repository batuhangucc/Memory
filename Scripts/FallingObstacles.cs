using UnityEngine;
using System.Collections;

public class FallingObstacles : MonoBehaviour
{
    public float dropTime = 1f; 
    public float riseTime = 1f;
    public GameObject targetPositionObject;
    public float positionHeight;

    private Vector2 originalPosition; 

    void Start()
    {
      
        originalPosition = targetPositionObject.transform.position;
        StartCoroutine(DropAndRise());
    }

    private IEnumerator DropAndRise()
    {
        while (true)
        {
            
            transform.position = new Vector2(originalPosition.x, originalPosition.y + positionHeight); 

            
            yield return StartCoroutine(Drop());

           
            yield return new WaitForSeconds(0.5f);

           
            yield return StartCoroutine(Rise());
        }
    }

    private IEnumerator Drop()
    {
        float elapsedTime = 0f;
        Vector2 startPosition = transform.position;
        Vector2 targetPosition = new Vector2(originalPosition.x, originalPosition.y);

        while (elapsedTime < dropTime)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, (elapsedTime / dropTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition; 
    }

    private IEnumerator Rise()
    {
        float elapsedTime = 0f;
        Vector2 startPosition = transform.position;
        Vector2 targetPosition = new Vector2(originalPosition.x, originalPosition.y + positionHeight); 

        while (elapsedTime < riseTime)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, (elapsedTime / riseTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition; 
    }
}
