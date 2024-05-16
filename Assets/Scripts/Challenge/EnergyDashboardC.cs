using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnergyDashboardC : MonoBehaviour
{
    [SerializeField] private EnergySystemC energySystem;
    [SerializeField] private Image fillBar;
    private void Start()
    {
        // 에너지시스템의 에너지 사용에 대해 fillBar가 변경되도록 수정
        energySystem.OnEnergyChanged += EnergyChanged;
    }

    private void Update()
    {
        energySystem.RecoveryEnergy();
        UpdateEnergyDashboard();
    }

    private void UpdateEnergyDashboard()
    {
        fillBar.transform.localScale = new Vector3(energySystem.Fuel / energySystem.MaxFuel, 1, 1);
    }

    private void EnergyChanged(float energyBurst)
    {
        energySystem.UseEnergy(energyBurst);
    }
}