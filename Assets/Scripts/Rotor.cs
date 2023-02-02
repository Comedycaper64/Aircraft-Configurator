using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Rotor
{
    public enum RotorSpinAxis
    {
        x,
        y,
        z,
    }

    public Transform rotorTransform;
    public RotorSpinAxis rotorSpinAxis;
}
