using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddUIElement : MonoBehaviour
{
    [SerializeField] GameObject uiElement;

    void AddItemUIElement()
    {
        Instantiate(uiElement, Vector3.zero, Quaternion.identity, GameReferenceManager.Instance.ItemsUIElementsHolder);
    }

    private void Start()
    {
        AddItemUIElement();
    }
}
