using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBoundary : MonoBehaviour
{
    public GameObject global;
    private AudioSource BreakSound;

    // Start is called before the first frame update
    void Start()
    {
        BreakSound = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            if (global != null)
            {
                global.GetComponent<Global>().numBackwallHits += 1;
            }

            global.GetComponent<Global>().score -= 10;
            BreakSound.PlayOneShot(BreakSound.clip);
            Destroy(collision.gameObject);
        }
    }
}
