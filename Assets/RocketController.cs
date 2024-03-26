using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public GameObject[] objectsToCompare; // Karşılaştırılacak objelerin listesi

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject collidedObject = other.gameObject;

        // Çarpışan nesne üzerindeki aktif olan alt obje sayısını hesapla
        int collidedActiveChildCount = CountActiveChildObjects(collidedObject.transform);

        // Tanımlanan objeler arasındaki en küçük aktif olan alt obje sayısını bul
        int minActiveChildCount = int.MaxValue;
        int minIndex = -1;
        for (int i = 0; i < objectsToCompare.Length; i++)
        {
            if (objectsToCompare[i] != null) // Referans null değilse işlem yap
            {
                int activeChildCount = CountActiveChildObjects(objectsToCompare[i].transform);
                if (activeChildCount < minActiveChildCount)
                {
                    minActiveChildCount = activeChildCount;
                    minIndex = i;
                }
            }
        }

        // Karşılaştırma yap ve sonucu Debug.Log ile yazdır
        if (collidedActiveChildCount == minActiveChildCount)
        {
            Debug.Log("True");
            other.gameObject.GetComponent<Animation>().Play();
            // En küçük aktif nesneyi yok et
            if (minIndex != -1 && objectsToCompare[minIndex] != null) // Referans null değilse işlem yap
            {
                objectsToCompare[minIndex] = null; // Referansı null yap
            }
        }
        else
        {
            Debug.Log("False");
        }

        // Yok etmek yerine devam et
        //Destroy(other.gameObject);
    }

    // Verilen transform altındaki aktif olan alt obje sayısını döndüren fonksiyon
    int CountActiveChildObjects(Transform parent)
    {
        int activeChildCount = 0;

        foreach (Transform child in parent)
        {
            if (child.gameObject.activeSelf)
            {
                activeChildCount++;
            }

            // Eğer çocuk objenin altında başka çocuk objeler varsa, bu çocuk objenin altındaki aktif olanları da kontrol et
            if (child.childCount > 0)
            {
                activeChildCount += CountActiveChildObjects(child);
            }
        }

        return activeChildCount;
    }
}




