using UnityEngine;
using System.Collections;
public class BlockDestroyer : MonoBehaviour
{
    private bool isTriggered = false;
    private float destructionDelay = 1.5f;


    public void TriggerDestruction()
    {
        if (!isTriggered)
        {
            isTriggered = true;
            StartCoroutine(DestroyBlockAfterDelay());
        }
    }


    private IEnumerator DestroyBlockAfterDelay()
    {
        yield return new WaitForSeconds(destructionDelay);
        Destroy(gameObject);
    }
}

