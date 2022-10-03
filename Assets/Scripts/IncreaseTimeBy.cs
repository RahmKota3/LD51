using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseTimeBy : MonoBehaviour
{
    [SerializeField] float increaseBy;

    public void IncreaseTime()
    {
        GameReferenceManager.Instance.Timer.IncreaseTime(increaseBy);
    }
}
