using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EveryNthCard : BaseItem
{
    void HandleCardPlayed()
    {
        OnItemTriggered?.Invoke();
    }

    private void Start()
    {
        EventsManager.Instance.OnCardPlayed += HandleCardPlayed;
    }

    private void OnDestroy()
    {
        EventsManager.Instance.OnCardPlayed -= HandleCardPlayed;
    }
}
