using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseEventOnce : MonoBehaviour
{
    [SerializeField] private GameEvent gameStateEvent;

    private void Start()
    {
        if( gameStateEvent != null)
            gameStateEvent.Raise();
    }

    public void Raise(GameEvent toRaise)
    {
        toRaise.Raise();
    }
}
