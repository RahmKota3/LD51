using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockEnemyAttack : MonoBehaviour
{
    [SerializeField] CardDisplay cardDisplay;

    StatsController target;
    float reduction;

    public void ReduceEnemyAttack()
    {
        target = ReferenceManager.Instance.SelectedEnemy.GetComponent<StatsController>();
        reduction = -cardDisplay.cardData.EffectStrength;

        target.IncreaseAttribute(AttributeType.CurrentDamage, reduction);
    }
}
