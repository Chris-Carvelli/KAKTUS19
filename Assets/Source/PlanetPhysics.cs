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

    [Header("Joint config")]
    public float breakForce;
    public float breakTorque;

	[Header("Debug")]
    float force;
    public float velocityMagnitude;
    public float forceMultiplier;
    public float distance;
	public Vector3 dir;
	public float magnitude;

    public bool useDistance = false;

	private Rigidbody body;
    private Rigidbody _originalTarget;
    FixedJoint _stickJoint;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();

        _forceScale = travelScale;
        _originalTarget = target;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distance = Vector3.Distance(target.transform.position, transform.position);
    	dir = (target.transform.position - transform.position).normalized;
    	magnitude = dir.magnitude;
        force = (gravity * (body.mass * target.mass)) / (useDistance ? distance : 1);
        forceMultiplier = _forceScale;
        force *= forceMultiplier;

        velocityMagnitude = body.velocity.magnitude;
        if (!_collided)
            body.AddForce(dir * force, ForceMode.Acceleration);
        /*else if (velocityMagnitude * 2 > breakForce) {
            Destroy(_stickJoint);
            _collided = false;
        }*/
    }

    public void OnCollisionEnter(Collision c) {
        /*print(name);
        _forceScale = landedScale;*/

        if (!_collided && attractToCollided) {
            body.velocity = Vector3.zero;
            body.angularVelocity = Vector3.zero;
            _stickJoint = gameObject.AddComponent<FixedJoint>();
            _stickJoint.breakForce = breakForce;
            //_stickJoint.breakTorque = breakTorque;
            _stickJoint.connectedBody = target;
        }

        //body.isKinematic = true;
        
        _collided = true;
    }

    public void OnJointBreak(float f) {
        print($"breaking force: {f}");
        body.AddForce(-(target.transform.position - transform.position).normalized,ForceMode.Impulse);
        _collided = false;
        _forceScale = travelScale;
    }
    /*public void OnCollisionExit(Collision c) {
        _forceScale = travelScale;
        target = _originalTarget;
        _collided = false;
    }*/
}
