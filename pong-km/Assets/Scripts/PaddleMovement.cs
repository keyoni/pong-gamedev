using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 10f;
    public int paddleId;
    
  
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float yInput = 0f;
        // Moves depending on paddle
        if (paddleId == 1)
        { 
            yInput= Input.GetAxis("LeftPaddle");
            
        } else if (paddleId == 2)
        { 
            yInput= Input.GetAxis("RightPaddle");
        }
        
        //Create a vector3 with movement vectors
        Vector3 movement = new Vector3(0, 0,yInput);
        
        //Add Force Needs a vector3 variable 
        rb.velocity = movement * speed * Time.deltaTime;
    }
}
