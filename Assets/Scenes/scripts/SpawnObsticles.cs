using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObsticles : MonoBehaviour
{
    public GameObject BuildingPrefab;

    private Collider circleCol;
    private float radius;
    private Vector3 center;
    private Vector3 randomDirection;

    // Start is called before the first frame update
    void Start()
    {
        circleCol = GetComponent<Collider>();
        radius = transform.localScale.x / 2 - 0.5f;
        randomDirection = Random.insideUnitCircle * radius;
        center = transform.position;
        for (int i = 0; i < 3; i++)
        {
            //set a random direction in each loop, spawn obsicles and andemies from a list, make prefabs
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
