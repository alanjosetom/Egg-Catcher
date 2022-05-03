using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    // Start is called before the first frame update
    private float horizontalInput;
    float xRange = 20.8f;
    public float speed;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
    }

    // private void OnCollisionEnter(Collision collision)
    // {

    //     if (gameObject.CompareTag("Player"))
    //     {
    //         Debug.Log("got it");
    //     }
    // }
}
