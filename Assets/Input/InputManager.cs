using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class InputManager : MySingleton<InputManager>
{
    protected override bool DoDestroyOnLoad => true;

    private PlayerActions _playerActions;

    #region InputEvent
    
    //start touch event
    public delegate void StartTouching(Vector2 pos, float time);
    public event StartTouching OnStartTouch;
    
    //end touch event
    public delegate void EndTouching(Vector2 pos, float time);
    public event EndTouching OnEndTouch;

    //accelerometer event
    public delegate void PhoneAccelerometer(Vector3 acceleration);
    public event PhoneAccelerometer OnAccelerate;
    
    #endregion
    
    

    // Start is called before the first frame update
    new void Awake()
    {
        base.Awake();
        _playerActions = new PlayerActions();
        
        //Handle event call start/end touching
        _playerActions.Actions.TouchDetection.started += ctx => HandleStartTouching(ctx);
        _playerActions.Actions.TouchDetection.canceled += ctx => HandleEndTouching(ctx);
    }
    private void OnEnable()
    {
        ActivatePhoneFeature();
        _playerActions.Enable();
    }

    private void ActivatePhoneFeature()
    {
        //activate Accelerometer
        if (Accelerometer.current != null)
            InputSystem.EnableDevice(Accelerometer.current);
        
        //activate Gyroscope
        if (UnityEngine.InputSystem.Gyroscope.current != null)
            InputSystem.EnableDevice(UnityEngine.InputSystem.Gyroscope.current);
        
        //activate Attitude
        if (AttitudeSensor.current != null)
            InputSystem.EnableDevice(AttitudeSensor.current);
    }

    private void OnDisable()
    {
        _playerActions.Disable();
    }

    private void Update()
    {
        HandlePhoneAcceleration();
    }

    public PlayerActions GetPlayerActions
    {
        get => _playerActions;
    }
    
    private void HandleStartTouching(InputAction.CallbackContext ctx)
    {
        if (OnStartTouch != null)
            OnStartTouch(Utils.ScreenToWorldPoint(Camera.main, _playerActions.Data.TouchPosition.ReadValue<Vector2>()), (float) ctx.startTime);
        
    }
    private void HandleEndTouching(InputAction.CallbackContext ctx)
    {
        if (OnEndTouch != null)
            OnEndTouch(Utils.ScreenToWorldPoint(Camera.main,_playerActions.Data.TouchPosition.ReadValue<Vector2>()), (float) ctx.time);
        
    }
    
    private void HandlePhoneAcceleration()
    {
        if (OnAccelerate != null)
            OnAccelerate(_playerActions.Data.PhoneAcceleration.ReadValue<Vector3>());
    }
    
}
