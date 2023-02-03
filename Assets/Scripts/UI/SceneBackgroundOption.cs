using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SceneBackgroundOption : MonoBehaviour
{
    [SerializeField] private Material backgroundOption;
    [SerializeField] private TextMeshProUGUI nameText;

    public void ChangeSceneBackground()
    {
        RenderSettings.skybox = backgroundOption;
        UIManager.Instance.SetCurrentBackground(nameText.text);
        UIManager.Instance.OpenMainMenu();
    }
}
