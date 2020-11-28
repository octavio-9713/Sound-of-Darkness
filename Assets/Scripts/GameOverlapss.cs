using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverlapss : MonoBehaviour
{
    AudioSource _as;
    public Image gameOverImage;
    public Transform cam;
    public Transform whereTo;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {

        _as = GetComponent<AudioSource>();
        gameOverImage.gameObject.SetActive(false);
        StartCoroutine(GameOver());
    }
    private void Update()
    {

        cam.transform.position = Vector3.Lerp(cam.transform.position, whereTo.transform.position, speed * Time.deltaTime);
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
