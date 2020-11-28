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
    public float AlphaSpeed;
    bool dark;

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
        if(dark)
        {
            BlindingLight.color = Color.Lerp(BlindingLight.color, Color.black, AlphaSpeed * Time.deltaTime);
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
        yield return new WaitForSeconds(0.5f);
        dark = true;
        yield return new WaitForSeconds(2);
        blindingScreen.gameObject.SetActive(false);
        BlackScreen.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Menu");
    }
}
