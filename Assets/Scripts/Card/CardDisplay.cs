using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    [Header("Card")]
    public Card cardData;

    [Header("Display elements")]
    [SerializeField] TextMeshPro nameBox;
    [SerializeField] TextMeshPro descriptionBox;
    [SerializeField] TextMeshPro effectStrengthTextBox;
    [SerializeField] SpriteRenderer cardIcon;
    [SerializeField] SpriteRenderer effectIcon;
    [SerializeField] SpriteRenderer background;
    [SerializeField] SpriteRenderer quickInfoBackground;

    [HideInInspector] public CardSortingLayer layerInHand;
    float defaultZPosition = -999f;

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
        if (layer != CardSortingLayer.HighlightedCard)
        {
            layerInHand = layer;
            defaultZPosition = transform.position.z;
        }

        nameBox.sortingLayerID = SortingLayer.NameToID(layer.ToString());
        descriptionBox.sortingLayerID = SortingLayer.NameToID(layer.ToString());
        effectStrengthTextBox.sortingLayerID = SortingLayer.NameToID(layer.ToString());
        cardIcon.sortingLayerName = layer.ToString();
        effectIcon.sortingLayerName = layer.ToString();
        background.sortingLayerName = layer.ToString();
        quickInfoBackground.sortingLayerName = layer.ToString();

        if (layer == CardSortingLayer.HighlightedCard)
            transform.position = new Vector3(transform.position.x, transform.position.y, -50);
        else
            transform.position = new Vector3(transform.position.x, transform.position.y, defaultZPosition);
    }

    public void ShowCardAboveOhers()
    {
        ChangeSortingLayer(CardSortingLayer.HighlightedCard);
    }

    void UpdateSpriteColor()
    {
        background.color = cardData.CardColor;
        quickInfoBackground.color = cardData.CardColor;
    }
}
