using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    [Header("Card")]
    [SerializeField] Card cardData;

    [Header("Display elements")]
    [SerializeField] TextMeshPro nameBox;
    [SerializeField] TextMeshPro descriptionBox;
    [SerializeField] TextMeshPro effectStrengthTextBox;
    [SerializeField] SpriteRenderer cardIcon;
    [SerializeField] SpriteRenderer effectIcon;
    [SerializeField] SpriteRenderer background;
    [SerializeField] SpriteRenderer quickInfoBackground;

    [ContextMenu("Populate card")]
    public void DisplayCard()
    {
        if(cardData == null)
        {
            Debug.LogError("No card set for: " + this.gameObject.name);
            return;
        }

        nameBox.text = cardData.Name;
        descriptionBox.text = string.Format(cardData.Description, cardData.EffectStrength);
        effectStrengthTextBox.text = cardData.EffectStrength.ToString();
        cardIcon.sprite = cardData.CardIcon;
        effectIcon.sprite = cardData.EffectIcon;

        UpdateSpriteColor();
    }

    public void ChangeSortingLayer(CardSortingLayer layer)
    {
        nameBox.sortingLayerID = SortingLayer.NameToID(layer.ToString());
        descriptionBox.sortingLayerID = SortingLayer.NameToID(layer.ToString());
        effectStrengthTextBox.sortingLayerID = SortingLayer.NameToID(layer.ToString());
        cardIcon.sortingLayerName = layer.ToString();
        effectIcon.sortingLayerName = layer.ToString();
        background.sortingLayerName = layer.ToString();
        quickInfoBackground.sortingLayerName = layer.ToString();
    }

    void UpdateSpriteColor()
    {
        background.color = cardData.CardColor;
        quickInfoBackground.color = cardData.CardColor;
    }
}
