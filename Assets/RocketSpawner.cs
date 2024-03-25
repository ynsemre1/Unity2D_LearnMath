using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public int numberOfInstances = 4; // Oluşturulacak prefab sayısı
    public float spawnRadius = 5f; // Oluşturulacak prefabın spawner'dan uzaklık aralığı

    public List<GameObject> starsToActivate = new List<GameObject>(); // Editor üzerinden eklenen yıldız objelerinin listesi

    void Start()
    {
        for (int i = 0; i < numberOfInstances; i++)
        {
            SpawnPrefab();
        }
    }

    void SpawnPrefab()
    {
        Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
        GameObject newPrefab = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

        // Listeden alınan yıldız objelerini doğrudan kontrol et
        foreach (GameObject star in starsToActivate)
        {
            if (star.CompareTag("Star"))
            {
                star.SetActive(Random.value > 0.5f); // Rastgele bir şekilde etkinleştir veya devre dışı bırak
            }
        }
    }
}

