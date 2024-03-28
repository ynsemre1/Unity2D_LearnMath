using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Oynatılacak ses kliplerinin listesi
    // Ses klipleri için değişkenler
    public List<AudioClip> sesler; // Kullanılacak ses kliplerinin listesi
    public AudioClip basariliSes; // Başarılı ses klibi
    public AudioClip basarisizSes; // Başarısız ses klibi

    // Diğer component'ler için değişkenler
    private AudioSource audioSource; // Sesi oynatmak için ses kaynağı
    public List<Button> butonlar; // Oyun butonlarının listesi
    public GameObject objectToSpawn; // Oluşturulacak nesne
    public GameObject[] stars; // Yıldız görsellerinin dizisi
    public TextMeshProUGUI endUIText; // Oyun sonu UI metni

    // Diğer değişkenler
    private List<int> basariliIndeksler = new List<int>(); // Başarılı indekslerin listesi
    private bool seslerTukendi = false; // Seslerin tükendiği kontrolü
    private int tıklananBalonSayısı = 0; // Tıklanan balon sayısı
    private int yanlisCevaplar = 0; // Yanlış cevap sayısı

    private void Start()
    {
        // Component referanslarını al
        audioSource = GetComponent<AudioSource>();
        // İlk ses dosyasını seç ve oynat
        SesDosyasiSecVeCal();

        // Butonlara tıklama dinleyicilerini ekle
        foreach (Button buton in butonlar)
        {
            buton.onClick.AddListener(() => ButonTiklandi(buton));
        }
    }

    // Tüm seslerin tükenip tükenmediğini kontrol et
    private bool SeslerTukendiMi()
    {
        return basariliIndeksler.Count == sesler.Count;
    }

    // Rasgele bir ses dosyası seç ve oynat
    private void SesDosyasiSecVeCal()
    {
        // Eğer tüm sesler seçildiyse
        if (SeslerTukendiMi())
        {
            Debug.Log("Tüm ses dosyaları seçildi.");
            seslerTukendi = true;
            // Oyun sonu metnini güncelle
            endUIText.text = "Yanlis Sayiniz: " + yanlisCevaplar;
            // Yıldız görsellerini güncelle
            GuncelleYildizlar();
            // Oluşturulacak nesneyi aktifleştir
            objectToSpawn.SetActive(true);
            return;
        }

        // Ses dosyası listesi boşsa işlem yapma
        if (sesler.Count == 0)
        {
            Debug.Log("Ses dosyası listesi boş, yeni seçim yapılamıyor.");
            return;
        }

        // Başarılı indeksler listesinde olmayan bir indeks seçene kadar işlemi tekrarla
        int secilenIndex;
        do
        {
            secilenIndex = Random.Range(0, sesler.Count);
        } while (basariliIndeksler.Contains(secilenIndex));

        // Seçilen ses dosyasını oynat
        AudioClip secilenSes = sesler[secilenIndex];
        audioSource.clip = secilenSes;
        audioSource.Play();
    }

    // Buton tıklandığında gerçekleşecek işlemler
    public void ButonTiklandi(Button tiklananButon)
    {
        // Butonun metnini al
        string buttonText = tiklananButon.GetComponentInChildren<TextMeshProUGUI>().text;
        int butonNumarasi;
        // Buton metnini integer'a dönüştür
        bool basarili = int.TryParse(buttonText, out butonNumarasi);
        butonNumarasi--;

        // Başarılı bir dönüşüm değilse hata ver
        if (!basarili)
        {
            Debug.LogError("Buton metni integer'a dönüştürülemedi: " + buttonText);
            return;
        }

        // Doğru ses dosyasıyla eşleşme kontrolü
        if (audioSource.clip == sesler[butonNumarasi])
        {
            // Başarılı sesi oynat
            audioSource.PlayOneShot(basariliSes);
            Debug.Log("Başarılı! Tıklanan butonun içerisindeki sayıyla seçilen ses dosyasının indeksi eşleşiyor.");
            // Başarılı indeksi ekle
            basariliIndeksler.Add(butonNumarasi);
            // Tıklanan balon sayısını artır
            tıklananBalonSayısı++;
            // Animasyonu oynat
            Animation tiklananObjAnim = tiklananButon.gameObject.GetComponent<Animation>();
            if (tiklananObjAnim != null)
            {
                tiklananObjAnim.Play();
            }
            else
            {
                Debug.LogError("Animation bileşeni bulunamadı!");
            }
            // Bekleme işlemi başlat
            StartCoroutine(Bekle(4f));
        }
        else
        {
            // Başarısız sesi oynat
            audioSource.PlayOneShot(basarisizSes);
            // Yanlış cevap sayısını artır
            yanlisCevaplar++;
            Debug.Log("Başarısız! Tıklanan butonun içerisindeki sayıyla seçilen ses dosyasının indeksi eşleşmiyor.");
        }
    }

    // Belirtilen süre kadar bekle ve sonrasında ses dosyası seç ve oynat
    IEnumerator Bekle(float sure)
    {
        yield return new WaitForSeconds(sure);
        Debug.Log("Bekleme süresi bitti!");
        SesDosyasiSecVeCal();
    }

    // Yıldız görsellerini güncelle
    public void GuncelleYildizlar()
    {
        int yildizSayisi;
        // Yanlış cevap sayısına göre yıldız sayısını belirle
        if (yanlisCevaplar <= 15)
        {
            yildizSayisi = 3;
        }
        else if (yanlisCevaplar > 15 && yanlisCevaplar <= 30)
        {
            yildizSayisi = 2;
        }
        else
        {
            yildizSayisi = 1;
        }
    }
}