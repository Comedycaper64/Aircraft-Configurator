using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBase", menuName = "Aircraft Base", order = 0)]
public class AircraftBase : ScriptableObject 
{
    public string baseName;
    public GameObject aircraftModel;
    public float baseCost;
    public Material primaryMaterial;
    public Material secondaryMaterial;
    public Vector3 spoilerLocation;

    [Header("Model Stats")]
    [Range(0, 7)]
    public int baseSpeed;
    [Range(0, 7)]
    public int baseAccel;
    [Range(0, 7)]
    public int baseHandling;
}
