using UnityEngine;
using System;

public class EnergyManager : MonoBehaviour
{
    public static EnergyManager Instance { get; private set; }
    public event Action OnEnergyEnabled;
    public event Action OnEnergyDisabled;

    [Range(0f, 1f)]
    [Tooltip("Chance de pane ao ligar (0 a 1)")]
    public float failureChance = 0.2f;

    private bool hasEnergy = false;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void TryEnableEnergy()
    {
        // Decide aleatoriamente se vai falhar
        if (UnityEngine.Random.value < failureChance)
        {
            DisableEnergy();
            Debug.Log("Pane no sistema! Jogue novamente.");
            return;
        }
        EnableEnergy();
    }

    private void EnableEnergy()
    {
        if (hasEnergy) return;
        hasEnergy = true;
        OnEnergyEnabled?.Invoke();
        Debug.Log("Energia ligada!");
    }

    public void DisableEnergy()
    {
        if (!hasEnergy) return;
        hasEnergy = false;
        OnEnergyDisabled?.Invoke();
        Debug.Log("Energia desligada.");
    }

    public bool HasEnergy() => hasEnergy;
}
