using UnityEngine;
using TMPro;

public class TimeScript : MonoBehaviour
{
    private Global Global;
    private TMP_Text dispalyTime;

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
        if (totalTime > 0)
        {
            totalTime -= Time.deltaTime;
        }
        double b = System.Math.Round(totalTime, 0);

        dispalyTime.text = "Time: " + b.ToString();
        if (totalTime < 0)
        {
            // calling end game function here
            //Debug.Log("Completed");
            Global.FreezeGame();
        }
    }
}
