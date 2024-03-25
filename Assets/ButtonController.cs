using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public Animator transitionAnimator;
    public float transitionTime = 1f;
    public string hedefSahneAdi; // Geçmek istediğiniz sahnenin adını bu değişkende saklayın

    public void SahneyeGit()
    {
        StartCoroutine(LoadLevel(hedefSahneAdi));
    }

    public void OncekiSahne()
    {
        StartCoroutine(LoadLevel("UIScene"));
    }

    IEnumerator LoadLevel(string sahneAdi)
    {
        transitionAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sahneAdi); // Belirtilen sahneye geçiş yapılıyor

    }
}
