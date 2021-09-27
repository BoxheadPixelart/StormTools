using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mover Data", menuName = "CustomData/MoverData", order = 1)]
public class MoverData : ScriptableObject
{
    [SerializeField] public LayerMask layerMask;
    [SerializeField] public float maxLiftDist;
    [SerializeField] public float goalHeight;
    [SerializeField] public float springStrength;
    [SerializeField] public float springDamp;
    [SerializeField] public float uprightSpringStrength;
    [SerializeField] public float uprightSpringDamp;
}
