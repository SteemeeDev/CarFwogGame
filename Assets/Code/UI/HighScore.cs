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
    float time;
    // Start is called before the first frame update
    void Start()
    {
        display = this.GetComponent<TMP_Text>();

    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        //int.TryParse(display.text, out score);
        display.text = Math.Round(time, 0).ToString();
    }
}
