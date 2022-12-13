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
        this.GetComponent<Rigidbody>().MovePosition(newT.position);
        this.GetComponent<Rigidbody>().MoveRotation(newT.rotation);

        Vector3 displace = (this.transform.position - previousPos);
        velocity = displace.magnitude / Time.deltaTime;

        previousPos = this.transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (global != null)
        {
            global.GetComponent<Global>().numHits += 1;
        }


        Vector3 normal = -collision.GetContact(0).normal;
        collision.gameObject.GetComponent<Rigidbody>().AddForce(normal * velocity); //assume contact is instantaenous? f * t

        XRNode node;
        if (handedness == Handedness.left)
        {
            node = XRNode.LeftHand;
        } else
        {
            node = XRNode.RightHand;
        }
        if (InputDevices.GetDeviceAtXRNode(node).TryGetHapticCapabilities(out caps))
        {
            if (caps.supportsImpulse)
            {
                InputDevices.GetDeviceAtXRNode(node).SendHapticImpulse(0, 0.3f, 0.3f); //channel, amp, seconds
            }
        }
    }

}
