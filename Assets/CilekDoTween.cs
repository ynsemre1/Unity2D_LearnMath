using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CilekDoTween : MonoBehaviour
{
    public GameObject sepetObject;

    void Start()
    {
        // GameObject'in başlangıç pozisyonunu al
        Vector3 startPosition = transform.position;

        // Hedef pozisyonu belirle
        Vector3 targetPosition = new Vector3(-4.3f, -.17f, 0f);

        // DoTween ile hareketi başlat
        transform.DOMove(targetPosition, 1f).SetEase(Ease.Linear);
        SepetDoTween();
    }

    void SepetDoTween()
    {
        Vector3 startPosition = sepetObject.transform.position;

        // Hedef pozisyonu belirle
        Vector3 targetPosition = new Vector3(5.65f, 2.71f, 0f);

        // DoTween ile hareketi başlat
        sepetObject.transform.DOMove(targetPosition, 1f).SetEase(Ease.Linear);
    }
}
