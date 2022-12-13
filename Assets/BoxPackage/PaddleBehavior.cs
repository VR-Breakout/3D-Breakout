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
        Vector3 normal = -collision.GetContact(0).normal;

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
                InputDevices.GetDeviceAtXRNode(node).SendHapticImpulse(0, 0.7f, 0.5f); //channel, amp, seconds
            }
        }

        //Debug.Log(normal);
        //Debug.Log(velocity);
        collision.gameObject.GetComponent<Rigidbody>().AddForce(normal * velocity); //assume contact is instantaenous? f * t
    }

}
