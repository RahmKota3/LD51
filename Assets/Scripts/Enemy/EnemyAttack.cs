using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] StatsController statsController;
    [SerializeField] AnimationController anim;

    int damage;

    public void AttackPlayer()
    {
        anim.PlayAttackAnimation();
        ReferenceManager.Instance.PlayerStatsController.IncreaseAttribute(AttributeType.CurrentHp, -damage);
        TurnManager.Instance.EnemyAttacked();
    }

    void HandleDamageReductionChange(AttributeType type, float amount)
    {
        if (type != AttributeType.CurrentDamage)
            return;

        damage = (int)amount;
    }

    void HandleEnemyTurnStart()
    {
        AttackPlayer();
    }

    void HandlePlayerTurnStart()
    {
        statsController.SetAttributeTo(AttributeType.CurrentDamage, statsController.GetAttributeValue(AttributeType.Damage));
    }

    private void Start()
    {
        EventsManager.Instance.OnEnemyTurnStart += HandleEnemyTurnStart;
        EventsManager.Instance.OnPlayerTurnStart += HandlePlayerTurnStart;
        statsController.OnAttributeChanged += HandleDamageReductionChange;

        HandlePlayerTurnStart();
    }

    private void OnDestroy()
    {
        EventsManager.Instance.OnEnemyTurnStart -= HandleEnemyTurnStart;
        EventsManager.Instance.OnPlayerTurnStart -= HandlePlayerTurnStart;
    }
}
