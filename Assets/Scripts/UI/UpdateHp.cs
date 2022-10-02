using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateHp : UpdateableTextBase
{
    [SerializeField] StatsController stats;

    public override void UpdateTextWithTwoNumbers(int numberAToDisplay, int numberBToDisplay)
    {
        numberBToDisplay = (int)stats.GetAttributeValue(AttributeType.MaxHp);
        base.UpdateTextWithTwoNumbers(numberAToDisplay, numberBToDisplay);
    }

    void HandleHpUpdate(float currentHp)
    {
        UpdateTextWithTwoNumbers((int)currentHp, -999);
    }

    private void Start()
    {
        stats.OnHealthChanged += HandleHpUpdate;

        HandleHpUpdate(stats.GetAttributeValue(AttributeType.CurrentHp));
    }

    private void OnDestroy()
    {
        stats.OnHealthChanged -= HandleHpUpdate;
    }
}
