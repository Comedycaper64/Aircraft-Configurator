using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
public static SoundManager Instance { get; private set; }

    [SerializeField] private AudioSource audioSource;

    private float masterVolume;

    private void Awake()
    {
        SetUpSingleton();
        if (Instance != null)
        {
            //Debug.LogError("There's more than one SoundManager! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;

        masterVolume = 1f;
        audioSource.volume = GetMasterVolume();
    }

    private void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public float GetMasterVolume()
    {
        return masterVolume;
    }

    public void SetMasterVolume(float masterVolume)
    {
        this.masterVolume = masterVolume;
        if (audioSource)
            audioSource.volume = GetMasterVolume();
    }
}
