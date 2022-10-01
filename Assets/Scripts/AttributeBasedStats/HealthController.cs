using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField] StatsController stats;

    public UnityEvent OnDeath;

    void HandleHealthChange(AttributeType type, float value)
    {
        if (type != AttributeType.CurrentHp)
            return;

        if (value <= 0)
            OnDeath?.Invoke();
    }

    private void Start()
    {
        stats.OnAttributeChanged += HandleHealthChange;

        stats.SetAttributeTo(AttributeType.CurrentHp, stats.GetAttributeValue(AttributeType.MaxHp));
    }

    private void OnDestroy()
    {
        stats.OnAttributeChanged -= HandleHealthChange;
    }
}
