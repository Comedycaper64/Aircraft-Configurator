using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance {get; private set;}

    [SerializeField] private GameObject currentOpenMenu;
    [SerializeField] private GameObject mainMenu;

    [SerializeField] private TextMeshProUGUI baseText;
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private Slider speedSlider;
    [SerializeField] private Slider accelSlider;
    [SerializeField] private Slider handlingSlider;

    [SerializeField] private MenuOption baseMenuOption;
    [SerializeField] private MenuOption weaponMenuOption;
    [SerializeField] private MenuOption colour1MenuOption;
    [SerializeField] private MenuOption colour2MenuOption;

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

    private void UpdateOptions()
    {
        AircraftGenerator generator = AircraftGenerator.Instance;
        baseMenuOption.UpdateOption(generator.currentBase.baseName, generator.currentBase.baseCost.ToString());
        colour1MenuOption.UpdateOption(generator.currentPrimaryColour.colourName, generator.currentPrimaryColour.colourCost.ToString());
        colour2MenuOption.UpdateOption(generator.currentSecondaryColour.colourName, generator.currentSecondaryColour.colourCost.ToString());
        weaponMenuOption.UpdateOption(generator.currentWeapon.weaponName, generator.currentWeapon.weaponCost.ToString());
    }

    public void SetBaseText(string newBaseText)
    {
        baseText.text = "Aircraft Model: " + newBaseText;
    }

    public void SetCostText(float newCost)
    {
        costText.text = "Cost: £" + newCost;
    }

    public void SetStats(int newSpeedValue, int newAccelValue, int newHandlingValue)
    {
        speedSlider.value = newSpeedValue;
        accelSlider.value = newAccelValue;
        handlingSlider.value = newHandlingValue;
    }
}
