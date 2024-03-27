using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CilekDoTween : MonoBehaviour
{
    public GameObject sepetObject;
    public Button dogruButton;
    public AudioClip dogruBildin;
    public GameObject cilek1;
    public GameObject cilek2;
    public GameObject cilek3;
    public GameObject cilek4;
    public AudioClip soru2;
    public Button dogruButton2;
    public GameObject dogruButRecyler2;
    public GameObject dogruButRecyler;
    public GameObject sepet;
    public GameObject karpuzSepeti;
    public GameObject karpuzSample;
    public GameObject karpuz1;
    public GameObject karpuz2;
    public GameObject karpuz3;
    public AudioClip soru3;
    public GameObject portakalSample;

    void Start()
    {
        AudioSource audioSourceSoru3 = gameObject.GetComponent<AudioSource>();

        // GameObject'in başlangıç pozisyonunu al
        Vector3 startPosition = transform.position;
        // Hedef pozisyonu belirle
        Vector3 targetPosition = new Vector3(-4.3f, -.17f, 0f);
        // DoTween ile hareketi başlat
        transform.DOMove(targetPosition, 1f).SetEase(Ease.Linear);
        SepetDoTween();
        StartCoroutine(ikinciSample(1f));
        StartCoroutine(portakalSampleOff(2f));

        dogruButton.onClick.AddListener(() =>
        {
            audioSourceSoru3.clip = dogruBildin;
            audioSourceSoru3.Play();
            CilekleriSepeteAl();
            StartCoroutine(ikinciSoru(2f));
            dogruButRecyler.SetActive(false);
            dogruButRecyler2.SetActive(true);
        });

        dogruButton2.onClick.AddListener(() =>
        {
            audioSourceSoru3.clip = dogruBildin;
            audioSourceSoru3.Play();
            ikinciSoruDogru();
            StartCoroutine(ucuncuSample(1.3f));
        });
    }

    void SepetDoTween()
    {
        Vector3 startPosition = sepetObject.transform.position;

        // Hedef pozisyonu belirle
        Vector3 targetPosition = new Vector3(5.65f, 2.71f, 0f);

        // DoTween ile hareketi başlat
        sepetObject.transform.DOMove(targetPosition, 1f).SetEase(Ease.Linear);
    }

    IEnumerator ikinciSample(float sure)
    {
        yield return new WaitForSeconds(sure); // Belirtilen süre kadar bekler        
        // Bekleme süresi bittikten sonra burada yapmak istediğiniz işlemleri ekleyebilirsiniz
        AudioSource audioSourceSoru3 = gameObject.GetComponent<AudioSource>();
        audioSourceSoru3.Play();
    }

    void CilekleriSepeteAl()
    {
        Vector3 cilek1Position = cilek1.transform.position;
        Vector3 cilek2Position = cilek2.transform.position;
        Vector3 cilek3Position = cilek3.transform.position;
        Vector3 cilek4Position = cilek4.transform.position;

        // Hedef pozisyonu belirle
        Vector3 cilek1Target = new Vector3(5.02f, 3.57f, 0f);
        Vector3 cilek2Target = new Vector3(4.18f, 3.34f, 0f);
        Vector3 cilek3Target = new Vector3(4.41f, 4.2f, 0f);
        Vector3 cilek4Target = new Vector3(5.38f, 4.39f, 0f);

        Vector3 targetScale = new Vector3(1.22f, 1.22f, 1.22f);

        // DoTween ile hareketi başlat
        cilek1.transform.DOMove(cilek1Target, 1f).SetEase(Ease.Linear);
        cilek2.transform.DOMove(cilek2Target, 1f).SetEase(Ease.Linear);
        cilek3.transform.DOMove(cilek3Target, 1f).SetEase(Ease.Linear);
        cilek4.transform.DOMove(cilek4Target, 1f).SetEase(Ease.Linear);

        cilek1.transform.DOScale(targetScale, 1f).SetEase(Ease.Linear);
        cilek2.transform.DOScale(targetScale, 1f).SetEase(Ease.Linear);
        cilek3.transform.DOScale(targetScale, 1f).SetEase(Ease.Linear);
        cilek4.transform.DOScale(targetScale, 1f).SetEase(Ease.Linear);
    }

    IEnumerator ikinciSoru(float sure)
    {
        yield return new WaitForSeconds(sure); // Belirtilen süre kadar bekler        
        // Bekleme süresi bittikten sonra burada yapmak istediğiniz işlemleri ekleyebilirsiniz
        AudioSource audioSourceSoru3 = gameObject.GetComponent<AudioSource>();
        audioSourceSoru3.clip = soru2;
        audioSourceSoru3.Play();

        Vector3 sepetPos = sepet.transform.position;
        Vector3 sepetTargetPos = new Vector3(.68f, 1.03f, 0f);

        sepet.transform.DOMove(sepetTargetPos, 1f).SetEase(Ease.Linear);

        Vector3 cilek1Position = cilek1.transform.position;
        Vector3 cilek2Position = cilek2.transform.position;
        Vector3 cilek3Position = cilek3.transform.position;
        Vector3 cilek4Position = cilek4.transform.position;

        // Hedef pozisyonu belirle
        Vector3 cilek1Target = new Vector3(0.04999924f, 2.01f, 0f);
        Vector3 cilek2Target = new Vector3(-0.7900009f, 1.78f, 0f);
        Vector3 cilek3Target = new Vector3(-0.5600002f, 2.64f, 0f);
        Vector3 cilek4Target = new Vector3(0.4099998f, 2.83f, 0f);

        cilek1.transform.DOMove(cilek1Target, 1f).SetEase(Ease.Linear);
        cilek2.transform.DOMove(cilek2Target, 1f).SetEase(Ease.Linear);
        cilek3.transform.DOMove(cilek3Target, 1f).SetEase(Ease.Linear);
        cilek4.transform.DOMove(cilek4Target, 1f).SetEase(Ease.Linear);

        Vector3 cilekTargetCikartma = new Vector3(-0.5600004f, 3.76f, 0f);
        Vector3 cilek2TargetCikartma = new Vector3(2.18f, 3.79f, 0f);

        cilek3.transform.DOMove(cilekTargetCikartma, 1f).SetEase(Ease.Linear);
        cilek4.transform.DOMove(cilek2TargetCikartma, 1f).SetEase(Ease.Linear);
    }

    public void ikinciSoruDogru()
    {
        Vector3 cilek1Position = cilek1.transform.position;
        Vector3 cilek2Position = cilek2.transform.position;
        Vector3 cilek3Position = cilek3.transform.position;
        Vector3 cilek4Position = cilek4.transform.position;

        Vector3 sepetPos = sepet.transform.position;


        Vector3 cilek1Target = new Vector3(12.32f, 2.01f, 0f);
        Vector3 cilek2Target = new Vector3(12.32f, 1.78f, 0f);
        Vector3 cilek3Target = new Vector3(11.71f, 2.64f, 0f);
        Vector3 cilek4Target = new Vector3(14.45f, 2.83f, 0f);

        Vector3 sepetTarget = new Vector3(12.99f, 1.03f, 0f);

        cilek1.transform.DOMove(cilek1Target, 1f).SetEase(Ease.Linear);
        cilek2.transform.DOMove(cilek2Target, 1f).SetEase(Ease.Linear);
        cilek3.transform.DOMove(cilek3Target, 1f).SetEase(Ease.Linear);
        cilek4.transform.DOMove(cilek4Target, 1f).SetEase(Ease.Linear);

        sepet.transform.DOMove(sepetTarget, 1f).SetEase(Ease.Linear);
    }

    IEnumerator ucuncuSample(float sure)
    {
        yield return new WaitForSeconds(sure); // Belirtilen süre kadar bekler
        karpuzSample.SetActive(true);
    }

    IEnumerator portakalSampleOff(float sure)
    {
        yield return new WaitForSeconds(sure); // Belirtilen süre kadar bekler
        portakalSample.SetActive(false);
    }
}
