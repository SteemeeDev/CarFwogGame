using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TMPro;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
//this section was written by chatgpt. was too much effort for a small joke

public class HighScore : MonoBehaviour
{
    TMP_Text display;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        display = this.GetComponent<TMP_Text>();

    }

    // Update is called once per frame
    void Update()
    {
        //int.TryParse(display.text, out score);
        display.text = score.ToString();
    }
}
