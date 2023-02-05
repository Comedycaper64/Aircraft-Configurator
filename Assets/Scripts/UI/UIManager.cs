using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance {get; private set;}

    private List<AircraftConfig> savedConfigs = new List<AircraftConfig>();

    [SerializeField] private GameObject currentOpenMenu;
    [SerializeField] private string currentBackground;
    [SerializeField] private GameObject mainMenu;

    [SerializeField] private GameObject loadOptionPrefab;
    [SerializeField] private Transform loadOptionContainer;

    [SerializeField] private TextMeshProUGUI baseText;
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private Slider speedSlider;
    [SerializeField] private Slider defenseSlider;
    [SerializeField] private Slider mobilitySlider;
    [SerializeField] private Slider airToAirSlider;
    [SerializeField] private Slider airToGroundSlider;

    [SerializeField] private MenuOption baseMenuOption;
    [SerializeField] private MenuOption weaponMenuOption;
    [SerializeField] private MenuOption colour1MenuOption;
    [SerializeField] private MenuOption colour2MenuOption;
    [SerializeField] private MenuOption backgroundMenuOption;

    private void Awake() 
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one UIManager! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;    
    }

    private void Start() 
    {
        SetCurrentBackground("Nighttime");
        UpdateOptions();    
    }

    public void OpenScreen(GameObject newMenu)
    {
        currentOpenMenu.SetActive(false);
        newMenu.SetActive(true);
        currentOpenMenu = newMenu;
    }

    public void OpenMainMenu()
    {
        currentOpenMenu.SetActive(false);
        mainMenu.SetActive(true);
        currentOpenMenu = mainMenu;
        UpdateOptions();
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    private void UpdateOptions()
    {
        AircraftGenerator generator = AircraftGenerator.Instance;
        baseMenuOption.UpdateOption(generator.currentBase.baseName, generator.currentBase.baseCost.ToString());
        colour1MenuOption.UpdateOption(generator.currentPrimaryColour.colourName, generator.currentPrimaryColour.colourCost.ToString());
        colour2MenuOption.UpdateOption(generator.currentSecondaryColour.colourName, generator.currentSecondaryColour.colourCost.ToString());
        weaponMenuOption.UpdateOption(generator.currentWeapon.weaponName, generator.currentWeapon.weaponCost.ToString());
        backgroundMenuOption.UpdateOption(currentBackground, "0");
    }

    public void SaveConfig()
    {
        AircraftGenerator generator = AircraftGenerator.Instance;
        savedConfigs.Add(new AircraftConfig(generator.currentBase, generator.currentPrimaryColour, generator.currentSecondaryColour, generator.currentWeapon));
        LoadOption newConfig = Instantiate(loadOptionPrefab, loadOptionContainer).GetComponent<LoadOption>();
        newConfig.SetupOption(savedConfigs[savedConfigs.Count - 1], "Save " + savedConfigs.Count.ToString());
    }
    
    public void LoadConfig(AircraftConfig config)
    {
        AircraftGenerator generator = AircraftGenerator.Instance;
        generator.UpdateColour(config.aircraftColour1, true);
        generator.UpdateColour(config.aircraftColour2, false);
        generator.GenerateAircraft(config.aircraftBase);
        generator.GenerateWeapon(config.aircraftWeapon);
    }

    public void SetBaseText(string newBaseText)
    {
        baseText.text = "Aircraft Model: " + newBaseText;
    }

    public void SetCostText(float newCost)
    {
        costText.text = "Cost: £" + newCost;
    }

    public void SetCurrentBackground(string newBackground)
    {
        currentBackground = newBackground;
    }

    public void SetStats(int newSpeedValue, int newDefenseValue, int newMobilityValue, int newAirToAirValue, int newAirToGroundValue)
    {
        speedSlider.value = newSpeedValue;
        defenseSlider.value = newDefenseValue;
        mobilitySlider.value = newMobilityValue;
        airToAirSlider.value = newAirToAirValue;
        airToGroundSlider.value = newAirToGroundValue;
    }
}
