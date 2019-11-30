using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[Serializable]
public class GameConfig : ScriptableObject
{
    [SerializeField]
    public Color[] ObjectColors;
}
