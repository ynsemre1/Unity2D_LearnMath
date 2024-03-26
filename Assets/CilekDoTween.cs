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
        dogruButton.onClick.AddListener(() =>
        {
            audioSourceSoru3.clip = dogruBildin;
            audioSourceSoru3.Play();
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
}
