using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUiElement : MonoBehaviour
{
    [SerializeField] GameObject baseUiElement;
    [SerializeField] ItemInfoHolder itemInfoHolder;

    public void SpawnElement()
    {
        GameObject g = Instantiate(baseUiElement, Vector3.zero, Quaternion.identity, GameReferenceManager.Instance.ItemsUIElementsHolder);
        g.GetComponent<ItemInfoHolder>().SetNewItem(itemInfoHolder.item);
    }
}
