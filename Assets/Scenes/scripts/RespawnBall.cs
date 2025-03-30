using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBall : MonoBehaviour
{
    public balllauncher _BallLauncher;
    public Rigidbody Ball;
    public GameObject SpawnPoint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Ball.isKinematic = true;
            Ball.transform.position = SpawnPoint.transform.position;
            _BallLauncher.ShowMainCamera();
        }
    }
}
