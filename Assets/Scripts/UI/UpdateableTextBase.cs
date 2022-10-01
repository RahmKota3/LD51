using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateableTextBase : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string textToDisplay = "{0}";

    public virtual void UpdateTextWithNumber(int numberToDisplay)
    {
        textComponent.text = string.Format(textToDisplay, numberToDisplay);
    }
}
