using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public float Choice = 1;
    public GameObject StartGame;
    public GameObject Credits;
    public GameObject QuitGame;
    public GameObject Tuto;

    // Start is called before the first frame update
    void Start()
    {
        Choice = 1;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Choice = Choice + (1);
        }


        if (Input.GetKeyDown(KeyCode.S))
        {
            Choice = Choice + (1);
        }


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Choice = Choice - (1);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Choice = Choice - (1);
        }


        if (Choice == (0))
        {
            Choice = (4);
        }

        if (Choice == (5))
        {
            Choice = (1);
        }

        if (Choice == (1))
        {
            print("Start the game?");


            if (Input.GetKeyDown(KeyCode.Space))
            {

                SceneManager.LoadScene("Game Scene");
            }

            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {

                SceneManager.LoadScene("Game Scene");
            }
        }

        if (Choice == (2))
        {
            print("Go to the tutorial?");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("TutoScene");
            }

            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                SceneManager.LoadScene("TutoScene");
            }
        }

        if (Choice == (3))
        {
            print("Go to the credits?");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("CreditsScene");
            }

            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {

                SceneManager.LoadScene("CreditsScene");
            }
        }

        if (Choice == (4))
        {
            print("Quit game?");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Application.Quit();
            }

            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {

                Application.Quit();
            }
        }

    }
}
