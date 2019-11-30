using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetPhysics : MonoBehaviour
{
	public float gravity = 9.81f;
	public Transform target;

	[Header("Debug")]
	public Vector3 dir;
	public float magnitude;

	private Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    	dir = (target.position - transform.position).normalized;
    	magnitude = dir.magnitude;
        body.AddForce(dir * gravity, ForceMode.Acceleration);
    }
}
