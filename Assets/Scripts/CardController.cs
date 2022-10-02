using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardController : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
{
    [SerializeField] Animator anim;
    [SerializeField] CardDisplay cardDisplay;

    bool isSelected = false;
    Vector2 offsetFromCursor = Vector2.zero;
    Vector3 previousPosition = Vector3.zero;

    public void OnPointerDown(PointerEventData eventData)
    {
        //CardsManager.Instance.PlayCard(this.gameObject);

        if (ReferenceManager.Instance.IsCardSelected)
            return;

        isSelected = true;
        ReferenceManager.Instance.IsCardSelected = true;
        offsetFromCursor = (Vector2)transform.position - InputManager.Instance.MousePos;
        previousPosition = transform.position;
        cardDisplay.ChangeSortingLayer(CardSortingLayer.HighlightedCard);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isSelected = false;
        ReferenceManager.Instance.IsCardSelected = false;
        transform.position = previousPosition;

        if (InputManager.Instance.MousePos.y >= ReferenceManager.Instance.PlayCardYPosition)
        {
            CardsManager.Instance.PlayCard(this.gameObject);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (ReferenceManager.Instance.IsCardSelected)
            return;

        anim.SetBool(Globals.MouseOverCardAnimBool, true);
        cardDisplay.ChangeSortingLayer(CardSortingLayer.HighlightedCard);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isSelected)
            return;

        anim.SetBool(Globals.MouseOverCardAnimBool, false);
        cardDisplay.ChangeSortingLayer(cardDisplay.layerInHand);
    }

    Vector3 GetMousePositionWithOffset()
    {
        return new Vector3(InputManager.Instance.MousePos.x + offsetFromCursor.x, 
            InputManager.Instance.MousePos.y + offsetFromCursor.y, transform.position.z);
    }

    void LateUpdate()
    {
        if (isSelected == false)
            return;

        transform.position = GetMousePositionWithOffset();
    }
}
