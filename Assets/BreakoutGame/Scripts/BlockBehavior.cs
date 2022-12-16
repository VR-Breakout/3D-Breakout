using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehavior : MonoBehaviour
{
    private Global Global;

    public ParticleSystem Particle;
    // Start is called before the first frame update
    void Start()
    {
        Global = GameObject.Find("Global").GetComponent<Global>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (Particle != null)
        {
            Instantiate(Particle, transform.position, Quaternion.identity);
        }
        Global.score += 10;
        Destroy(gameObject, 0.1f);
    }
}
