using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] StatsController statsController;

    int damage;

    public void AttackPlayer()
    {
        ReferenceManager.Instance.PlayerStatsController.IncreaseAttribute(AttributeType.CurrentHp, -damage);
    }

    void HandleDamageReductionChange(AttributeType type, float amount)
    {
        if (type != AttributeType.CurrentDamage)
            return;

        damage = (int)amount;
    }

    void HandleTurnChange()
    {
        statsController.SetAttributeTo(AttributeType.CurrentDamage, statsController.GetAttributeValue(AttributeType.Damage));
    }

    private void Start()
    {
        //EventsManager.Instance.DEBUG_OnDrawCardsButtonPressed += AttackPlayer;
        EventsManager.Instance.OnEnemyTurnStart += HandleTurnChange;
        statsController.OnAttributeChanged += HandleDamageReductionChange;

        HandleTurnChange();
    }

    private void OnDestroy()
    {
        EventsManager.Instance.OnEnemyTurnStart -= HandleTurnChange;
    }
}
