using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    public float boundLower = -0.5f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < boundLower)
        {
            Destroy(gameObject);
        }
    }
}
