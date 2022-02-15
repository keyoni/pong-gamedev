using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class BallMovement : MonoBehaviour
{
    private Rigidbody _rb;

    public float speed = 7f;
    public GameObject ballSpawner;
    private int _speedCounter = 0;
    public float speedInc = 0.02f;
    private GameObject lastHit;
    
    
   public Vector3 ballMovementVector = new Vector3(1,0,0);
   
    void Start()
    { 
        _rb = GetComponent<Rigidbody>();
       GameStart();
    }

    void GameStart()
    {
        // Add starting force to the ball
        _rb.AddForce(ballMovementVector * speed,ForceMode.VelocityChange);
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
        _rb.velocity = ballMovementVector * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Paddle":
            case "Wall":
                ballMovementVector = Vector3.Reflect(ballMovementVector, collision.GetContact(0).normal);
                speed += speedInc;
                _speedCounter++;
                _rb.velocity = ballMovementVector * speed;
                if (collision.gameObject.CompareTag("Paddle"))
                {
                    lastHit = collision.gameObject;
                }

                break;
            case "Goal":
                ResetMovement();
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            // Up the powerup Counter on last hit object
            Destroy(other,0.1f);
            //other.gameObject.SetActive(false);
            lastHit.GetComponent<PowerUp>().PowerUpCounter();
            print("Pickup");
        }
        else if (other.gameObject.CompareTag("PickUpBad"))
        {
            Destroy(other,0.1f);
            other.gameObject.SetActive(false);
            lastHit.GetComponent<PowerUp>().PowerUpBadCounter();
            print("BadPickup");
        }
    }

    private void ResetMovement()
    {
        // Reduces speed back to start speed
         speed -= (speedInc * _speedCounter);
         _speedCounter = 0;
         
         // Moves ball back to start spot
         gameObject.transform.position = ballSpawner.transform.position;

         ballMovementVector.x /= Math.Abs(ballMovementVector.x);
    }

  
    
}
