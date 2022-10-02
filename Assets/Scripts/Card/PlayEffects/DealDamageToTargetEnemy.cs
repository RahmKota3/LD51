using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageToTargetEnemy : MonoBehaviour
{
    [SerializeField] CardDisplay cardDisplay;

    StatsController target;
    float damage;

    public void DealDamageToTarget()
    {
        target = ReferenceManager.Instance.SelectedEnemy.GetComponent<StatsController>();
        damage = -cardDisplay.cardData.EffectStrength;

        target.IncreaseAttribute(AttributeType.CurrentHp, damage);
    }
}
