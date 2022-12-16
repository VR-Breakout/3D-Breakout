using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.XR;

public class Global : MonoBehaviour
{
    public GameObject blockFab;
    public GameObject ballFab;

    public float SPEED = 50;

    public int numHits = 0;
    public int numBackwallHits = 0;

    public int score = 0;

    public int numBlocksX;
    public int numBlocksY;
    public int numBlocksZ;

    public float gapBlocksX;
    public float gapBlocksY;
    public float gapBlocksZ;

    public float blockYDist;
    public float blockZDist;

    [SerializeField]
    private GameObject leftPaddle;
    [SerializeField]
    private GameObject rightPaddle;

    [SerializeField]
    private GameObject timerText;

    [SerializeField]
    private GameObject winText;

    [SerializeField]
    private GameObject gameoverText;

    private TimeScript timeScript;

    GameObject[] blocks;

    private InputDevice RightControllerDevice;
    private InputDevice LeftControllerDevice;

    List<InputDevice> devices;

    private bool triggerPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        devices = new List<InputDevice>();

        blocks = new GameObject[numBlocksX * numBlocksY * numBlocksZ];
        if (ballFab == null || blockFab == null)
        {
            Debug.LogError("need assign fabs for ball and block");
            return;
        }
        CreateBlocks();
        timeScript = timerText.GetComponent<TimeScript>();

        winText.SetActive(false);
        gameoverText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        InputDevices.GetDevices(devices);
        foreach (var device in devices)
        {
            if ((device.characteristics & InputDeviceCharacteristics.Right) == InputDeviceCharacteristics.Right) {
                RightControllerDevice = device;
            }
            if ((device.characteristics & InputDeviceCharacteristics.Left) == InputDeviceCharacteristics.Left) {
                LeftControllerDevice = device;
            }
        }
        RightControllerDevice.TryGetFeatureValue(CommonUsages.menuButton, out bool rightMenuButton);
        LeftControllerDevice.TryGetFeatureValue(CommonUsages.menuButton, out bool leftMenuButton);
        RightControllerDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool rightTriggerButton);
        LeftControllerDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool leftTriggerButton);
        if ((rightMenuButton && rightTriggerButton) || (leftMenuButton && leftTriggerButton))
        {
            Debug.Log("End Game!");
            EndGame();
        }

        
        if (rightMenuButton || leftMenuButton) {
            RestartLevel();
        }

        if (rightTriggerButton || leftTriggerButton)
        {
            timeScript.startTiming();
            if (!triggerPressed && rightTriggerButton)
            {
                triggerPressed = true;
                Instantiate(ballFab, rightPaddle.transform.position + 0.4f * rightPaddle.transform.up, Quaternion.identity);
            }
            else if (!triggerPressed && leftTriggerButton)
            {
                triggerPressed = true;
                Instantiate(ballFab, leftPaddle.transform.position + 0.4f * leftPaddle.transform.up, Quaternion.identity);
            }
        }
        else
        {
            triggerPressed = false;
        }

        if (GameObject.FindGameObjectWithTag("Block") == null) {
            // gameover = true
            foreach (var ball in GameObject.FindGameObjectsWithTag("Ball")) {
                Destroy(ball);
            }
            timeScript.stopTiming();
            winText.SetActive(true);
        }
        //if (leftTriggerButtonValue) {
        //    RestartLevel();
        //}
    }

    public void GameOver()
    {
        // gameover = true
        foreach (var ball in GameObject.FindGameObjectsWithTag("Ball"))
        {
            Destroy(ball);
        }
        gameoverText.SetActive(true);
    }

    public void CreateBlocks()
    {
        int count = 0;
        for (int i = -numBlocksX / 2; i <= numBlocksX / 2; ++i)
        {
            for (int j = -numBlocksY / 2; j <= numBlocksY / 2; ++j)
            {
                for (int k = 0; k < numBlocksZ; ++k)
                {
                    blocks[count] = Instantiate(blockFab,
                        new Vector3(i * gapBlocksX, blockYDist + j * gapBlocksY, blockZDist + k * gapBlocksZ),
                        Quaternion.identity);
                    blocks[count].name = "Block " + count;
                    Color color = new Color(0.2f / numBlocksZ * (k + 1), 0.2f + 0.5f / numBlocksZ * (k + 1), 0.1f + 0.75f / numBlocksZ * (k + 1), 0.7f + 0.15f / numBlocksZ * (k + 1));
                    //blocks[count].GetComponent<Renderer>().material.SetColor("_Color", color);
                    blocks[count].GetComponent<Renderer>().material.SetColor("_EmissionColor", color);

                    ++count;
                }
            }
        }
    }

    public void FreezeGame()
    {
        Time.timeScale = 0.0f;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}

