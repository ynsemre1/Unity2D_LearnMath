using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class KarpuzDoTween : MonoBehaviour
{
    public GameObject karpuzSepeti;
    public GameObject karpuz2;
    public GameObject karpuz4;
    public GameObject karpuz5;
    public GameObject karpuzYedili;
    public GameObject cilekSample;
    public AudioClip karpuzSoruClip2;
    public GameObject cilekCevaplar;
    public GameObject karpuzCevaplar1;
    public GameObject karpuzCevaplar2;
    public Button dogruButton;
    public Button dogruButton2;
    public GameObject dogruButtonRecyler;
    public GameObject dogruButtonRecyler2;
    public AudioClip dogruBildin;
    public GameObject endUI;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource audioSourceSoru3 = gameObject.GetComponent<AudioSource>();

        Vector3 karpuzSepet = karpuzSepeti.transform.position;
        Vector3 karpuzSepetiTarget = new Vector3(1.100559f, 0.06703911f, 0f);

        karpuzSepeti.transform.DOMove(karpuzSepetiTarget, 1f).SetEase(Ease.Linear);
        StartCoroutine(ikiKarpuzEksi(3f));

        cilekSample.SetActive(false);
        cilekCevaplar.SetActive(false);
        karpuzCevaplar1.SetActive(true);

        dogruButton.onClick.AddListener(() =>
        {
            audioSourceSoru3.clip = dogruBildin;
            audioSourceSoru3.Play();
            //CilekleriSepeteAl();
            dogruButtonRecyler.SetActive(false);
            dogruButtonRecyler2.SetActive(true);
            StartCoroutine(ikinciSoruDogru(1f));

        });

        dogruButton2.onClick.AddListener(() =>
        {
            audioSourceSoru3.clip = dogruBildin;
            audioSourceSoru3.Play();
            //ikinciSoruDogru();
            //StartCoroutine(ucuncuSample(1.3f));
            endUI.SetActive(true);
        });

    }

    IEnumerator ikiKarpuzEksi(float sure)
    {
        yield return new WaitForSeconds(sure); // Belirtilen süre kadar bekler
        Vector3 karpuzPos = karpuz2.transform.position;
        Vector3 karpuz2Pos = karpuz4.transform.position;
        Vector3 karpuz3Pos = karpuz5.transform.position;

        Vector3 karpuz2Target = new Vector3(0.4540489f, 3.637241f, 0f);
        Vector3 karpuz4Target = new Vector3(-2.584701f, 3.708741f, 0f);
        Vector3 karpuz5Target = new Vector3(3.832424f, 3.601491f, 0f);

        karpuz2.transform.DOMove(karpuz2Target, 1f).SetEase(Ease.Linear);
        karpuz4.transform.DOMove(karpuz4Target, 1f).SetEase(Ease.Linear);
        karpuz5.transform.DOMove(karpuz5Target, 1f).SetEase(Ease.Linear);
    }

    IEnumerator ikinciSoruDogru(float sure)
    {
        yield return new WaitForSeconds(sure); // Belirtilen süre kadar bekler
        Vector3 karpuz1Pos = karpuz2.transform.position;
        Vector3 karpuz2Pos = karpuz4.transform.position;
        Vector3 karpuz3Pos = karpuz5.transform.position;

        Vector3 karpuz2Target = new Vector3(14.12f, 4.266997f, 0f);
        Vector3 karpuz4Target = new Vector3(11.65125f, 4.245737f, 0f);
        Vector3 karpuz5Target = new Vector3(12.89f, 4.286997f, 0f);

        karpuz2.transform.DOMove(karpuz2Target, 1f).SetEase(Ease.Linear);
        karpuz4.transform.DOMove(karpuz4Target, 1f).SetEase(Ease.Linear);
        karpuz5.transform.DOMove(karpuz5Target, 1f).SetEase(Ease.Linear);

        Vector3 yediliKarpuz = karpuzYedili.transform.position;
        Vector3 yediliKarpuzTarget = new Vector3(7.48f, 1.8f, 0f);

        karpuzYedili.transform.DOMove(yediliKarpuzTarget, 1f).SetEase(Ease.Linear);

        AudioSource audioSourceSoru3 = gameObject.GetComponent<AudioSource>();
        audioSourceSoru3.clip = karpuzSoruClip2;
        audioSourceSoru3.Play();
    }
}
