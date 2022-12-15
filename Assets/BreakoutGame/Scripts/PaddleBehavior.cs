using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public enum Handedness { left, right }

public class PaddleBehavior : MonoBehaviour
{
    Vector3 previousPos;
    private float velocity;

    public GameObject Controller;
    public Handedness handedness;
    private HapticCapabilities caps;

    public GameObject global;



    // Start is called before the first frame update
    void Start()
    {
        if (Controller == null)
        {
            Debug.Log("Controller is null, needs to be assigned");
        }
        else
        {
            caps = new HapticCapabilities();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Transform newT = Controller.transform;

        // fixes for ping pong paddle mesh
        this.GetComponent<Rigidbody>().MovePosition(newT.position - 0.06f * gameObject.transform.up);
        this.GetComponent<Rigidbody>().MoveRotation(newT.rotation * Quaternion.Euler(90, 0, 0) * Quaternion.Euler(0, 90, 0));

        Vector3 displace = (this.transform.position - previousPos);
        velocity = displace.magnitude / Time.deltaTime;

        previousPos = this.transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            if (global != null)
            {
                global.GetComponent<Global>().numHits += 1;
            }

            XRNode node;
            if (handedness == Handedness.left)
            {
                node = XRNode.LeftHand;
            }
            else
            {
                node = XRNode.RightHand;
            }
            if (InputDevices.GetDeviceAtXRNode(node).TryGetHapticCapabilities(out caps))
            {
                if (caps.supportsImpulse)
                {
                    InputDevices.GetDeviceAtXRNode(node).SendHapticImpulse(0, 0.22f, 0.15f); //channel, amp, seconds
                }
            }
        }
    }


    void EndGame()
    { }
}
