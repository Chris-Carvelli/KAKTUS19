using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
	public Transform rotationTarget;
	public float rotSpeed = 3;
	private Rigidbody body;

	[Header("Debug")]
	public Vector3 rotDir;

	void Start() {
        body = GetComponent<Rigidbody>();
	}
    // Update is called once per frame
    void FixedUpdate()
    {
        float xRot = Input.GetAxis("Horizontal");
        float yRot = Input.GetAxis("Vertical");
        float zRot = Input.GetAxis("Yaw");

        rotDir = new Vector3(xRot, yRot, zRot).normalized;

        body.MoveRotation(body.rotation * Quaternion.Euler(rotDir));
    }
}
