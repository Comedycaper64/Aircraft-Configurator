using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AircraftBaseOption : MonoBehaviour
{
    [SerializeField] private AircraftBase baseOption;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private TextMeshProUGUI accelText;
    [SerializeField] private TextMeshProUGUI handlingText;

    private void Start() 
    {
        nameText.text = baseOption.baseName;
        costText.text = "£" + baseOption.baseCost.ToString();
        speedText.text = "Speed: " + baseOption.baseSpeed;    
        accelText.text = "Defense: " + baseOption.baseDefense;    
        handlingText.text = "Mobility: " + baseOption.baseMobility;    
    }

    public void ChangeCarBase()
    {
        AircraftGenerator.Instance.GenerateAircraft(baseOption);
        UIManager.Instance.OpenMainMenu();
    }
}
