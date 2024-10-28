using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform cameraTransform; // Kameran�n transform bile�eni
    public Vector2 parallaxEffectMultiplier; // Arka plan�n ne kadar h�zl� hareket edece�i

    private Vector3 lastCameraPosition; // Kameran�n son pozisyonu

    void Start()
    {
        lastCameraPosition = cameraTransform.position; // Kameran�n ba�lang�� pozisyonunu kaydet
    }

    void Update()
    {
        // Kamera pozisyonundaki de�i�imi hesapla
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;

        // Arka plan�n pozisyonunu g�ncelle
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y, 0);

        // Kameran�n pozisyonunu g�ncelle
        lastCameraPosition = cameraTransform.position;
    }
}


