using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EveryNthCard : BaseItem
{
    int cardsPlayedInRow = 0;

    void HandleCardPlayed()
    {
        cardsPlayedInRow += 1;

        if (cardsPlayedInRow == HowManyCardsPlayed)
        {
            OnItemTriggered?.Invoke();
            cardsPlayedInRow = 0;
        }
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
