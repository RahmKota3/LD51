using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseTime : MonoBehaviour
{
    [SerializeField] CardDisplay cardDisplay;

    public void IncreaseTimer()
    {
        FindObjectOfType<Timer>().IncreaseTime(cardDisplay.cardData.EffectStrength);
    }
}
