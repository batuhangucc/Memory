using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour
{
    public GameObject bonePrefab; 
    public Transform firePoint; 
    public Transform ps1; 
    public Transform ps2;
    public Transform ps3;        
    public float fireRate = 5f; 
    public float arcHeight = 4.5f; 

    void Start()
    {
        
        InvokeRepeating("ThrowBone", 0f, fireRate);
    }

    void ThrowBone()
    {
        
        Transform targetPosition = Random.Range(0, 3) == 0 ? ps1 : (Random.Range(0, 2) == 0 ? ps2 : ps3);

        
        GameObject bone = Instantiate(bonePrefab, firePoint.position, Quaternion.identity);

       
        StartCoroutine(ThrowBoneToTarget(bone, targetPosition.position));
    }

    IEnumerator ThrowBoneToTarget(GameObject bone, Vector3 targetPosition)
    {
        Vector3 startPos = bone.transform.position;
        float time = 0;
        Rigidbody2D rb = bone.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 3f; 
        }

        
        while (time < 1f)
        {
            
            if (bone == null)
            {
                yield break; 
            }

            time += Time.deltaTime / fireRate;
            float xPos = Mathf.Lerp(startPos.x, targetPosition.x, time);
            float yPos = Mathf.Lerp(startPos.y, targetPosition.y, time) + arcHeight * Mathf.Sin(Mathf.Clamp01(time) * Mathf.PI);
            bone.transform.position = new Vector3(xPos, yPos, bone.transform.position.z);

            Vector3 direction = (targetPosition - startPos).normalized;
            bone.transform.right = direction;

            yield return null;
        }

       
        if (bone != null)
        {
            Destroy(bone);
        }
    }

}





