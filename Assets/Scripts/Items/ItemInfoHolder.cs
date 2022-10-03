using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoHolder : MonoBehaviour
{
    public ItemInfo item;

    [SerializeField] ItemTooltip tooltipComponent;
    [SerializeField] GetItem getItemButtonComponent;
    [SerializeField] Image itemIcon;

    public void SetNewItem(ItemInfo newItem)
    {
        item = newItem;

        if (getItemButtonComponent != null)
            getItemButtonComponent.SetItemToGet(item.objectToSpawn);

        tooltipComponent.SetText(item.Tooltip);

        itemIcon.sprite = item.itemIcon;
    }
}
