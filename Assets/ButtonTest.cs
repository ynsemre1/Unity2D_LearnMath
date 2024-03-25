using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTest : MonoBehaviour
{
    void Start()
    {
        // Button bileşenini al
        Button button = GetComponent<Button>();
        TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
        
        // Button'un tıklanma olayına abone ol
        button.onClick.AddListener(() =>
        {   
            // Eğer text bileşeni bulunduysa ve içeriği boş değilse
            if (buttonText != null && !string.IsNullOrEmpty(buttonText.text))
            {
                // Debug.Log ile text içeriğini konsola yazdır
                Debug.Log("Button Text: " + buttonText.text);
            }
            else
            {
                // Text bileşeni bulunamadı veya içeriği boş
                Debug.LogWarning("Button text not found or empty.");
            }
        });
    }

}
