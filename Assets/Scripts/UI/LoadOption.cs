using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadOption : MonoBehaviour
{
    public AircraftConfig configOption;
    [SerializeField] private TextMeshProUGUI optionName;
    [SerializeField] private TextMeshProUGUI baseName;
    [SerializeField] private TextMeshProUGUI weaponName;

    public void SetupOption(AircraftConfig config, string configName)
    {
        configOption = config;
        optionName.text = configName;
        baseName.text = config.aircraftBase.name;
        weaponName.text = config.aircraftWeapon.name;
    }

    public void LoadConfig()
    {
        UIManager.Instance.LoadConfig(configOption);
        UIManager.Instance.OpenMainMenu();
    }
}
