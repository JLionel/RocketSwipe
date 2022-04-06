using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManagerUpgradeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI speedLevelText;
    [SerializeField] private TextMeshProUGUI fuelLevelText;
    
    [SerializeField] private TextMeshProUGUI speedCost;
    [SerializeField] private TextMeshProUGUI fuelCost;
    
    [SerializeField] private IntVariable speedPricing;
    [SerializeField] private IntVariable fuelPricing;
    
    [SerializeField] private IntVariable speedLevel;
    [SerializeField] private IntVariable fuelLevel;

    private void Awake()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        //update level
        speedLevelText.text = $"{speedLevel.Value}";
        fuelLevelText.text = $"{fuelLevel.Value}";
        
        //update Cost
        speedCost.text = $"Coûte : {speedPricing.Value}";
        fuelCost.text = $"Coûte : {fuelPricing.Value}";
    }
}
