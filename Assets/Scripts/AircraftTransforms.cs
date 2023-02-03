using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftTransforms : MonoBehaviour
{
    public Transform[] weaponLocations;
    public Rotor[] rotors;
    private bool spinRotors;

    [SerializeField] private float rotorSpeed;

    private void Update() 
    {
        if (spinRotors)
        {
            foreach(Rotor rotor in rotors)
            {
                if (rotor.rotorSpinAxis == Rotor.RotorSpinAxis.x)
                {
                    rotor.rotorTransform.Rotate(Vector3.right, rotorSpeed * Time.deltaTime);
                }
                else if (rotor.rotorSpinAxis == Rotor.RotorSpinAxis.y)
                {
                    rotor.rotorTransform.Rotate(Vector3.up, rotorSpeed * Time.deltaTime);
                }
                else if (rotor.rotorSpinAxis == Rotor.RotorSpinAxis.z)
                {
                    rotor.rotorTransform.Rotate(Vector3.forward, rotorSpeed * Time.deltaTime);
                }
            }
        }    
    }

    public void ToggleRotors(bool enable)
    {
        spinRotors = enable;
    }
}
