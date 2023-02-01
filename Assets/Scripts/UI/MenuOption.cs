using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuOption : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentOption;
    [SerializeField] private TextMeshProUGUI currentCost;

    public void UpdateOption(string newOption, string newCost)
    {
        currentOption.text = newOption;
        currentCost.text = "£" + newCost;
    }

}
