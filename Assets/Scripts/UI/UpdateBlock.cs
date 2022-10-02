using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateBlock : UpdateableTextBase
{
    void HandleBlockChange(AttributeType type, float value)
    {
        if (type != AttributeType.Block)
            return;

        base.UpdateTextWithNumber((int)value);
    }

    private void Start()
    {
        ReferenceManager.Instance.PlayerStatsController.OnAttributeChanged += HandleBlockChange;

        base.UpdateTextWithNumber((int)ReferenceManager.Instance.PlayerStatsController.GetAttributeValue(AttributeType.Block));
    }

    private void OnDestroy()
    {
        ReferenceManager.Instance.PlayerStatsController.OnAttributeChanged -= HandleBlockChange;
    }
}
