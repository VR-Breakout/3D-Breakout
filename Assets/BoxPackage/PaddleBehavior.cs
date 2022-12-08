using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehavior : MonoBehaviour
{
    Vector3 previousPos;
    private float velocity;

    public GameObject Controller;

    // Start is called before the first frame update
    void Start()
    {
        
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
        //Debug.Log(normal);
        //Debug.Log(velocity);
        collision.gameObject.GetComponent<Rigidbody>().AddForce(normal * velocity); //assume contact is instantaenous? f * t
    }

}
