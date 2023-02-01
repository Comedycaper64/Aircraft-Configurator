using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AircraftColourOption : MonoBehaviour
{
    [SerializeField] private AircraftColour aircraftColour;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI costText;

    private void Start() 
    {
        nameText.text = aircraftColour.colourName; 
        costText.text = "£" + aircraftColour.colourCost.ToString();   
    }

    public void ChangeCarColour(bool isPrimaryColour)
    {
        AircraftGenerator.Instance.UpdateColour(aircraftColour, isPrimaryColour);
        UIManager.Instance.OpenMainMenu();
    }
}
