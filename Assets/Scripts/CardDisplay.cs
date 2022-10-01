using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    [Header("Card")]
    [SerializeField] Card cardData;

    [Header("Display elements")]
    [SerializeField] TextMeshPro NameBox;
    [SerializeField] TextMeshPro DescriptionBox;
    [SerializeField] TextMeshPro EffectStrengthTextBox;
    [SerializeField] SpriteRenderer CardIcon;
    [SerializeField] SpriteRenderer EffectIcon;

    [ContextMenu("Populate card")]
    public void DisplayCard()
    {
        if(cardData == null)
        {
            Debug.LogError("No card set for: " + this.gameObject.name);
            return;
        }

        NameBox.text = cardData.Name;
        DescriptionBox.text = cardData.Description;
        EffectStrengthTextBox.text = cardData.EffectStrength.ToString();
        CardIcon.sprite = cardData.CardIcon;
        EffectIcon.sprite = cardData.EffectIcon;
    }
}
