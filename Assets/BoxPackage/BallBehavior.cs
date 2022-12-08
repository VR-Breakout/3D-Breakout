using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{

    public float MinSpeed = 2;
    public float MaxSpeed = 10;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, MaxSpeed);
        //todo min
        if(rb.velocity.magnitude < MinSpeed)
        {
            rb.velocity = rb.velocity.normalized * MinSpeed;
        }
        /*else if (rb.velocity.magnitude == MinSpeed)
        {
            rb.AddForce(new Vector3(0, 0, 0.1f));
        }*/
    }

    void OnCollisionEnter(Collision collision)
    {
        // todo
    }
}
