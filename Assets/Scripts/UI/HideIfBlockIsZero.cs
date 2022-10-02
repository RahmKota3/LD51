using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideIfBlockIsZero : MonoBehaviour
{
    [SerializeField] StatsController stats;
    [SerializeField] GameObject objectToHide;

    void HandleBlockChange(AttributeType type, float value)
    {
        if (type != AttributeType.Block)
            return;

        if (value <= 0)
            objectToHide.SetActive(false);
        else
            objectToHide.SetActive(true);
    }

    private void Start()
    {
        stats.OnAttributeChanged += HandleBlockChange;

        HandleBlockChange(AttributeType.Block, stats.GetAttributeValue(AttributeType.Block));
    }

    private void OnDestroy()
    {
        stats.OnAttributeChanged -= HandleBlockChange;
    }
}
