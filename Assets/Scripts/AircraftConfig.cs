using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftConfig
{
    public AircraftConfig(AircraftBase aircraftBase, AircraftColour aircraftColour1, AircraftColour aircraftColour2, AircraftWeapon aircraftWeapon)
    {
        this.aircraftBase = aircraftBase;
        this.aircraftColour1 = aircraftColour1;
        this.aircraftColour2 = aircraftColour2;
        this.aircraftWeapon = aircraftWeapon;
    }

    public AircraftBase aircraftBase;
    public AircraftColour aircraftColour1;
    public AircraftColour aircraftColour2;
    public AircraftWeapon aircraftWeapon;
}
