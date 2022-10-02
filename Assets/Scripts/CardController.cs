using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardController : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Animator anim;
    [SerializeField] CardDisplay cardDisplay;

    public void OnPointerDown(PointerEventData eventData)
    {
        CardsManager.Instance.PlayCard(this.gameObject);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        anim.SetBool(Globals.MouseOverCardAnimBool, true);
        cardDisplay.ChangeSortingLayer(CardSortingLayer.HighlightedCard);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        anim.SetBool(Globals.MouseOverCardAnimBool, false);
        cardDisplay.ChangeSortingLayer(cardDisplay.layerInHand);
    }
}
