using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NoiseHit : MonoBehaviour 


{
    public AudioSource source;

    private float _pitchHigh = 2f;
    private float _pitchLow =  1f;
    

    public AudioClip sound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        float ran = Random.Range(_pitchLow, _pitchHigh);
        source.pitch = ran;
        source.PlayOneShot(sound);
    
    }
}
