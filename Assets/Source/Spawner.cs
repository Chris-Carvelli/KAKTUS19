using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public Rigidbody target;
	public PlanetPhysics obj;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
        	PlanetPhysics spw = Instantiate<PlanetPhysics>(obj, transform.position, transform.rotation);
        	spw.target = target;
        }
    }
}
