using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetPhysics : MonoBehaviour
{
	public float gravity = 9.81f;
	public Rigidbody target;

	[Header("Debug")]
	public Vector3 dir;
	public float magnitude;
    
    public bool useDistance = false;

	private Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);
    	dir = (target.transform.position - transform.position).normalized;
    	magnitude = dir.magnitude;
        float force = (gravity * (body.mass * target.mass)) / (useDistance ? distance : 1);
        body.AddForce(dir * force, ForceMode.Acceleration);
    }
}
