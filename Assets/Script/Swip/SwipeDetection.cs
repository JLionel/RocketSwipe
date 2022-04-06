using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class SwipeDetection : MySingleton<SwipeDetection>
{
    #region event

    public delegate void SwipeUp();
    public event SwipeUp OnSwipeUp;
    
    
    public delegate void SwipeDown();
    public event SwipeDown OnSwipeDown;
    
    
    public delegate void SwipeRight();
    public event SwipeRight OnSwipeRight;
    
    
    public delegate void SwipeLeft();
    public event SwipeLeft OnSwipeLeft;
    
    #endregion
    
    [Tooltip("Minimum distance a swipe need to be")]
    [SerializeField] private float minDistance = 0.2f;

    [Tooltip("Maximum time a swipe can take")] 
    [SerializeField] private float maxTime = 1f;

    [Tooltip("Angle to tell the swipe direction")]
    [SerializeField] private float directionTreshold = .9f;
    
    private InputManager _inputManager;
    
    private Vector2 _startPosition;
    private float _startTime;
    
    
    private Vector2 _endPosition;
    private float _endTime;

    protected override bool DoDestroyOnLoad => true;

    private new void Awake()
    {
        base.Awake();
        _inputManager = InputManager.Instance;
    }

    private void OnEnable()
    {
        _inputManager.OnStartTouch += SwipeStart;
        _inputManager.OnEndTouch += SwipeEnd;
    }

    private void OnDisable()
    {
        _inputManager.OnStartTouch -= SwipeStart;
        _inputManager.OnEndTouch -= SwipeEnd;
    }

    private void SwipeStart(Vector2 pos, float time)
    {
        _startPosition = pos;
        _startTime = time;
    }
    
    
    private void SwipeEnd(Vector2 pos, float time)
    {
        _endPosition = pos;
        _endTime = time;
        ManageSwipe();
    }

    private void ManageSwipe()
    {
        if (Vector2.Distance(_startPosition, _endPosition) >= minDistance
            && (_endTime - _startTime) <= maxTime)
        {
            Vector3 direction = _endPosition - _startPosition;
            Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
            SwipeDirection(direction2D);
        }
    }

    private void SwipeDirection(Vector2 direction)
    {
        if (Vector2.Dot(Vector2.up, direction) > directionTreshold)
        {
            if (OnSwipeUp != null)
            {
                OnSwipeUp(); 
            }
        }
        else if (Vector2.Dot(Vector2.down, direction) > directionTreshold)
        {
            if (OnSwipeDown != null)
            {
                OnSwipeDown();
            }
        }
        else if (Vector2.Dot(Vector2.right, direction) > directionTreshold)
        {
            if (OnSwipeRight != null)
            {
                OnSwipeRight();
            }
        }
        else if (Vector2.Dot(Vector2.left, direction) > directionTreshold)
        {
            if (OnSwipeLeft != null)
            {
                OnSwipeLeft();
            }
        }
    }
}
