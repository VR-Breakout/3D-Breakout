using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Destroy(this.gameObject, 3.0f);
    }
}
