using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Topun Transform bileşeni
    public Vector3 offset;   // Kameranın topa göre pozisyonu
    public float rotationSpeed = 5.0f; // Kameranın dönüş hızı

    private float currentX = 0f;
    private float currentY = 0f;
    public float minY = -20f;
    public float maxY = 80f;

    void Start()
    {
        // Başlangıçta offset değerini hesapla
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        if (PauseMenu.GameIsPaused)
            return;

        // Fare hareketi ile kameranın döndürülmesi
        currentX += Input.GetAxis("Mouse X") * rotationSpeed;
        currentY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        currentY = Mathf.Clamp(currentY, minY, maxY);

        // Kameranın dönüşü
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = target.position + rotation * offset;
        transform.LookAt(target);
    }
}