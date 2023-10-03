using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    public int score = 0;
    private Text uiText;

    // Start is called before the first frame update
    void Start()
    {
        uiText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        uiText.text = "Final Score: " + scoreCounter.score.ToString("#,0");
    }
}
