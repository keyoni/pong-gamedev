using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCam : MonoBehaviour
{

    // To get the Player posision
    public GameObject ball;

    //To get camera offset from player
    private Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        if (ball != null)
        {
            // camera transfrom postion - player tranform position
            _offset = transform.position - ball.transform.position;
        }
    }

    // Late Update is called once per frame but after all the other updates are done
    void LateUpdate()
    {
        if (ball != null)
        {
            // aligns the camera to where the player is, but not the rotation so that's why it's not a child
            transform.position = ball.transform.position + _offset;
        }
    }
}
