using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardController : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
{
    [SerializeField] Animator anim;
    [SerializeField] CardDisplay cardDisplay;
    [SerializeField] bool canTarget = false;

    bool isSelected = false;
    bool followCursor = false;
    Vector2 offsetFromCursor = Vector2.zero;
    Vector3 previousPosition = Vector3.zero;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (ReferenceManager.Instance.IsCardSelected)
            return;

        isSelected = true;
        ReferenceManager.Instance.IsCardSelected = true;

        if (canTarget == false)
            HandleNonTargettingCard();
        else
            HandleTargettingCard();

        cardDisplay.ChangeSortingLayer(CardSortingLayer.HighlightedCard);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isSelected = false;
        ReferenceManager.Instance.IsCardSelected = false;

        if(followCursor)
            transform.position = previousPosition;

        if (CanPlayCard())
        {
            CardsManager.Instance.PlayCard(this.gameObject);
        }

        followCursor = false;
        HideTargettingArrow();

        UnhighlightCard();
        OnPointerExit(eventData);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (ReferenceManager.Instance.IsCardSelected)
            return;

        HighlightCard();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //if (isSelected)
        //    return;

        UnhighlightCard();
    }

    void HandleMouseUp()
    {
        if (isSelected == false || canTarget == false)
            return;

        OnPointerUp(new PointerEventData(EventSystem.current));
    }

    void UnhighlightCard()
    {
        anim.SetBool(Globals.MouseOverCardAnimBool, false);
        cardDisplay.ChangeSortingLayer(cardDisplay.layerInHand);
    }

    void HighlightCard()
    {
        anim.SetBool(Globals.MouseOverCardAnimBool, true);
        cardDisplay.ChangeSortingLayer(CardSortingLayer.HighlightedCard);
    }

    void HandleNonTargettingCard()
    {
        offsetFromCursor = (Vector2)transform.position - InputManager.Instance.MousePos;
        previousPosition = transform.position;

        followCursor = true;
    }

    void HandleTargettingCard()
    {
        ReferenceManager.Instance.SelectedCardPos = InputManager.Instance.MousePos;
        ReferenceManager.Instance.TargettingArrowObj.SetActive(true);
    }

    void HideTargettingArrow()
    {
        ReferenceManager.Instance.TargettingArrowObj.SetActive(false);
    }

    bool CanPlayCard()
    {
        if (canTarget == false)
        {
            if (InputManager.Instance.MousePos.y >= ReferenceManager.Instance.PlayCardYPosition)
                return true;
        }
        else
        {
            if (ReferenceManager.Instance.SelectedEnemy != null)
                return true;
        }

        return false;
    }

    Vector3 GetMousePositionWithOffset()
    {
        return new Vector3(InputManager.Instance.MousePos.x + offsetFromCursor.x, 
            InputManager.Instance.MousePos.y + offsetFromCursor.y, transform.position.z);
    }

    void Start()
    {
        EventsManager.Instance.OnLeftMouseUp += HandleMouseUp;
    }

    void LateUpdate()
    {
        if (followCursor == false)
            return;

        transform.position = GetMousePositionWithOffset();
    }
}
