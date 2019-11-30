using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetPhysics : MonoBehaviour
{
	public float gravity = 9.81f;
	public Rigidbody target;

    public float travelScale;
    public float landedScale;
    public bool attractToCollided;

    private float _forceScale;
    private bool _collided = false;

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

        _forceScale = travelScale;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distance = Vector3.Distance(target.transform.position, transform.position);
    	dir = (target.transform.position - transform.position).normalized;
    	magnitude = dir.magnitude;
        float force = (gravity * (body.mass * target.mass)) / (useDistance ? distance : 1);
        forceMultiplier = _forceScale;
        force *= forceMultiplier;
        body.AddForce(dir * force, ForceMode.Acceleration);
    }

    public void OnCollisionEnter(Collision c) {
        print(name);
        _forceScale = landedScale;

        if (!_collided && attractToCollided)
            target = c.transform.GetComponent<Rigidbody>();
        _collided = true;
    }

    /*public void OnCollisionExit(Collision c) {
        _forceScale = travelScale;
        target = c.transform.GetComponent<Rigidbody>();
        _collided = false;
    }*/
}
