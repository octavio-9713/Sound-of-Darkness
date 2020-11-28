using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverlapss : MonoBehaviour
{
    public Image gameOverImage;
    // Start is called before the first frame update
    void Start()
    {

        gameOverImage.gameObject.SetActive(false);
        StartCoroutine(GameOver());
    }

   IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2.5f);
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
