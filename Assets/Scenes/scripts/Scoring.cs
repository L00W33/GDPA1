using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Scoring : MonoBehaviour
{
    // Start is called before the first frame update
    private int Score = 0;
    private int NumEnemies = 10;
    private int NumBalls = 10;
    private bool GameOver = false;
    void Start()
    {
        int Score = 0;
        int NumEnemies = 10;
        int NumBalls = 10;
        bool GameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver == true)
        {
        }
    }

    public void EnemyDeath() { NumEnemies--; Score++; Debug.Log("score"); }
    public void MinusBalls() { NumBalls--; }
    public void AddBalls() { NumBalls += 3; }

}
