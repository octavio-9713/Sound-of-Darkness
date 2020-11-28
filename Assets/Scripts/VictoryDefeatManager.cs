using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class VictoryDefeatManager : MonoBehaviour
{
    public bool didIWin;
    public Image blindingScreen;
    public Image BlackScreen;
    public Light BlindingLight;
    public float DarkAlphaSpeed;
    public float LightAlphaSpeed;
    bool dark;
    bool ligher;
    // Start is called before the first frame update
    void Start()
    {
        BlackScreen.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (didIWin)
        {
            VictoryGameover();
            didIWin = false;
        }
        if (dark)
        {
            BlindingLight.color = Color.Lerp(BlindingLight.color, Color.black, DarkAlphaSpeed * Time.deltaTime);
        }
        if (ligher)
        {
            BlindingLight.color = Color.Lerp(BlindingLight.color, Color.white, LightAlphaSpeed * Time.deltaTime);
        }
    }

    public void Gameover()
    {
        SceneManager.LoadScene("defeat scene");
    }

    public void VictoryGameover()
    {
        BlindingLight.gameObject.SetActive(true);
        blindingScreen.gameObject.SetActive(true);
        StartCoroutine(TimerBeforeLightOut());
    }
    IEnumerator TimerBeforeLightOut()
    {
        ligher = true;
        yield return new WaitForSeconds(2f);
        ligher = false;
        dark = true;
        yield return new WaitForSeconds(2);
        blindingScreen.gameObject.SetActive(false);
        BlackScreen.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Menu");
    }
}
