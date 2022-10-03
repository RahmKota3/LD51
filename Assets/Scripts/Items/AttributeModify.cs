using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeModify : MonoBehaviour
{
    [SerializeField] List<AttributeModificationDictionaryElement> AttributesToModify; 

    public void ModifyAttribute()
    {
        foreach (AttributeModificationDictionaryElement item in AttributesToModify)
        {
            ReferenceManager.Instance.PlayerStatsController.IncreaseAttribute(item.AttributeToModify, item.ModifyBy);
        }
    }
}

[System.Serializable]
public class AttributeModificationDictionaryElement
{
    public AttributeType AttributeToModify;
    public float ModifyBy;
}