using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameOnDeath : MonoBehaviour
{
    public void HandlePlayerDeath()
    {
        EventsManager.Instance.OnPlayerDeath?.Invoke();
    }
}
