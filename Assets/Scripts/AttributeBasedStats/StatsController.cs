using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsController : MonoBehaviour
{
    [SerializeField] Stats statsPrefab;
    [HideInInspector] public Stats CurrentStats;

    public Dictionary<AttributeType, int> AttributeAndItsOrder = new Dictionary<AttributeType, int>();

    public System.Action<AttributeType, float> OnAttributeChanged;
    public System.Action<float> OnBeforeHealthChange;
    public System.Action<float> OnHealthChanged;

    public float GetAttributeValue(AttributeType type)
    {
        if (StatsContainAttribute(type) == false)
            return -Mathf.Infinity;

        return CurrentStats.Attributes[AttributeAndItsOrder[type]].Value;
    }

    public void IncreaseAttribute(AttributeType type, float increaseBy)
    {
        if (CanModifyAttribute(type) == false)
            return;

        if(type == AttributeType.CurrentHp)
        {
            OnBeforeHealthChange?.Invoke(increaseBy);
            return;
        }

        SerializableAttributeDictionary attributeToIncrease = 
            CurrentStats.Attributes[AttributeAndItsOrder[type]];

        attributeToIncrease.Value = Mathf.Clamp(attributeToIncrease.Value + increaseBy, 
            attributeToIncrease.MinValue, attributeToIncrease.MaxValue);

        OnAttributeChanged?.Invoke(type, attributeToIncrease.Value);
    }

    public void SetAttributeTo(AttributeType type, float value)
    {
        if (CanModifyAttribute(type) == false)
            return;

        SerializableAttributeDictionary attributeToIncrease =
            CurrentStats.Attributes[AttributeAndItsOrder[type]];

        attributeToIncrease.Value = Mathf.Clamp(value, attributeToIncrease.MinValue, 
            attributeToIncrease.MaxValue);

        OnAttributeChanged?.Invoke(type, attributeToIncrease.Value);
    }

    bool StatsContainAttribute(AttributeType type)
    {
        if (AttributeAndItsOrder.ContainsKey(type))
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
            AttributeAndItsOrder[statsPrefab.Attributes[i].Attribute] = i;
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
        CurrentStats = Instantiate(statsPrefab);
        SetAttributesInOrder();
    }
}
