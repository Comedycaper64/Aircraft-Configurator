using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    private Controls controls;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one InputManager! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;

        controls = new Controls();
        controls.Default.Enable();
    }

    public float GetCameraRotateAmount()
    {
        return controls.Default.RotateCam.ReadValue<float>();
    }

    public float GetCameraZoomAmount()
    {
        return controls.Default.ZoomCam.ReadValue<float>();
    }
}
