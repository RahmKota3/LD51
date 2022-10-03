using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceTime : MonoBehaviour
{
    void HandleEnemyTurnStart()
    {
        TurnManager.Instance.EnemyAttacked();
    }

    void HandlePlayerTurnStart()
    {
        GameReferenceManager.Instance.Timer.ReduceTime(2);
    }

    private void Start()
    {
        EventsManager.Instance.OnPlayerTurnStart += HandlePlayerTurnStart;
        EventsManager.Instance.OnEnemyTurnStart += HandleEnemyTurnStart;
    }

    private void OnDestroy()
    {
        EventsManager.Instance.OnPlayerTurnStart -= HandlePlayerTurnStart;
        EventsManager.Instance.OnEnemyTurnStart -= HandleEnemyTurnStart;
    }
}
