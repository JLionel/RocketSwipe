using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MySingleton<GameManager>
{
    protected override bool DoDestroyOnLoad => true;

    [SerializeField] private PlayerInformations playerInformations;
    
    [SerializeField] private IntVariable swipePower;
    
    [SerializeField] private GameEvent finalLaunch;
    
    private SwipeDetection _swipeDetection;
    private int _swipeNumber = 0;
    private void Start()
    {
        playerInformations.UpdateAllInformations();
    }

    public void PrepareRocketLaunch()
    {
        _swipeDetection = SwipeDetection.Instance;
        swipePower.Value = 1;
        _swipeNumber = 0;

        _swipeDetection.OnSwipeUp += IncreaseSwipe;
    }
    
    public void LaunchRocket()
    {
        swipePower.Value += _swipeNumber;
        _swipeDetection.OnSwipeUp -= IncreaseSwipe;
        finalLaunch.Raise();
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    private void IncreaseSwipe()
    {
        Debug.Log("Increase swipe");
        _swipeNumber++;
    }
    
    
}
