using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
	public Vector3 offsetRot;
	public Transform rotationTarget;
	public float rotSpeed = 3;
	private Rigidbody body;

	[Header("JoyCon")]
	private List<Joycon> joycons;

	// Values made available via Unity
	public float[] stick;
	public Vector3 gyro;
	public Vector3 accel;
	public int jc_ind = 0;
	public Quaternion orientation;

	[Header("Debug")]
	public Vector3 rotDir;

	void Start() {
		body = GetComponent<Rigidbody>();

		gyro = new Vector3(0, 0, 0);
		accel = new Vector3(0, 0, 0);
		// get the public Joycon array attached to the JoyconManager in scene
		joycons = JoyconManager.Instance.j;
		if (joycons.Count < jc_ind+1){
			Destroy(gameObject);
		}

		transform.rotation = joycons[jc_ind].GetVector();
	}
	// Update is called once per frame
	void FixedUpdate()
	{
		if (joycons.Count > 0) {
			Joycon j = joycons[jc_ind];
			orientation = j.GetVector();
			//body.MoveRotation(orientation);
			Quaternion rot = joycons[jc_ind].GetVector();
			/*rot = Quaternion.identity *
					Quaternion.AngleAxis(rot.eulerAngles.y, Vector3.up) *
					Quaternion.AngleAxis(rot.eulerAngles.z, Vector3.forward) *
					Quaternion.AngleAxis(rot.eulerAngles.x, Vector3.right);*/
			transform.rotation = rot;
		}
		else {
			float xRot = Input.GetAxis("Horizontal");
			float yRot = Input.GetAxis("Vertical");
			float zRot = Input.GetAxis("Yaw");

			rotDir = new Vector3(xRot, yRot, zRot).normalized;

			body.MoveRotation(body.rotation * Quaternion.Euler(rotDir * rotSpeed));
		}

		
	}
}
