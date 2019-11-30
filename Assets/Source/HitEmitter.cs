using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEmitter : MonoBehaviour
{
    public event EventHandler OnObjectHitPlanet;
    public bool IsCounted = false;
    
    public void OnCollisionEnter(Collision collision)
    {
        // Logic for what constitutes hitting the planet
    }
}
