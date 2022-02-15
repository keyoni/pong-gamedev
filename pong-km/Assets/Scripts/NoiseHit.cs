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
    private float _currentPitch = 1f;
    

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
        _currentPitch += 0.4f;
        if (_currentPitch > _pitchHigh)
        {
            _currentPitch = _pitchLow;
        }
        source.pitch = _currentPitch;
        source.PlayOneShot(sound);
    
    }
}
