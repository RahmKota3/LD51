using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timer;
    [HideInInspector] public float TimeLeftInTurn = 10f;

    bool playersTurn = true;

    string format;

    void DecreaseTime()
    {
        TimeLeftInTurn -= Time.deltaTime;

        if(TimeLeftInTurn <= 0)
        {
            timer.gameObject.SetActive(false);
            TurnManager.Instance.EndTurn();
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
        playersTurn = true;
        timer.gameObject.SetActive(true);
    }

    private void Start()
    {
        EventsManager.Instance.OnPlayerTurnStart += ResetTimer;
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
    }
}
