using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Scoring _Scoring;
    private Rigidbody RigidEnemy;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody RigidEnemy = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ball")
        {
            _Scoring.EnemyDeath();
            Destroy(RigidEnemy);
        }
    }
}
