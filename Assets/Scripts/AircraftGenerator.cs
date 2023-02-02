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
    public AircraftTransforms currentAircraftTransforms;
    private GameObject activeModel;
    private Vector3 modelLocation;
    private List<GameObject> activeWeapons = new List<GameObject>();

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
        currentAircraftTransforms = activeModel.GetComponent<AircraftTransforms>();

        currentAircraftTransforms.ToggleRotors(true);

        UpdateWeaponLocations();
        UpdateUI();
    }

    public void GenerateWeapon(AircraftWeapon newWeapon)
    {
        ClearActiveWeapons();

        if (!newWeapon)
        {
            currentWeapon = null;
            return;
        }

        currentWeapon = newWeapon;

        if (currentWeapon.weaponModel)
        {
            foreach(Transform location in currentAircraftTransforms.weaponLocations)
            {
                activeWeapons.Add(Instantiate(currentWeapon.weaponModel, location));
            }
            
        }
        UpdateUI();
    }

    private void ClearActiveWeapons()
    {
        if (activeWeapons.Count > 0)
        {
            foreach(GameObject weapon in activeWeapons)
            {
                Destroy(weapon);
            }
        }
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

    private void UpdateWeaponLocations()
    {
        if (activeWeapons.Count == 0) {return;}
        ClearActiveWeapons();
        foreach(Transform location in currentAircraftTransforms.weaponLocations)
        {   
            activeWeapons.Add(Instantiate(currentWeapon.weaponModel, location));
        }
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
            currentBase.baseSpeed,
            currentBase.baseDefense,
            currentBase.baseMobility,
            currentWeapon.weaponAirToAir,
            currentWeapon.weaponAirToGround
        );

    }
}
