using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AircraftWeaponOption : MonoBehaviour
{
    [SerializeField] private AircraftWeapon weaponOption;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private TextMeshProUGUI accelText;
    [SerializeField] private TextMeshProUGUI handlingText;

    private void Start() 
    {
        nameText.text = weaponOption.weaponName;
        costText.text = "£" + weaponOption.weaponCost.ToString();
        speedText.text = "Speed: " + weaponOption.weaponSpeed;    
        accelText.text = "Accel: " + weaponOption.weaponAccel;    
        handlingText.text = "Hand.: " + weaponOption.weaponHandling;    
    }

    public void ChangeCarAccessory()
    {
        AircraftGenerator.Instance.GenerateWeapon(weaponOption);
        UIManager.Instance.OpenMainMenu();
    }
}
