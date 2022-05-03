using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int pointValue;
    private Rigidbody playerRb;

    // public GameObject gameObj;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        // gameManager = GameObject.Find("spawnManager").GetComponent();
        // scoreUpdate = gameObj.GetComponent<spawnManager>();
        playerRb = GetComponent<Rigidbody>();
        playerRb.AddForce(Vector3.down * Random.Range(3, 6), ForceMode.Impulse);
        gameManager = GameObject.Find("spawnManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);

        }

    }
}
