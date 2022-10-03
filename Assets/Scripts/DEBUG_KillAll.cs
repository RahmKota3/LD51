using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBUG_KillAll : MonoBehaviour
{
    void KillAll()
    {
        StatsController[] list = FindObjectsOfType<StatsController>();

        foreach (StatsController item in list)
        {
            if (item != ReferenceManager.Instance.PlayerStatsController)
                item.IncreaseAttribute(AttributeType.CurrentHp, -9999);
        }
    }

    private void Start()
    {
        EventsManager.Instance.OnDebugButtonPressed += KillAll;
    }
}
