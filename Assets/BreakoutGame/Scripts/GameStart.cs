using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    private Global m_global;
    // Start is called before the first frame update
    void Start()
    {
        m_global = GameObject.Find("Global").GetComponent<Global>();
        if (m_global == null)
        {
            Debug.LogError("need assign Global object to Game Start Object");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            m_global.Createblocks();
            Destroy(gameObject);
        }
    }
}
