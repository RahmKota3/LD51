using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateAliveEnemies : MonoBehaviour
{
    public void UpdateNumAliveEnemies()
    {
        ReferenceManager.Instance.DecreaseNumAliveEnemies();
    }
}
