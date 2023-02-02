using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AircraftWeaponOption : MonoBehaviour
{
    [SerializeField] private AircraftWeapon weaponOption;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private TextMeshProUGUI airToAirText;
    [SerializeField] private TextMeshProUGUI airToGroundText;

    private void Start() 
    {
        nameText.text = weaponOption.weaponName;
        costText.text = "£" + weaponOption.weaponCost.ToString();
        airToAirText.text = "Air-To-Air: " + weaponOption.weaponAirToAir;    
        airToGroundText.text = "Air-To-Ground: " + weaponOption.weaponAirToGround;    
    }

    public void ChangeAircraftWeapon()
    {
        AircraftGenerator.Instance.GenerateWeapon(weaponOption);
        UIManager.Instance.OpenMainMenu();
    }
}
