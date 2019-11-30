using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Platform : MonoBehaviour
{
    public Color _platformColor;
    [Tooltip("Useful for showing how many boxes are inside of the right color while playing")]
    public bool ShowDebugCounter;

    [SerializeField]
    private int DebugPlatformCounter;

    private MeshRenderer renderer;
    private BoxCollider _collider;
    private List<GameObject> _trackedBoxes = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<BoxCollider>();
        _collider.isTrigger = true;
        renderer = GetComponent<MeshRenderer>();
        SetColor(_platformColor);
    }

    public void Update()
    {
        if (ShowDebugCounter == true)
        {
            DebugPlatformCounter = CountColors();
        }
    }

    public int CountColors()
    {
        int result = 0;
        for (int index = 0; index < _trackedBoxes.Count; index++)
        {
            Color boxColor = _trackedBoxes[index].GetComponent<MeshRenderer>().material.color;
            if (boxColor == _platformColor)
            {
                result += 1;
            }
            else
            {
                result -= 1;
            }
        }
        return result;
    }

    public void OnTriggerEnter(Collider other)
    {
        _trackedBoxes.Add(other.gameObject);
    }

    public void OnTriggerExit(Collider other)
    {
        if (_trackedBoxes.Contains(other.gameObject))
        {
            _trackedBoxes.Remove(other.gameObject);
        }
    }

    public void SetColor(Color color_)
    {
        _platformColor = color_;
        renderer.material.color = _platformColor;
    }
}
