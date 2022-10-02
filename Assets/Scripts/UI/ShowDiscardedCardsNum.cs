using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDiscardedCardsNum : UpdateableTextBase
{
    void UpdateCardsNumber()
    {
        base.UpdateTextWithNumber(CardsManager.Instance.NumOfCardsInDiscardPile);
    }

    private void Start()
    {
        EventsManager.Instance.OnCardPlayed += UpdateCardsNumber;
        EventsManager.Instance.OnCardsShuffled += UpdateCardsNumber;

        UpdateCardsNumber();
    }

    private void OnDestroy()
    {
        EventsManager.Instance.OnCardPlayed -= UpdateCardsNumber;
        EventsManager.Instance.OnCardsShuffled -= UpdateCardsNumber;
    }
}
