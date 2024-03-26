using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PortakalDoTween : MonoBehaviour
{
    public GameObject portakal1;
    public GameObject portakal2;
    public Button dogruCevap;
    public AudioSource soru2UI;
    public AudioClip soru2;
    public AudioClip basariliSes;
    public GameObject cevaplar1;
    public GameObject cevaplar2;
    public GameObject cevaplar3;
    public GameObject portakal3;
    public Button dogruCevap2;
    public GameObject sample;
    public GameObject sample2;
    public GameObject sample2UI;

    public void Start()
    {
        AudioSource soru = gameObject.GetComponent<AudioSource>();
        soru.Play();
        dogruCevap.onClick.AddListener(() =>
        {
            movePortakallar();
            soru.clip = basariliSes;
            soru.Play();
            soru2UI.clip = soru2;
            soru.clip = basariliSes;
            StartCoroutine(ikinciSoru(2f));
            cevaplar1.SetActive(false);
            cevaplar2.SetActive(true);
            showPortakal();
        });

        dogruCevap2.onClick.AddListener(() =>
        {
            soru.clip = basariliSes;
            soru.Play();
            movePortakal();
            StartCoroutine(ikinciSample(2f));
        });
        
    }

    IEnumerator ikinciSoru(float sure)
    {
        yield return new WaitForSeconds(sure); // Belirtilen süre kadar bekler        
        // Bekleme süresi bittikten sonra burada yapmak istediğiniz işlemleri ekleyebilirsiniz
        AudioSource soru = gameObject.GetComponent<AudioSource>();
        soru.clip = soru2;
        soru.Play();
    }

    public void movePortakallar()
    {
        // GameObject'in başlangıç pozisyonunu al
        Vector3 startPosition = portakal1.transform.position;

        // Hedef pozisyonu belirle
        Vector3 targetPosition = new Vector3(3.39f, 3.3f, 0f);

        Vector3 targetScale = new Vector3(1.75f, 1.75f, 1.75f);

        // DoTween ile hareketi başlat
        portakal1.transform.DOMove(targetPosition, 1f).SetEase(Ease.Linear);
        portakal1.transform.DOScale(targetScale, 1f).SetEase(Ease.Linear)
            .OnComplete(() => Debug.Log("Hareket ve boyut değişimi tamamlandı!"));

        // GameObject'in başlangıç pozisyonunu al
        Vector3 startPosition2 = portakal1.transform.position;

        // Hedef pozisyonu belirle
        Vector3 targetPosition2 = new Vector3(3.86f, 4.15f, 0f);

        // DoTween ile hareketi başlat
        portakal2.transform.DOMove(targetPosition2, 1f).SetEase(Ease.Linear);
        portakal2.transform.DOScale(targetScale, 1f).SetEase(Ease.Linear)
            .OnComplete(() => Debug.Log("Hareket ve boyut değişimi tamamlandı!"));
    }

    public void showPortakal()
    {
        portakal3.SetActive(true);
        Vector3 targetRotation = new Vector3(0f, 0f, 360); // Örnek bir hedef rotasyonu
        Vector3 targetPosition3 = new Vector3(-1.99f, 0.78f, 0f);
        portakal3.transform.DORotate(targetRotation, 1f).SetEase(Ease.Linear);
        portakal3.transform.DOMove(targetPosition3, 1f).SetEase(Ease.Linear);
    }

    public void movePortakal()
    {
        Vector3 startPosition4 = portakal1.transform.position;
        Vector3 targetPosition4 = new Vector3(5.88f, 4.31f, 0f);
        Vector3 targetScale = new Vector3(1.41f, 1.41f, 1.41f);

        // DoTween ile hareketi başlat
        portakal3.transform.DOMove(targetPosition4, 1f).SetEase(Ease.Linear);
        portakal3.transform.DOScale(targetScale, 1f).SetEase(Ease.Linear);
    }

    IEnumerator ikinciSample(float sure)
    {
        yield return new WaitForSeconds(sure); // Belirtilen süre kadar bekler        
        // Bekleme süresi bittikten sonra burada yapmak istediğiniz işlemleri ekleyebilirsiniz
        Vector3 startPosition5 = sample.transform.position;
        Vector3 targetPosition4 = new Vector3(50f, 0f, 0f);

        Vector3 startPosition6 = sample2.transform.position;
        sample.transform.DOMove(targetPosition4, 1f).SetEase(Ease.Linear);
        sample2.transform.DOMove(targetPosition4, 1f).SetEase(Ease.Linear);
        cevaplar2.SetActive(false);
        cevaplar3.SetActive(true);
        sample.SetActive(true);
        sample2UI.SetActive(true);
    }
}
