using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBall : MonoBehaviour
{
    public Rigidbody Ball;
    public GameObject SpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Ball.isKinematic = true;
            Ball.transform.position = SpawnPoint.transform.position;
        }
    }
}
