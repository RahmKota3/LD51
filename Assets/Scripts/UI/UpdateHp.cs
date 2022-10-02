using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateHp : UpdateableTextBase
{
    public override void UpdateTextWithTwoNumbers(int numberAToDisplay, int numberBToDisplay)
    {
        numberBToDisplay = (int)ReferenceManager.Instance.PlayerStatsController.GetAttributeValue(AttributeType.MaxHp);
        base.UpdateTextWithTwoNumbers(numberAToDisplay, numberBToDisplay);
    }

    void HandleHpUpdate(float currentHp)
    {
        UpdateTextWithTwoNumbers((int)currentHp, -999);
    }

    private void Start()
    {
        ReferenceManager.Instance.PlayerStatsController.OnHealthChanged += HandleHpUpdate;

        HandleHpUpdate(ReferenceManager.Instance.PlayerStatsController.GetAttributeValue(AttributeType.CurrentHp));
    }

    private void OnDestroy()
    {
        ReferenceManager.Instance.PlayerStatsController.OnHealthChanged -= HandleHpUpdate;
    }
}
