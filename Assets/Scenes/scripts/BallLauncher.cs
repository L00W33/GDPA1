using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balllauncher : MonoBehaviour
{
    
    private float speed;
    public Vector3 direction;
    public Transform target;
    public Rigidbody rb;
    public float speedScaler;

    //needed for ball control/mouse control
    private Vector3 screenPosition;
    private Vector3 worldPosition;

    //needed to update parts of the program for when the ball is being held or is let go
    private bool pressed = false;
    private bool launched = false;

    public Camera MainCamera;
    public Camera BallCamera;

    //for the velocity prediction line
    public LineController _LineController;
    public LineRenderer _LineRenderer;

    //for respawning the ball
    public RespawnBall RespawnBall;

    //functions for switching camerta
    public void ShowMainCamera()
    {
        MainCamera.enabled = true;
        BallCamera.enabled = false;
    }

    public void showBallCamera()
    {
        BallCamera.enabled = true;
        MainCamera.enabled = false;
    }
    private void Start()
    {
        ShowMainCamera();
    }
    void Update()
    {
        if (pressed && !launched && RespawnBall.isReady)
        {
            //sets the ball to mouse position when clicked/held on
            screenPosition = Input.mousePosition;
            worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, 6.5f));
            //multiple statements needed to prevent ball freezing when the mouse is out of bounds
            if (worldPosition.y >= -2.0f && worldPosition.y <= 5f) { rb.position = worldPosition; }
            else if (worldPosition.y <= -2.0f) { rb.position = new Vector3(worldPosition.x, -2.0f, worldPosition.z); }
            else if (worldPosition.y >= 5.0f) { rb.position = new Vector3(worldPosition.x, 5.0f, worldPosition.z); }
            //direction and magnitude are aquired for shooting
            direction = target.position - rb.position;
            speed = direction.magnitude*speedScaler;
            direction.Normalize();

            //trajectory line is drawn
            _LineController.UpdateTrajectory(rb.position, direction * speed);
            _LineRenderer.enabled = true;
        }

        //ball is fired when mouse is let go
        if (!pressed && launched)
        {
            _LineRenderer.enabled = false;
            launched = false;
            showBallCamera();
            rb.AddForce(direction * speed, ForceMode.Impulse);
            RespawnBall.isReady = false;
        }
    }

    //detects when the ball is clicked on/held on
    void OnMouseDown()
    {
        if (launched)
        {
            return;
        }
        if (RespawnBall.isReady)
        {
            pressed = true;
            rb.isKinematic = true;
        }
    }

    //detects when the user lets go of the ball/mouse
    void OnMouseUp()
    {
        if (launched)
        {
            return;
        }
        if (RespawnBall.isReady)
        {
            pressed = false;
            launched = true;
            rb.isKinematic = false;
        }
    }
}
