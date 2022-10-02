using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] StatsController statsController;

    public void AttackPlayer()
    {
        int damage = (int)statsController.GetAttributeValue(AttributeType.Damage);
        ReferenceManager.Instance.PlayerStatsController.IncreaseAttribute(AttributeType.CurrentHp, -damage);
    }

    private void Start()
    {
        EventsManager.Instance.DEBUG_OnDrawCardsButtonPressed += AttackPlayer;
    }
}
