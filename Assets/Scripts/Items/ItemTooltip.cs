using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ItemTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject tooltipObj;
    [SerializeField] TextMeshProUGUI tooltipText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowTooltip();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HideTooltip();
    }

    public void SetText(string tooltip)
    {
        tooltipText.text = tooltip;
    }

    void ShowTooltip()
    {
        tooltipObj.gameObject.SetActive(true);
    }
    
    void HideTooltip()
    {
        tooltipObj.gameObject.SetActive(false);
    }
}
