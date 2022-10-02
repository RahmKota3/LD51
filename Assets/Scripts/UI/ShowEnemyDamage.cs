using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEnemyDamage : UpdateableTextBase
{
    [SerializeField] StatsController statsController;

    void HandleDamageChange(AttributeType type, float value)
    {
        if (type != AttributeType.CurrentDamage)
            return;

        base.UpdateTextWithNumber((int)value);
    }

    private void Start()
    {
        statsController.OnAttributeChanged += HandleDamageChange;
    }
}
