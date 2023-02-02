using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Aircraft Weapon", order = 2)]
public class AircraftWeapon : ScriptableObject
{
    public string weaponName;
    public GameObject weaponModel;
    public float weaponCost;
    public WeaponType weaponType;

    [Header("Weapon Stats")]
    [Range(0,10)]
    public int weaponAirToAir; 
    [Range(0,10)]
    public int weaponAirToGround; 
}
