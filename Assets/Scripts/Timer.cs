using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timer;
    [HideInInspector] public float TimeLeftInTurn = 10f;

    //bool playersTurn { get { return TurnManager.Instance.IsPlayersTurn; } }
    bool playersTurn = true;

    string format;

    public void IncreaseTime(float increaseBy)
    {
        TimeLeftInTurn += increaseBy;
    }

    void DecreaseTime()
    {
        TimeLeftInTurn -= Time.deltaTime;

        if(TimeLeftInTurn <= 0)
        {
            TurnManager.Instance.EndPlayerTurn();
        }
    }

    void DisplayTime()
    {
        if (TimeLeftInTurn > 2)
            format = "0";
        else
            format = "0.0";

        timer.text = TimeLeftInTurn.ToString(format) + "s";
    }

    void ResetTimer()
    {
        TimeLeftInTurn = 10f;
        timer.gameObject.SetActive(true);
        playersTurn = true;
    }

    void HandleEnemyTurnStart()
    {
        timer.gameObject.SetActive(false);
        playersTurn = false;
    }

    private void Start()
    {
        EventsManager.Instance.OnPlayerTurnStart += ResetTimer;
        EventsManager.Instance.OnEnemyTurnStart += HandleEnemyTurnStart;
        ResetTimer();
    }

    private void Update()
    {
        if (playersTurn == false)
            return;

        DecreaseTime();
        DisplayTime();
    }

    private void OnDestroy()
    {
        EventsManager.Instance.OnPlayerTurnStart -= ResetTimer;
        EventsManager.Instance.OnEnemyTurnStart -= HandleEnemyTurnStart;
    }
}
