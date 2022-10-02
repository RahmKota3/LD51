using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DetectTargetting : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject highlight;

    public void OnPointerEnter(PointerEventData eventData)
    {
        highlight.SetActive(true);
        ReferenceManager.Instance.SelectedEnemy = this.gameObject;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        highlight.SetActive(false);
        ReferenceManager.Instance.SelectedEnemy = null;
    }
}
