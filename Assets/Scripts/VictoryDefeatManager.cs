using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryDefeatManager : MonoBehaviour
{
    public Image Defeat;
    public Image victory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Gameover()
    {
        Defeat.gameObject.SetActive(true);
    }

    public void VictoryGameover()
    {
        victory.gameObject.SetActive(false);
    }
}
