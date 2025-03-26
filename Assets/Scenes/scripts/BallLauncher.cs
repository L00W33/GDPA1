using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balllauncher : MonoBehaviour
{
    
    private float speed;
    public Vector3 direction;
    public Transform target;
    public Rigidbody rb;

    public Vector3 screenPosition;
    public Vector3 worldPosition;

    public bool pressed = true;
    public bool launched = false;

    void Update()
    {
        if (pressed && !launched)
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
            speed = direction.magnitude/2;
            Debug.Log(rb.position);
        }

        //ball is fired when mouse is let go
        if (!pressed && launched)
        {
            rb.AddForce(direction * speed, ForceMode.Impulse);
            launched = false;
        }
    }

    //detects when the ball is clicked on/held on
    void OnMouseDown()
    {
        if (launched)
        {
            return;
        }

        pressed = true;
        rb.isKinematic = true;
    }

    //detects when the user lets go of the ball/mouse
    void OnMouseUp()
    {
        if (launched)
        {
            return;
        }

        pressed = false;
        launched = true;
        rb.isKinematic = false;
    }



}
