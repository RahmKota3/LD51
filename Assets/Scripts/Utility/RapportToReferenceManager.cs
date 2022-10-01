using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapportToReferenceManager : MonoBehaviour
{
    [SerializeField] StatsController playerStatsController;

    private void Awake()
    {
        ReferenceManager.Instance.PlayerStatsController = playerStatsController;
    }
}
