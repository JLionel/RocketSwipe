using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

//TODO Standby, need to search more how to implement this
public class AccelerationRotate : MonoBehaviour
{
    [Tooltip("At what value we start to rotate depending of the phone tilt")]
    [Range(0.1f, 0.5f)]
    [SerializeField] private float accPrecision = 0.1f;
    
    [SerializeField] private AnimationCurve rotateAngle;
    
    
    private InputManager _inputManager;

    private void Awake()
    {
        _inputManager = InputManager.Instance;
    }

    private void OnEnable()
    {
        _inputManager.OnAccelerate += RotateRocket;
    }

    private void OnDisable()
    {
        _inputManager.OnAccelerate -= RotateRocket;
    }

    //not functional
    private void RotateRocket(Vector3 acceleration)
    {
        if (Mathf.Abs(acceleration.x) > accPrecision)
        {
            float angle = rotateAngle.Evaluate(acceleration.x);
            Vector3 euler = new Vector3(0, 0, angle);
            
            Quaternion newRotation = quaternion.Euler(euler);
            
            transform.rotation = newRotation;
            Debug.Log($"{euler.ToString()}");
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
