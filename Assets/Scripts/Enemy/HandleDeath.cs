using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleDeath : MonoBehaviour
{
    [SerializeField] HealthController hpController;

    public void HandleEnemyDeath()
    {
        SimplePool.Despawn(this.gameObject);
    }
}
