using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class TimedLaunch : MonoBehaviour
{
    [Tooltip("Time you have to swipe up the more you can till your finger pop off")]
    [SerializeField] private float maxTime = 3.0f;
    
    [Tooltip("Game Event which launch the rocket")]
    [SerializeField] private GameEvent launchRocket;
    
    [Tooltip("Timer displayed before the final launch")]
    [SerializeField] private TextMeshProUGUI timerText;
    
    private float _timer;
    private bool _startTimer;
    
    private void OnEnable()
    {
        _timer = maxTime;
        timerText.text = $"{_timer}";
        _startTimer = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_startTimer == true)
        {
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
                timerText.text = $"{_timer:0.0}";
            }
            else
            {
                launchRocket.Raise();
                
                //doesn't need it anymore till we reload the scene
                Destroy(gameObject);
            }
        }
    }
}
