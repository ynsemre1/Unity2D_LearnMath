using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BalonController : MonoBehaviour
{
    public List<GameObject> objects;
    private List<int> usedNumbers = new List<int>();

    void Start()
    {
        // Her obje için rastgele bir rakam atama
        foreach (GameObject obj in objects)
        {
            // Rastgele bir rakam üretme ve kullanılan rakamlar listesinde olmadığından emin olma
            int randomNum = GetUniqueRandomNumber();
            
            // Objeye rastgele rakamı atama
            obj.GetComponentInChildren<TextMeshProUGUI>().text = randomNum.ToString();
        }
    }

    // Kullanılmamış bir rastgele rakam getirme
    int GetUniqueRandomNumber()
    {
        int randomNum;
        do
        {
            randomNum = Random.Range(1, 11); // 1 ile 10 arasında rastgele bir rakam üretme
        } while (usedNumbers.Contains(randomNum)); // Kullanılmamış bir rakam elde edene kadar tekrar üretme

        usedNumbers.Add(randomNum); // Kullanılan rakamlar listesine ekleme
        return randomNum;
    }
}

