using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[CreateAssetMenu(menuName = "Player/PlayerInformations")]
public class PlayerInformations : ScriptableObject
{
    [Header("Other informations")]
    [Tooltip("Information on the upgrades available")]
    [SerializeField] private PlayerUpgrade playerUpgrade;
    
    [Tooltip("Information onn the price of the upgrade")]
    [SerializeField] private PlayerPricing playerPricing;
    
    [Header("Rocket informations")]
    [Tooltip("How fast the rocket go")]
    [SerializeField] private FloatVariable rocketSpeed;
    
    [Tooltip("How much fuel the rocket can transport")]
    [SerializeField] private FloatVariable rocketFuel;
    
    
    [SerializeField] private IntVariable speedLevel;
    
    [Tooltip("How much fuel the rocket can transport")]
    [SerializeField] private IntVariable fuelLevel;

    [Tooltip("Speed of the rocket depending of his level")]
    [SerializeField] private AnimationCurve speedLevelNumber;
    
    [Tooltip("Fuel of the rocket depending of his level")]
    [SerializeField] private AnimationCurve fuelLevelNumber;

    public void OnUpgradeSpeed()
    {
        if (playerUpgrade.UpgradeSpeed())
            UpdateSpeed();
    }

    private void UpdateSpeed()
    {
        float speedLevelValue = speedLevel.Value;
        rocketSpeed.Value = speedLevelNumber.Evaluate(speedLevelValue);
    }
    
    public void OnUpgradeFuel()
    {
        if (playerUpgrade.UpgradeFuel())
            UpdateFuel();
    }

    private void UpdateFuel()
    {
        float fuelLevelValue = fuelLevel.Value;
        rocketFuel.Value = fuelLevelNumber.Evaluate(fuelLevelValue);
    }
    
    public void UpdateAllInformations()
    {
        playerPricing.UpdatePrincing(speedLevel.Value, fuelLevel.Value);
        
        UpdateFuel();
        UpdateSpeed();
    }
}
