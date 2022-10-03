using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGameOverScreen : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen;

    void ShowGameOverWindow()
    {
        gameOverScreen.SetActive(true);
    }

    private void Start()
    {
        EventsManager.Instance.OnPlayerDeath += ShowGameOverWindow;
    }

    private void OnDestroy()
    {
        EventsManager.Instance.OnPlayerDeath -= ShowGameOverWindow;
    }
}
