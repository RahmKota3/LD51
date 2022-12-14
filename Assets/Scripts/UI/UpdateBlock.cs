using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateBlock : UpdateableTextBase
{
    [SerializeField] StatsController stats;

    void HandleBlockChange(AttributeType type, float value)
    {
        if (type != AttributeType.Block)
            return;

        base.UpdateTextWithNumber((int)value);
    }

    private void Start()
    {
        stats.OnAttributeChanged += HandleBlockChange;

        base.UpdateTextWithNumber((int)stats.GetAttributeValue(AttributeType.Block));
    }

    private void OnDestroy()
    {
        stats.OnAttributeChanged -= HandleBlockChange;
    }
}
