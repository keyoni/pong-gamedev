using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPickUps : MonoBehaviour
{
    public GameObject pickUp;
    public GameObject pickUpBad;

    private bool _lever = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit(Collider other)
    {
        if (_lever)
        {
            Instantiate(pickUp, other.transform.position + new Vector3(-0.1f, 0, -0.1f), other.transform.rotation);
           
        }
        else
        {
            Instantiate(pickUpBad, other.transform.position + new Vector3(-0.1f, 0, -0.1f), other.transform.rotation);   
        } 
        _lever = !_lever;
    }
}
