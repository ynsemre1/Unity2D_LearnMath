using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketStars : MonoBehaviour
{
    public GameObject[] stars; // Alt objelerdeki yıldızları tutacak dizi
    public int aktifObjSayac = 0;

    void Start()
    {
        RandomizeStars();
    }

    void RandomizeStars()
    {
        // Her yıldızı rastgele olarak açık veya kapalı yap
        foreach (GameObject star in stars)
        {
            // Rastgele bir boolean değer al
            bool isActive = Random.Range(0, 2) == 1; // 0 veya 1
            // Yıldızın etkinlik durumunu ayarla
            star.SetActive(isActive);
            if (isActive)
            {
                aktifObjSayac++;
            }
        }
    }
}

