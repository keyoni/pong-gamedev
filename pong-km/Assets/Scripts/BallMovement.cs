using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class BallMovement : MonoBehaviour
{
    private Rigidbody rb;

    public float speed = 7f;
    public GameObject ballSpawner;
    private int speedCounter = 0;
    public float speedInc = 0.02f;
   
    
    
   public Vector3 ballMovementVector = new Vector3(1,0,0);
   
    void Start()
    { 
        rb = GetComponent<Rigidbody>();
       GameStart();
    }

    void GameStart()
    {
        // Add starting force to the ball
        rb.AddForce(ballMovementVector * speed,ForceMode.VelocityChange);
    }

    private void Update()
    {
        // Resets Stuck Ball's Movement
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetMovement();
        }
    }

    private void FixedUpdate()
    {
        // This keeps the ball with good velocity, not sure how, but it worked when I tried it
        rb.velocity = ballMovementVector * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Paddle":
            case "Wall":
                ballMovementVector = Vector3.Reflect(ballMovementVector, collision.GetContact(0).normal);
                speed += speedInc;
                speedCounter++;
                rb.velocity = ballMovementVector * speed;
                break;
            case "Goal":
                ResetMovement();
                break;
        }
    }

    private void ResetMovement()
    {
        // Reduces speed back to start speed
         speed -= (speedInc * speedCounter);
         speedCounter = 0;
         
         // Moves ball back to start spot
         gameObject.transform.position = ballSpawner.transform.position;

         ballMovementVector.x /= Math.Abs(ballMovementVector.x);
    }

  
    
}
