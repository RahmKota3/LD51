using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardController : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        CardsManager.Instance.PlayCard(this.gameObject);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // TODO: Implement animation.
    }
}
