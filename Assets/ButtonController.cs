using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string hedefSahneAdi; // Geçmek istediğiniz sahnenin adını bu değişkende saklayın

    public void SahneyeGit()
    {
        SceneManager.LoadScene(hedefSahneAdi); // Belirtilen sahneye geçiş yapılıyor
    }

    public void OncekiSahne()
    {
        SceneManager.LoadScene("UIScene"); // Belirtilen sahneye geçiş yapılıyor
    }
}
