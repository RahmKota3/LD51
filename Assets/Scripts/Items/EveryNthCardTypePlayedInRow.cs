using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EveryNthCardTypePlayedInRow : BaseItem
{
    [SerializeField] CardType cardType;

    int inRow = 0;

    void HandleCardPlayed(CardType type)
    {
        if(cardType == type)
        {
            inRow += 1;
            if (inRow == HowManyCardsPlayed)
                EffectTrigger();
        }
        else
        {
            inRow = 0;
        }
    }

    void EffectTrigger()
    {
        inRow = 0;
        OnItemTriggered?.Invoke();
    }

    private void Start()
    {
        EventsManager.Instance.OnCardTypePlayed += HandleCardPlayed;
    }

    private void OnDestroy()
    {
        EventsManager.Instance.OnCardTypePlayed -= HandleCardPlayed;
    }
}
