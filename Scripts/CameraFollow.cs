using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Ana karakterin Transform bile�eni
    public Vector3 offset = new Vector3(0, 5, -10); // Kameran�n ana karakterle aras�ndaki mesafe
    public bool lookAtTarget = true; // Kameran�n hedefe bak�p bakmayaca��n� belirler

    private void LateUpdate()
    {
        if (target != null)
        {
            // �stenilen pozisyonu hesapla
            Vector3 desiredPosition = target.position + offset;

            // Kameran�n pozisyonunu an�nda g�ncelle
            transform.position = desiredPosition;

            // Kameran�n hedefe bakmas�n� sa�la
            if (lookAtTarget)
            {
                transform.LookAt(target);
            }
        }
    }
}



