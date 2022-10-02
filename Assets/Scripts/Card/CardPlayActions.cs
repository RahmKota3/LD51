using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardPlayActions : MonoBehaviour
{
    public UnityEvent OnPlayActions;

    public void PlayCard()
    {
        OnPlayActions?.Invoke();
    }
}
