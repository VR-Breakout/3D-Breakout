using UnityEngine;
using TMPro;

public class ScoreTextScript : MonoBehaviour
{
    private Global Global;
    private TMP_Text scoreText;
    // Use this for initialization
    void Start()
    {
        Global = GameObject.Find("Global").GetComponent<Global>();
        scoreText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        int score = Global.score;
        scoreText.text = "Score: " + score.ToString();
    }
}