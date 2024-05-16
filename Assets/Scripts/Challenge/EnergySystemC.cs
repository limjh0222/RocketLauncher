using System;
using UnityEngine;

public class EnergySystemC : MonoBehaviour
{
    public event Action<float> OnEnergyChanged;
    public float MaxFuel { get; private set; } = 10f;
    public float Fuel { get; private set; } = 10f;

    private void Update()
    {
        RecoveryEnergy();
    }

    public bool UseEnergy(float amount)
    {
        if (Fuel < amount) return false;
        Fuel -= amount;
        return true;
    }

   public void RecoveryEnergy()
    {
        if(Fuel < MaxFuel)
        {
            Fuel += Time.deltaTime;
        }
    }

    public void CallEnergyChanged(float energyBurst)
    {
        OnEnergyChanged?.Invoke(energyBurst);
    }
}