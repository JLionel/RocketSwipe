using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class RocketMove : MonoBehaviour
{
    [SerializeField] private FloatVariable speedAmount;
    [SerializeField] private FloatVariable fuelAmount;
    [SerializeField] private FloatVariable distanceFlew;
    
    [Range(0.1f,0.3f)]
    [SerializeField] private float fallPrecision = 0.1f;
    
    [SerializeField] private Transform parentTransform;
    
    [Tooltip("Raise an event which give money when fuel is empty")]
    [SerializeField] private GameEvent giveMoney;
    
    [Tooltip("Raise an event which update the main UI")]
    [SerializeField] private GameEvent updateEndUI;

#region SwipeHandle
    [Space(10)]
    [Header("Swipe Power")]
    
    [SerializeField] private IntVariable swipePower;
    
    [Tooltip("Time for the swipe power to lerp to 1")]
    [SerializeField] private float swipeMaxTimer = 3.0f;
    
    private float swipeTimer;
    private float swipeValue;

#endregion
    

    private Rigidbody2D _rigidbody2D;

    private float startYPos;

    private void Awake()
    {
        _rigidbody2D = GetComponentInParent<Rigidbody2D>();
    }

    private bool _lauch = false;
    private float _fuel;
    private float _fuelDepletion = 10f;
    private void Update()
    {
        if(_lauch == true)
        {
            if(_fuel > 0f)
                _fuel -= _fuelDepletion * Time.deltaTime;
            else
                speedAmount.Value = Mathf.Lerp(speedAmount.Value, 0, 1f * Time.deltaTime);

            //reduce swipe power in swipeMaxTimer seconds
            swipeValue = Mathf.Lerp(swipePower.Value , 1f, swipeTimer / swipeMaxTimer);
            swipeTimer += Time.deltaTime;

            Vector3 position = parentTransform.position;
            
            startYPos = position.y;
            position += parentTransform.up * speedAmount.Value * swipeValue * Time.deltaTime;
            
            parentTransform.position = position;

            distanceFlew.Value += transform.position.y - startYPos;
            
            if (speedAmount.Value <= fallPrecision)
            {
                _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
                updateEndUI.Raise(); //activate restart button
                giveMoney.Raise();
                _lauch = false;
            }
            
        }
    }
    
    //call in a GameEvent
    public void LaunchRocket()
    {
        _lauch = true;
        _fuel = fuelAmount.Value;
        swipeTimer = 0f;
        swipeValue = swipePower.Value;
    }
}
