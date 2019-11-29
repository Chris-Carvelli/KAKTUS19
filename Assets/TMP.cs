using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TMP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xRot = Input.GetAxis("Horizontal");
        float yRot = Input.GetAxis("Vertical");
        float zRot = Input.GetAxis("Yaw");

        Vector3 rotDir = new Vector3(xRot, yRot, zRot).normalized;

        transform.rotation *= Quaternion.Euler(rotDir);
    }
}
