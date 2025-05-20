using UnityEngine;

public class Device : MonoBehaviour
{
    private void OnEnable()
    {
        EnergyManager.Instance.OnEnergyEnabled += TurnOn;
        EnergyManager.Instance.OnEnergyDisabled += TurnOff;
    }

    private void OnDisable()
    {
        EnergyManager.Instance.OnEnergyEnabled -= TurnOn;
        EnergyManager.Instance.OnEnergyDisabled -= TurnOff;
    }

    void Start()
    {
        // Ajusta estado inicial
        if (EnergyManager.Instance.HasEnergy()) TurnOn();
        else TurnOff();
    }

    private void TurnOn()
    {
        // Exemplo: habilita luz, animação, som, etc.
        Light luz = GetComponent<Light>();
        if (luz != null)
            luz.enabled = true;

        Debug.Log($"{name} ligado.");
    }

    private void TurnOff()
    {
        Light luz = GetComponent<Light>();
        if (luz != null)
            luz.enabled = false;

        Debug.Log($"{name} desligado.");
    }

}
