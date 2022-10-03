using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseItem : MonoBehaviour
{
    public int HowManyCardsPlayed = 0;

    [Header("Events")]
    public UnityEvent OnItemTriggered;
    public UnityEvent OnItemAcquired;

    public void AcquireItem()
    {
        OnItemAcquired?.Invoke();
    }

    private void Start()
    {
        AcquireItem();
    }
}
