using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform cameraTransform; // Kameranýn transform bileþeni
    public Vector2 parallaxEffectMultiplier; // Arka planýn ne kadar hýzlý hareket edeceði

    private Vector3 lastCameraPosition; // Kameranýn son pozisyonu

    void Start()
    {
        lastCameraPosition = cameraTransform.position; // Kameranýn baþlangýç pozisyonunu kaydet
    }

    void Update()
    {
        // Kamera pozisyonundaki deðiþimi hesapla
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;

        // Arka planýn pozisyonunu güncelle
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y, 0);

        // Kameranýn pozisyonunu güncelle
        lastCameraPosition = cameraTransform.position;
    }
}


