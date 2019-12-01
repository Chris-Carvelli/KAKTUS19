using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStartScreen : MonoBehaviour
{
	public Rigidbody target;
	public PlanetPhysics obj;

    public Vector2 distanceRange;
    
    public Color[] colors;

    public Vector2 spawnEvery;

    public float _lastSpawn = -1;

    // Update is called once per frame
    void Update()
    {
        if (_lastSpawn < 0)
        {
            HereSpawn();
            _lastSpawn = Random.Range(spawnEvery.x, spawnEvery.y);
        }
        _lastSpawn -= Time.deltaTime;
    }

    private void HereSpawn() {
        Spawn(transform.position, transform.rotation);
    }

    private void Spawn(Vector3 pos, Quaternion rot) {
        PlanetPhysics spw = Instantiate<PlanetPhysics>(obj, pos, rot);
        spw.tag = "Box";
        PickUp pickUp = spw.GetComponent<PickUp>();
        pickUp.Init();
        pickUp.SetColor(colors[Random.Range(0, colors.Length)]);
        spw.target = target;
    }
}
