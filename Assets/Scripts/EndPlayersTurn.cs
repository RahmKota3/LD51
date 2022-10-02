using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPlayersTurn : MonoBehaviour
{
    public void TriggerEndTurn()
    {
        TurnManager.Instance.EndPlayerTurn();
    }
}
