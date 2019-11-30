using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
	public Color color;
	
	private MeshRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        SetColor(color);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetColor(Color color_) {
    	color = color_;
        renderer.material.color = color;
    }
}
