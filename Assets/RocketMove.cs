using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMove : MonoBehaviour
{
    public float moveSpeed = 5f; // Hareket hızı

    private void OnMouseDrag()
    {
        // Fare konumunu al
        Vector3 mousePosition = Input.mousePosition;
        // Fare konumunu dünya koordinatlarına dönüştür
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        // Yüksekliği sıfırla (objenin yüksekliği ile aynı seviyede olmasını sağlar)
        targetPosition.z = 0f;

        // Hedefe doğru yönel
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
