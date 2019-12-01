using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class HitEmitter : MonoBehaviour
{
    public UnityEvent OnHit;

    public void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Box")
        {
            OnHit.Invoke();
        }
    }
}
