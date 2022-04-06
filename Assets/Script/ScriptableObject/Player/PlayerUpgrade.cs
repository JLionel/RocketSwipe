using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Player/PlayerUpgrade")]
public class PlayerUpgrade : ScriptableObject
{
    [SerializeField] private IntVariable speedLevel;
    [SerializeField] private IntVariable fuelLevel;
    
    [SerializeField] private IntVariable playerMoney;
    
    
    [Tooltip("Information onn the price of the upgrade")]
    [SerializeField] private PlayerPricing playerPricing;

    public bool UpgradeSpeed()
    {
        float speedCost = playerPricing.EvaluateSpeedCost(speedLevel.Value);
        if (speedCost <= playerMoney.Value)
        {
            speedLevel.Value++;
            playerMoney.Value -= (int) speedCost;
            playerPricing.UpdatePrincing(speedLevel.Value, fuelLevel.Value);
            return true;
        }

        return false;
    }
    
    public bool UpgradeFuel()
    {
        float fuelCost = playerPricing.EvaluateFuelCost(fuelLevel.Value);
        if (fuelCost <= playerMoney.Value)
        {
            fuelLevel.Value++;
            playerMoney.Value -= (int) fuelCost;
            playerPricing.UpdatePrincing(speedLevel.Value, fuelLevel.Value);
            return true;
        }

        return false;
    }
}
