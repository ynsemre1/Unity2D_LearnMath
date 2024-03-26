using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketManager : MonoBehaviour
{  
   public GameObject[] rockets; // 4 adet rocket objesini tutacak dizi
    public int minNumber = 1; // En küçük rastgele sayı
    public int maxNumber = 7; // En büyük rastgele sayı
    private List<int> randomNumbers = new List<int>(); // Rastgele sayıları tutacak liste

    // Start is called before the first frame update
    void Start()
    {
        GenerateRandomNumbers(); // Rastgele sayıları oluştur
        ActivateStarsForRockets(); // Yıldızları aktif hale getir
    }

    // Rastgele sayıları oluşturan fonksiyon
    void GenerateRandomNumbers()
    {
        for (int i = 0; i < 4; i++) // 4 adet rastgele sayı oluştur
        {
            int randomNumber;
            do
            {
                randomNumber = Random.Range(minNumber, maxNumber + 1); // Rastgele sayı oluştur
            } while (randomNumbers.Contains(randomNumber)); // Oluşturulan sayı listede varsa tekrar oluştur
            randomNumbers.Add(randomNumber); // Oluşturulan sayıyı listeye ekle
        }
    }

    // Her bir rocket objesi için belirlenen sayıda yıldızı aktif hale getiren fonksiyon
    void ActivateStarsForRockets()
    {
        for (int i = 0; i < rockets.Length; i++)
        {
            GameObject rocket = rockets[i];

            List<Transform> starObjects = new List<Transform>();

            // Rocket altındaki Star taglı yıldızları bul
            foreach (Transform child in rocket.transform)
            {
                if (child.CompareTag("Star") && !child.gameObject.activeSelf)
                {
                    starObjects.Add(child);
                }
            }

            // Rocket için belirlenen sayıda yıldızı etkinleştir
            int starsToActivate = randomNumbers[i];
            for (int j = 0; j < starsToActivate && j < starObjects.Count; j++)
            {
                starObjects[j].gameObject.SetActive(true);
            }
        }
    }
}
