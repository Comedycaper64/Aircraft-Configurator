using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftGenerator : MonoBehaviour
{
    public static AircraftGenerator Instance {get; private set;}

    [SerializeField] private AircraftBase defaultAircraftBase;
    [SerializeField] private AircraftWeapon defaultWeapon;
    [SerializeField] private AircraftColour defaultPrimaryColour;
    [SerializeField] private AircraftColour defaultSecondaryColour;
    [SerializeField] private UIManager uIManager;

    [Header("Current Model:")]
    public AircraftBase currentBase;
    public AircraftColour currentPrimaryColour;
    public AircraftColour currentSecondaryColour;
    public AircraftWeapon currentWeapon;
    private GameObject activeModel;
    private Vector3 modelLocation;
    private GameObject activeWeapon;

    private void Awake() 
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one AircraftGenerator! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;

        GenerateAircraft(defaultAircraftBase);
        UpdateColour(defaultPrimaryColour, true);
        UpdateColour(defaultSecondaryColour, false);
        GenerateWeapon(defaultWeapon);
    }

    public void GenerateAircraft(AircraftBase newBase)
    {
        if (newBase)
        {
            currentBase = newBase;
        }
        if (activeModel)
        {
            Destroy(activeModel);
        }

        activeModel = Instantiate(currentBase.aircraftModel, modelLocation, Quaternion.identity);

        UpdateSpoilerLocation();
        UpdateUI();
    }

    public void GenerateWeapon(AircraftWeapon newWeapon)
    {
        if (activeWeapon)
        {
            Destroy(activeWeapon);
        }

        if (!newWeapon)
        {
            currentWeapon = null;
            return;
        }

        currentWeapon = newWeapon;

        if (currentWeapon.weaponModel)
        {
            activeWeapon = Instantiate(currentWeapon.weaponModel, transform.position, Quaternion.identity);
        }
        else
        {
            activeWeapon = null;
        }

        if (currentWeapon.weaponType == WeaponType.Spoiler)
        {
            activeWeapon.transform.position = currentBase.spoilerLocation;
        }
        UpdateUI();
    }

    public void UpdateColour(AircraftColour newColour, bool isPrimaryColour)
    {
        if (isPrimaryColour)
        {
            currentBase.primaryMaterial.color = newColour.colour;
            currentPrimaryColour = newColour;
        }
        else
        {
            currentBase.secondaryMaterial.color = newColour.colour;
            currentSecondaryColour = newColour;
        }
        UpdateUI();
    }

    private void UpdateSpoilerLocation()
    {
        if (activeWeapon == null) {return;}
        activeWeapon.transform.position = currentBase.spoilerLocation;
    }


    private void UpdateUI()
    {
        if (!currentBase || !currentWeapon) {return;}

        uIManager.SetBaseText(currentBase.baseName);

        uIManager.SetCostText(currentBase.baseCost 
        + currentPrimaryColour.colourCost 
        + currentSecondaryColour.colourCost 
        + currentWeapon.weaponCost);

        uIManager.SetStats(
            currentBase.baseSpeed + currentWeapon.weaponSpeed,
            currentBase.baseAccel + currentWeapon.weaponAccel,
            currentBase.baseHandling + currentWeapon.weaponHandling
        );

    }
}
