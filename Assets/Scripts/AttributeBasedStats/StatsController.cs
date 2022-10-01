using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttributeType { None, MaxHp, CurrentHp }

public class StatsController : MonoBehaviour
{
    [SerializeField] Stats statsPrefab;
    Stats currentStats;

    Dictionary<AttributeType, int> attributeAndItsOrder = new Dictionary<AttributeType, int>();

    public System.Action<AttributeType, float> OnAttributeChanged;

    public float GetAttributeValue(AttributeType type)
    {
        if (StatsContainAttribute(type) == false)
            return -Mathf.Infinity;

        return currentStats.Attributes[attributeAndItsOrder[type]].Value;
    }

    public void IncreaseAttribute(AttributeType type, float increaseBy)
    {
        if (CanModifyAttribute(type) == false)
            return;

        SerializableAttributeDictionary attributeToIncrease = 
            currentStats.Attributes[attributeAndItsOrder[type]];

        attributeToIncrease.Value = Mathf.Clamp(attributeToIncrease.Value + increaseBy, 
            attributeToIncrease.MinValue, attributeToIncrease.MaxValue);

        OnAttributeChanged?.Invoke(type, attributeToIncrease.Value);
    }

    public void SetAttributeTo(AttributeType type, float value)
    {
        if (CanModifyAttribute(type) == false)
            return;

        SerializableAttributeDictionary attributeToIncrease =
            currentStats.Attributes[attributeAndItsOrder[type]];

        attributeToIncrease.Value = Mathf.Clamp(value, attributeToIncrease.MinValue, 
            attributeToIncrease.MaxValue);

        OnAttributeChanged?.Invoke(type, attributeToIncrease.Value);
    }

    bool StatsContainAttribute(AttributeType type)
    {
        if (attributeAndItsOrder.ContainsKey(type))
        {
            return true;
        }
        else
        {
            Debug.LogError($"{statsPrefab.name} does not contain {type}");
            return false;
        }
    }

    void SetAttributesInOrder()
    {
        for (int i = 0; i < statsPrefab.Attributes.Count; i++)
        {
            attributeAndItsOrder[statsPrefab.Attributes[i].Attribute] = i;
        }
    }

    bool CanModifyAttribute(AttributeType type)
    {
        if (StatsContainAttribute(type) == false)
        {
            return false;
        }

        return true;
    }

    private void Awake()
    {
        currentStats = Instantiate(statsPrefab);
        SetAttributesInOrder();
    }
}
