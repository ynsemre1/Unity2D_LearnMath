using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BalonColorGenerator : MonoBehaviour
{
    public List<GameObject> objects;

    void Start()
    {
        // Renk listesi
        List<Color> colors = new List<Color>{
            Color.red,
            Color.blue,
            Color.green,
            Color.yellow,
            Color.cyan,
            Color.magenta,
            Color.white,
            Color.gray,
            new Color(1.0f, 0.5f, 0.0f), // Turuncu renk
            new Color(0.5f, 0.5f, 0.5f) // Özel bir renk ekleyebilirsiniz
        };

        // Rastgele renklerin atanması
        // Rastgele renklerin atanması
        foreach (GameObject obj in objects)
        {
            // Rastgele bir renk indeksi seçme
            int randomIndex = Random.Range(0, colors.Count);
            // Seçilen indeksteki rengi objeye atama
            obj.GetComponent<Image>().color = colors[randomIndex];
            // Seçilen rengi listeden kaldırma
            colors.RemoveAt(randomIndex);
        }

    }
}
