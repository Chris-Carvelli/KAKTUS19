using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetPhysics : MonoBehaviour
{
	public float gravity = 9.81f;
	public Rigidbody target;

    public Vector2 easeingRange;
    public AnimationCurve distanceEasing;

	[Header("Debug")]
    public float forceMultiplier;
    public float distance;
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
        distance = Vector3.Distance(target.transform.position, transform.position);
    	dir = (target.transform.position - transform.position).normalized;
    	magnitude = dir.magnitude;
        float force = (gravity * (body.mass * target.mass)) / (useDistance ? distance : 1);
        forceMultiplier = distanceEasing.Evaluate(distance);
        force *= forceMultiplier;
        body.AddForce(dir * force, ForceMode.Acceleration);
    }
}
