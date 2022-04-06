using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManagerMainGameUI : MonoBehaviour
{
    [SerializeField] private IntVariable money;
    [SerializeField] private TextMeshProUGUI moneyText;
    
    [Tooltip("This GO become visible when out of fuel")]
    [SerializeField] private GameObject restartGO;
    
    
    [SerializeField] private FloatVariable distanceFlew;
    [SerializeField] private TextMeshProUGUI distanceText;
    
    private void Awake()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        moneyText.text = $"{money.Value}";
    }

    public void UpdateEndGame()
    {
        distanceText.text = $"{distanceFlew.Value:0.0} m";
        restartGO.SetActive(true);
    }
}
