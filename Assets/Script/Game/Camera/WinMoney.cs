using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMoney : MonoBehaviour
{
    [SerializeField] private IntVariable money;
    [SerializeField] private FloatVariable distanceFlew;


    public void GiveMoney()
    {
        money.Value += (int) (distanceFlew.Value / 2f);
        distanceFlew.Value = 0f;
    }
}
