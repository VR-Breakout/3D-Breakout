using UnityEngine;
using TMPro;

public class TimeScript : MonoBehaviour
{
    private Global Global;
    private TMP_Text dispalyTime;

    private bool activeTimer = false;

    public float totalTime = 120.0f;
    // Use this for initialization
    void Start()
    {
        Global = GameObject.Find("Global").GetComponent<Global>();
        dispalyTime = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (activeTimer)
        {
            if (totalTime > 0)
            {
                totalTime -= Time.deltaTime;
            }
            double b = System.Math.Round(totalTime, 0);

            dispalyTime.text = "Time: " + b.ToString();
            if (totalTime < 0)
            {
                Global.GameOver();
            }
        }
    }

    public void startTiming()
    {
        activeTimer = true;
    }

    public void stopTiming()
    {
        activeTimer = false;
    }
}
