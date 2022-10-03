using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeModify : BaseItem
{
    [SerializeField] AttributeType attributeToModify;
    [SerializeField] int modifyBy;

    public void HandleItemAcquire()
    {
        ReferenceManager.Instance.PlayerStatsController.IncreaseAttribute(attributeToModify, modifyBy);
    }
}
