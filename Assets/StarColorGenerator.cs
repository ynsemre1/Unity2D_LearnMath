using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarColorGenerator : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        // SpriteRenderer bileşenini al
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Rastgele renk oluştur (turuncu, sarı, kırmızı ve yeşil arasında)
        Color randomColor = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);

        // SpriteRenderer bileşeninin rengini ayarla
        spriteRenderer.color = randomColor;
    }
}
