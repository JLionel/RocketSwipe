using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/PlayerPricing")]
public class PlayerPricing : ScriptableObject
{
    [Tooltip("Cost of the speed level depending on the current one")]
    [SerializeField] private AnimationCurve speedLevelCost;
    
    [Tooltip("Cost of the fuel level depending on the current one")]
    [SerializeField] private AnimationCurve fuelLevelCost;
    
    
    
    [SerializeField] private IntVariable fuelPrice;
    [SerializeField] private IntVariable speedPrice;

    public float EvaluateSpeedCost(float toEvaluate)
    {
        float price  = speedLevelCost.Evaluate(toEvaluate);
        return price;
    }
    
    public float EvaluateFuelCost(float toEvaluate)
    {
        float price  = fuelLevelCost.Evaluate(toEvaluate);
        return price;
    }

    public void UpdatePrincing(float speed, float fuel)
    {
        speedPrice.Value = (int) speedLevelCost.Evaluate(speed);
        fuelPrice.Value = (int) fuelLevelCost.Evaluate(fuel);
    }
}
