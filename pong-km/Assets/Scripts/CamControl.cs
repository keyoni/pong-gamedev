using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    public Camera fullCam;
    public Camera rightCam;
    public Camera leftCam;
    public Camera ballCam;
    private AudioListener full;

    void Start() {
        fullCam.enabled = true;
        rightCam.enabled = false;
        leftCam.enabled = false;
        ballCam.enabled = false;
    }
 
    void Update() {
 
        //Left Cam
        if (Input.GetKeyDown(KeyCode.C))
        {
            leftCam.enabled = true;
            fullCam.enabled = false;
            rightCam.enabled = false;
            ballCam.enabled = false;
            
        }
        // Full Cam
        if (Input.GetKeyDown(KeyCode.X))
        {
            leftCam.enabled = false;
            fullCam.enabled = true;
            rightCam.enabled = false;
            ballCam.enabled = false;
        }
        
        //Right Cam
        if (Input.GetKeyDown(KeyCode.Z))
        {
            leftCam.enabled = false;
            fullCam.enabled = false;
            rightCam.enabled = true;
            ballCam.enabled = false;
        }
        
        // Ball Cam
        if (Input.GetKeyDown(KeyCode.V))
        {
            leftCam.enabled = false;
            fullCam.enabled = false;
            rightCam.enabled = false;
            ballCam.enabled = true;
        }
    }
}
  
