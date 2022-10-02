using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField] StatsController stats;

    public UnityEvent OnDeath;

    void HandleHealthChange(float value)
    {
        SerializableAttributeDictionary attributeToIncrease =
            stats.CurrentStats.Attributes[stats.AttributeAndItsOrder[AttributeType.CurrentHp]];

        // Handle block
        if (value < 0)
        {
            float block = stats.GetAttributeValue(AttributeType.Block);
            stats.IncreaseAttribute(AttributeType.Block, value);

            value = Mathf.Clamp(value + block, -9999, 0);
        }

        attributeToIncrease.Value = Mathf.Clamp(attributeToIncrease.Value + value,
            attributeToIncrease.MinValue, attributeToIncrease.MaxValue);

        stats.OnHealthChanged?.Invoke(stats.GetAttributeValue(AttributeType.CurrentHp));

        if (stats.GetAttributeValue(AttributeType.CurrentHp) <= 0)
            OnDeath?.Invoke();
    }

    private void Start()
    {
        stats.OnBeforeHealthChange += HandleHealthChange;

        stats.SetAttributeTo(AttributeType.CurrentHp, stats.GetAttributeValue(AttributeType.MaxHp));
    }

    private void OnDestroy()
    {
        stats.OnBeforeHealthChange -= HandleHealthChange;
    }
}
