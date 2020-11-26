﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentQuitButton : MonoBehaviour
{
    public float Choice = 1;
    SpriteRenderer Opacity;
    Color NewColor;

    // Start is called before the first frame update
    void Start()
    {
        Opacity = GetComponent<SpriteRenderer>();


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Choice = Choice + (1);
        }


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Choice = Choice - (1);
        }

        if (Choice == (0))
        {
            Choice = (3);
        }

        if (Choice == (4))
        {
            Choice = (1);
        }

        if (Choice == (1))
        {
            NewColor = new Color(255f, 255f, 255f, NewColor.a = 0.5f);
            Opacity.color = NewColor;


        }

        if (Choice == (2))
        {
            NewColor = new Color(255f, 255f, 255f, NewColor.a = 0.5f);
            Opacity.color = NewColor;

        }

        if (Choice == (3))
        {
            NewColor = new Color(255f, 255f, 255f, NewColor.a = 1f);
            Opacity.color = NewColor;
        }


    }
}
