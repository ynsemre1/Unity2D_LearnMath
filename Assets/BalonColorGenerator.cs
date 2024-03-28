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
            Color.red,          // Kırmızı
            Color.blue,         // Mavi
            Color.green,        // Yeşil
            Color.yellow,       // Sarı
            Color.cyan,         // Cyan (Açık mavi)
            Color.magenta,      // Magenta (Açık mor)
            Color.white,        // Beyaz
        new Color(1.0f, 0.5f, 0.0f),   // Turuncu
        new Color(0.0f, 0.8f, 0.8f),    // Parlak turkuaz
        new Color(0.6f, 0.0f, 0.6f)     // Mor
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
