using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public List<AudioClip> sesler; // Ses dosyalarının listesi
    private AudioSource audioSource; // Ses çalmak için kullanılacak Audio Source bileşeni
    public List<Button> butonlar; // Butonların listesi
    public AudioClip basariliSes; // Başarılı seçimde çalacak ses dosyası
    public AudioClip basarisizSes; // Başarısız seçimde çalacak ses dosyası
    private List<int> basariliIndeksler = new List<int>();
    private bool seslerTukendi = false;

    private int yanlisCevaplar = 0;

    private void Start()
    {
        // Audio Source bileşenini al
        audioSource = GetComponent<AudioSource>();

        // Rastgele bir ses dosyası seçip çal
        SesDosyasiSecVeCal();

        foreach (Button buton in butonlar)
        {
            // Buton bileşenine tıklama dinleyicisi ekle
            buton.onClick.AddListener(() => ButonTiklandi(buton));
        }
    }

    private bool SeslerTukendiMi()
    {
        return basariliIndeksler.Count == sesler.Count;
    }

    private void SesDosyasiSecVeCal()
    {
        // Eğer ses dosyaları tükenmişse, yeni bir seçim yapma
        if (SeslerTukendiMi())
        {
            Debug.Log("Tüm ses dosyaları seçildi.");
            seslerTukendi = true;
            return;
        }

        // Eğer ses dosyası listesi boşsa, yeni bir seçim yapma
        if (sesler.Count == 0)
        {
            Debug.Log("Ses dosyası listesi boş, yeni seçim yapılamıyor.");
            return;
        }

        // Rastgele bir ses dosyası indeksi seç
        int secilenIndex;
        do
        {
            secilenIndex = Random.Range(0, sesler.Count);
        } while (basariliIndeksler.Contains(secilenIndex)); // Eğer seçilen indeks daha önce başarılıysa, tekrar seç

        // Seçilen ses dosyasını çal
        AudioClip secilenSes = sesler[secilenIndex];
        audioSource.clip = secilenSes;
        audioSource.Play();
    }

    // Buton tıklama işlevi
    public void ButonTiklandi(Button tiklananButon)
    {
        // Butonların içerisinde dolaş
        foreach (Button buton in butonlar)
        {
            // Tıklanan buton, listedeki butonlardan birine eşitse
            if (buton == tiklananButon)
            {
                // Butonun içerisindeki metni al
                string buttonText = buton.GetComponentInChildren<TextMeshProUGUI>().text;

                // Butonun içerisindeki metni integer'a çevir
                int butonNumarasi;
                bool basarili = int.TryParse(buttonText, out butonNumarasi);
                butonNumarasi--;

                // Eğer metin integer'a dönüştürülemediyse, hata oluştuğunu belirt
                if (!basarili)
                {
                    Debug.LogError("Buton metni integer'a dönüştürülemedi: " + buttonText);
                    return;
                }

                // Eğer seçilen ses dosyasının indeksi, butonun içerisindeki sayıya eşitse
                if (audioSource.clip == sesler[butonNumarasi])
                {
                    // Başarılı bir seçim yapıldığında başarılı ses dosyasını çal
                    audioSource.PlayOneShot(basariliSes);
                    Debug.Log("Başarılı! Tıklanan butonun içerisindeki sayıyla seçilen ses dosyasının indeksi eşleşiyor.");
                    basariliIndeksler.Add(butonNumarasi); // Başarılı indeksi listeye ekle
                    GameObject tiklananObj = tiklananButon.gameObject;
                    Animation tiklananObjAnim = tiklananObj.GetComponent<Animation>(); // Tiklanan objenin Animation bileşenini al
                    if (tiklananObjAnim != null) // Eğer Animation bileşeni null değilse
                    {
                        tiklananObjAnim.Play(); // Animasyonu oynat
                    }
                    else // Eğer Animation bileşeni bulunamadıysa
                    {
                        Debug.LogError("Animation bileşeni bulunamadı!"); // Hata mesajı yazdır
                    }
                    StartCoroutine(Bekle(6f)); // 3 saniye bekler
                }
                else
                {
                    // Başarısız bir seçim yapıldığında başarısız ses dosyasını çal
                    audioSource.PlayOneShot(basarisizSes);
                    yanlisCevaplar++;
                    Debug.Log("Başarısız! Tıklanan butonun içerisindeki sayıyla seçilen ses dosyasının indeksi eşleşmiyor.");
                }
            }
        }
    }

    IEnumerator Bekle(float sure)
    {
        yield return new WaitForSeconds(sure); // Belirtilen süre kadar bekler
        Debug.Log("Bekleme süresi bitti!");

        // Bekleme süresi bittikten sonra yapılacak işlemler
        SesDosyasiSecVeCal(); // Yeni ses dosyasını çal
    }
}
