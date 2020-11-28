using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverlapss : MonoBehaviour
{
    public AudioSource scream;
    public AudioSource steps;

    public Image gameOverImage;
    public Transform cam;
    public Transform whereTo;
    public float waitForScream = 1f;
    public int speed;

    public AudioSource menuSound;
    public AudioClip tensionSound;

    // Start is called before the first frame update
    void Start()
    {
        gameOverImage.gameObject.SetActive(false);
        StartCoroutine(GameOver());
        menuSound.PlayOneShot(tensionSound);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    private void Update()
    {

        cam.transform.position = Vector3.Lerp(cam.transform.position, whereTo.transform.position, speed * Time.deltaTime);
    }
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(waitForScream);
        scream.Play();
        steps.Stop();
        yield return new WaitForSeconds(2f);
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
