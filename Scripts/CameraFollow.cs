using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Ana karakterin Transform bileþeni
    public Vector3 offset = new Vector3(0, 5, -10); // Kameranýn ana karakterle arasýndaki mesafe
    public bool lookAtTarget = true; // Kameranýn hedefe bakýp bakmayacaðýný belirler

    private void LateUpdate()
    {
        if (target != null)
        {
            // Ýstenilen pozisyonu hesapla
            Vector3 desiredPosition = target.position + offset;

            // Kameranýn pozisyonunu anýnda güncelle
            transform.position = desiredPosition;

            // Kameranýn hedefe bakmasýný saðla
            if (lookAtTarget)
            {
                transform.LookAt(target);
            }
        }
    }
}



