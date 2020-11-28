using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverlapss : MonoBehaviour
{
    public Image gameOverImage;
    AudioSource _as;
    // Start is called before the first frame update
    void Start()
    {

        gameOverImage.gameObject.SetActive(false);
        _as = GetComponent<AudioSource>();
        StartCoroutine(GameOver());
    }

   IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.75f);
        _as.Play();

        yield return new WaitForSeconds(1.75f);
        gameOverImage.gameObject.SetActive(true);
        Cursor.visible = true;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void TryAgain()
    {
        SceneManager.LoadScene("first level");
    }
}
