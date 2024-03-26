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

        // Rastgele renk oluştur
        Color randomColor = Random.ColorHSV();

        // SpriteRenderer bileşeninin rengini ayarla
        spriteRenderer.color = randomColor;
    }
}
