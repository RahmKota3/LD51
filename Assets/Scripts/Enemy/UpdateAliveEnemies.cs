using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateAliveEnemies : MonoBehaviour
{
    public void UpdateNumAliveEnemies()
    {
        EncounterManager.Instance.HandleEnemyDeath();
    }
}
