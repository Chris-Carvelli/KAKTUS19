using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
	public Color color;
	
	private MeshRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        Init();
        
    }

    // Update is called once per frame
    void Update()
    {
    	
    }

    public void Init() {
    	renderer = GetComponent<MeshRenderer>();
    }

    public void SetColor(Color color_) {
    	color = color_;
        renderer.material.color = color;
    }
}
