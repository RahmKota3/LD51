using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDrawableCardsNum : UpdateableTextBase
{
    void UpdateCardsNumber()
    {
        base.UpdateTextWithNumber(CardsManager.Instance.NumOfCardsInDrawPile);
    }

    private void Start()
    {
        EventsManager.Instance.OnCardDrawn += UpdateCardsNumber;
        EventsManager.Instance.OnCardsShuffled += UpdateCardsNumber;

        UpdateCardsNumber();
    }

    private void OnDestroy()
    {
        EventsManager.Instance.OnCardDrawn -= UpdateCardsNumber;
        EventsManager.Instance.OnCardsShuffled -= UpdateCardsNumber;
    }
}
