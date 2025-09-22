using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnEntirelyNewScriptForThisSmallThing : MonoBehaviour
{
    GameObject highscore;
    string score;
    // Start is called before the first frame update
    void Start()
    {
        highscore = GameObject.FindWithTag("HighScore");
        score = highscore.GetComponent<TMP_Text>().text;
        GetComponent<TMP_Text>().text = score;
        Destroy(highscore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
